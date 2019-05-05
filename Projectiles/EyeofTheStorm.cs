using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;

namespace EnduriumMod.Projectiles
{
    public class EyeofTheStorm : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eye of The Storm");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }
        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.friendly = true;
            projectile.height = 24;
            projectile.width = 28;
            projectile.alpha = 0;
            projectile.penetrate = -1;
            projectile.timeLeft *= 5;
            Main.projFrames[projectile.type] = 6;
            projectile.tileCollide = false;
        }
        public override void AI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > 6)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 5)
            {
                projectile.frame = 0;
            }
            //Making player variable "p" set as the projectile's owner
            Player player = Main.player[projectile.owner];
            bool flag64 = projectile.type == mod.ProjectileType("EyeofTheStorm");
            MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(mod, "MyPlayer");

            if (player.dead)
            {
                modPlayer.EarthTurret = false;
            }
            if (modPlayer.EyeofTheStorm)
            {
                projectile.timeLeft = 2;
            }
            if (!modPlayer.EyeofTheStorm)
            {
                projectile.Kill();
            }
            float num24 = 0.6f;
            float num25 = 9999f;
            projectile.tileCollide = false;
            Vector2 vector4 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
            float num26 = Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) - vector4.X;
            float num27 = Main.player[projectile.owner].position.Y + Main.player[projectile.owner].gfxOffY + (float)(Main.player[projectile.owner].height / 2) - vector4.Y;
            if (Main.player[projectile.owner].direction == -1)
            {
                num26 -= 20f;
                projectile.direction = -1;
            }
            else if (Main.player[projectile.owner].direction == 1)
            {
                num26 += 20f;
                projectile.direction = 1;
            }
            num27 -= 30f;
            float num28 = (float)Math.Sqrt((double)(num26 * num26 + num27 * num27));
            projectile.position.X = projectile.position.X + num26;
            projectile.position.Y = projectile.position.Y + num27;

            int num9;
            projectile.spriteDirection = projectile.direction;
            int num3 = projectile.frameCounter;

            int[] array = new int[20];
            int num433 = 0;
            float num434 = 10000f;
            bool flag14 = false;
            for (int num435 = 0; num435 < 200; num435 = num3 + 1)
            {
                if (Main.npc[num435].CanBeChasedBy(projectile, false))
                {
                    float num436 = Main.npc[num435].position.X + (float)(Main.npc[num435].width / 2);
                    float num437 = Main.npc[num435].position.Y + (float)(Main.npc[num435].height / 2);
                    float num438 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num436) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num437);
                    if (num438 < num434 && Collision.CanHit(projectile.Center, 1, 1, Main.npc[num435].Center, 1, 1))
                    {
                        if (num433 < 20)
                        {
                            array[num433] = num435;
                            num3 = num433;
                            num433 = num3 + 1;
                        }
                        flag14 = true;
                    }
                }
                num3 = num435;
            }

            if (flag14)
            {
                int num439 = Main.rand.Next(num433);
                num439 = array[num439];
                float num440 = Main.npc[num439].position.X + (float)(Main.npc[num439].width / 2);
                float num441 = Main.npc[num439].position.Y + (float)(Main.npc[num439].height / 2);
                projectile.localAI[0] += 1f;
                if (projectile.localAI[0] == 125f)
                {
                    projectile.localAI[0] = 0f;
                }
                if (projectile.localAI[0] == 80f || projectile.localAI[0] == 90f || projectile.localAI[0] == 100f)
                {
                    Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 93); //zap sound
                    float num442 = 4f;
                    Vector2 vector32 = new Vector2(projectile.Center.X, projectile.Center.Y);
                    vector32 += projectile.velocity * 4f;
                    float num443 = num440 - vector32.X;
                    float num444 = num441 - vector32.Y;
                    float num445 = (float)Math.Sqrt((double)(num443 * num443 + num444 * num444));
                    num445 = num442 / num445;
                    num443 *= num445;
                    num444 *= num445;
                    int num666 = 100;
                    int num307 = mod.ProjectileType("ArcSoulBolt");
                    int data = Projectile.NewProjectile(vector32.X, vector32.Y, num443, num444, num307, num666, projectile.knockBack, projectile.owner, 0f, 0f);
                    Main.projectile[data].melee = false;
                    Main.projectile[data].netUpdate = true;
                    return;
                }

            }
        }
    }
}