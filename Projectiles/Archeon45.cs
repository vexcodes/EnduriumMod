using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class Archeon45 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Archeon-45");
        }
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.alpha = 255;
            projectile.penetrate = 1;
            projectile.timeLeft = 500;
            projectile.ranged = true;
        }
        public override void Kill(int timeLeft)
        {
            for (int num2 = 0; num2 < 15; num2++)
            {
                int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 235, 0f, 0f, 100, default(Color), 1.2f);
                Main.dust[num].velocity *= 3f;
                Main.dust[num].noGravity = true;
            }
        }
        float dustScale = 1f;
        float dustVelocity = 0f;
        float dustFadeIn = 1f;
        int dustType = 0;
        bool canhome = false;
        float homingBoost = 0.08f;
        public override void AI()
        {
            if (dustType == 0)
            {
                dustScale += Main.rand.NextFloat(0.15f, 0.45f);
                dustVelocity += Main.rand.NextFloat(0.05f, 0.15f);
                dustFadeIn += Main.rand.NextFloat(0.05f, 0.15f);
                homingBoost += Main.rand.NextFloat(0.05f, 0.15f);
                if (Main.rand.Next(3) == 0)
                {
                    canhome = true;
                }
                if (Main.rand.Next(4) == 0)
                {
                    dustType = 2;
                }
                else
                {
                    dustType = 1;
                }
            }
            if (canhome)
            {
                float num372 = projectile.position.X;
                float num373 = projectile.position.Y;
                float num374 = 100000f;
                bool flag10 = false;
                int num3;
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

                if (!flag10)
                {
                    num372 = projectile.position.X + (float)(projectile.width / 2) + projectile.velocity.X * 250f;
                    num373 = projectile.position.Y + (float)(projectile.height / 2) + projectile.velocity.Y * 250f;
                }
                float num379 = 11f;
                float num380 = 0.09f;
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
            }
            int num4;
            if (dustType == 1)
            {
                for (int num93 = 0; num93 < 1; num93 = num4 + 1)
                {
                    float num94 = projectile.velocity.X / 3f * (float)num93;
                    float num95 = projectile.velocity.Y / 3f * (float)num93;
                    int num96 = 4;
                    int num97 = Dust.NewDust(new Vector2(projectile.position.X + (float)num96, projectile.position.Y + (float)num96), projectile.width - num96 * 2, projectile.height - num96 * 2, 235, 0f, 0f, 100, default(Color), dustScale);
                    Main.dust[num97].noGravity = true;
                    Main.dust[num97].fadeIn *= dustFadeIn;
                    Dust dust3 = Main.dust[num97];
                    dust3.velocity *= dustVelocity;
                    dust3 = Main.dust[num97];
                    dust3.velocity += projectile.velocity * dustVelocity;
                    Dust dust6 = Main.dust[num97];
                    dust6.position.X = dust6.position.X - num94;
                    Dust dust7 = Main.dust[num97];
                    dust7.position.Y = dust7.position.Y - num95;
                    num4 = num93;
                }
            }
            else if (dustType == 2)
            {
                int drust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 235, 0f, 0f, 100, default(Color), dustScale);
                Main.dust[drust].velocity *= dustVelocity;
                Main.dust[drust].fadeIn *= dustFadeIn;
                Main.dust[drust].noGravity = true;
            }
        }
    }
}