using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System.IO;

namespace EnduriumMod.Projectiles
{
    public class TheDragun : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;
            projectile.CloneDefaults(ProjectileID.TheEyeOfCthulhu);
            projectile.width = 22;
            projectile.height = 22;
            projectile.aiStyle = 99;
            projectile.friendly = true;
            projectile.scale = 0.75f;
            projectile.penetrate = -1;
            projectile.melee = true;
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 20f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 310f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 20f;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Dragun");
        }

        public override void AI()
        {
            if (projectile.ai[0] == 0f)
            {
                projectile.ai[0] = projectile.velocity.X;
                projectile.ai[1] = projectile.velocity.Y;
            }
            int num3 = projectile.frameCounter;
            projectile.frameCounter = num3 + 1;
            if (projectile.frameCounter > 6)
            {
                projectile.frameCounter = 0;
                num3 = projectile.frame;
                projectile.frame = num3 + 1;
                if (projectile.frame > 4)
                {
                    projectile.frame = 0;
                }
            }
            int[] array = new int[20];
            int num433 = 0;
            float num434 = 400f;
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
                if (projectile.localAI[0] > 28f)
                {
                    projectile.penetrate--;
                    projectile.localAI[0] = 0f;
                    float num442 = 6f;
                    Vector2 vector32 = new Vector2(projectile.position.X + (float)projectile.width, projectile.position.Y + (float)projectile.height);
                    vector32 += projectile.velocity * 4f;
                    float num443 = num440 - vector32.X;
                    float num444 = num441 - vector32.Y;
                    float num445 = (float)Math.Sqrt((double)(num443 * num443 + num444 * num444));
                    num445 = num442 / num445;
                    num443 *= num445;
                    num444 *= num445;
                    int num1111 = Projectile.NewProjectile(vector32.X, vector32.Y, num443, num444, mod.ProjectileType("FireBlast"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
                    return;
                }

            }
        }

    }
}