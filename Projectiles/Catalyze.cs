using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class Catalyze : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Catalyze");
        }

        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 22;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = 6;
            projectile.alpha = 120;
            projectile.timeLeft = 400;
            projectile.extraUpdates = 1;
        }
        int numgay = 0;
        public override void AI()
        {
            float num372 = projectile.position.X;
            float num373 = projectile.position.Y;
            float num374 = 100000f;
            bool flag10 = false;
            if (projectile.velocity.X != projectile.velocity.X)
            {
                projectile.velocity.X = projectile.velocity.X * -0.1f;
            }
            int num3;
            numgay += 1;
            if (numgay >= 35)
            {
                projectile.penetrate = 1;
                for (int num375 = 0; num375 < 200; num375 = num3 + 1)
                {
                    if (Main.npc[num375].CanBeChasedBy(projectile, false))
                    {
                        float num376 = Main.npc[num375].position.X + (float)(Main.npc[num375].width / 2);
                        float num377 = Main.npc[num375].position.Y + (float)(Main.npc[num375].height / 2);
                        float num378 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num376) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num377);
                        if (num378 < 800f && num378 < num374 && Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[num375].position, Main.npc[num375].width, Main.npc[num375].height))
                        {
                            num374 = num378;
                            num372 = num376;
                            num373 = num377;
                            flag10 = true;
                        }
                    }
                    num3 = num375;
                }
            }

            if (!flag10)
            {
                num372 = projectile.position.X + (float)(projectile.width / 2) + projectile.velocity.X * 100f;
                num373 = projectile.position.Y + (float)(projectile.height / 2) + projectile.velocity.Y * 100f;
            }
            float num379 = 7f;
            float num380 = 0.12f;
            Vector2 vector29 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
            float num381 = num372 - vector29.X;
            float num382 = num373 - vector29.Y;
            float num383 = (float)Math.Sqrt((double)(num381 * num381 + num382 * num382));
            num383 = num379 / num383;
            num381 *= num383;
            num382 *= num383;
            if (projectile.velocity.X < num381)
            {
                projectile.velocity.X = projectile.velocity.X + num380;
                if (projectile.velocity.X < 0f && num381 > 0f)
                {
                    projectile.velocity.X = projectile.velocity.X + num380 * 2f;
                }
            }
            else
            {
                if (projectile.velocity.X > num381)
                {
                    projectile.velocity.X = projectile.velocity.X - num380;
                    if (projectile.velocity.X > 0f && num381 < 0f)
                    {
                        projectile.velocity.X = projectile.velocity.X - num380 * 2f;
                    }
                }
            }
            if (projectile.velocity.Y < num382)
            {
                projectile.velocity.Y = projectile.velocity.Y + num380;
                if (projectile.velocity.Y < 0f && num382 > 0f)
                {
                    projectile.velocity.Y = projectile.velocity.Y + num380 * 2f;
                    return;
                }
            }
            else
            {
                if (projectile.velocity.Y > num382)
                {
                    projectile.velocity.Y = projectile.velocity.Y - num380;
                    if (projectile.velocity.Y > 0f && num382 < 0f)
                    {
                        projectile.velocity.Y = projectile.velocity.Y - num380 * 2f;
                        return;
                    }
                }
            }
            if (projectile.wet)
            {
                projectile.Kill();
            }
            int num200 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 173, 0f, 0f, 100, default(Color), 1f);
            Dust dust37 = Main.dust[num200];
            dust37.position.X = dust37.position.X - 2f;
            Dust dust38 = Main.dust[num200];
            dust38.position.Y = dust38.position.Y + 2f;
            Dust dust3 = Main.dust[num200];
            dust3.scale += (float)Main.rand.Next(50) * 0.01f;
            Main.dust[num200].noGravity = true;
            Dust dust39 = Main.dust[num200];
            dust39.velocity.Y = dust39.velocity.Y - 2f;
            if ((double)projectile.velocity.Y < 0.25 && (double)projectile.velocity.Y > 0.15)
            {
                projectile.velocity.X = projectile.velocity.X * 0.8f;
            }
        }
    }
}