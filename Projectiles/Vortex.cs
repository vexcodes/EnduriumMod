using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class Vortex : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;

            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 99;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.melee = true;
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 18f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 300f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 18f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vortex");
        }
        public override void AI()
        {
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
            if (Math.Sqrt((double)(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y)) > 2.0)
            {
                projectile.velocity *= 0.98f;
            }
            for (int num432 = 0; num432 < 1000; num432 = num3 + 1)
            {
                if (num432 != projectile.whoAmI && Main.projectile[num432].active && Main.projectile[num432].owner == projectile.owner && Main.projectile[num432].type == projectile.type && projectile.timeLeft > Main.projectile[num432].timeLeft && Main.projectile[num432].timeLeft > 30)
                {
                    Main.projectile[num432].timeLeft = 30;
                }
                num3 = num432;
            }
            int[] array = new int[20];
            int num433 = 0;
            float num434 = 300f;
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
            if (projectile.timeLeft < 30)
            {
                flag14 = false;
            }

            int num439 = Main.rand.Next(num433);
            num439 = array[num439];
            float num440 = Main.npc[num439].position.X + (float)(Main.npc[num439].width / 2);
            float num441 = Main.npc[num439].position.Y + (float)(Main.npc[num439].height / 2);
            projectile.localAI[0] += 1f;
            if (projectile.localAI[0] > 16f)
            {
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
                Projectile.NewProjectile(vector32.X, vector32.Y, num443, num444, mod.ProjectileType("VortexBeam"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
            }
            return;
        }

    }
}