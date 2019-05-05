using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class SandWave : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sand Wave ");
        }
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 34;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft /= 2;
            projectile.melee = true;
        }
        public override void AI()
        {

            projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;
            if (projectile.alpha <= 0)
            {
                int num;
                for (int num108 = 0; num108 < 3; num108 = num + 1)
                {
                    int num109 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 133, 0f, 0f, 0, default(Color), 0.8f);
                    Main.dust[num109].noGravity = true;
                    Dust dust3 = Main.dust[num109];
                    dust3.velocity *= 0f;
                    Main.dust[num109].noLight = true;
                    num = num108;
                }
            }
            if (projectile.alpha > 0)
            {
                projectile.alpha -= 55;
                projectile.scale = 1.3f;
                if (projectile.alpha < 0)
                {
                    projectile.alpha = 0;
                    float num110 = 16f;
                    int num111 = 0;
                    while ((float)num111 < num110)
                    {
                        Vector2 vector14 = Vector2.UnitX * 0f;
                        vector14 += -Vector2.UnitY.RotatedBy((double)((float)num111 * (6.28318548f / num110)), default(Vector2)) * new Vector2(1f, 4f);
                        vector14 = vector14.RotatedBy((double)projectile.velocity.ToRotation(), default(Vector2));
                        int num112 = Dust.NewDust(projectile.Center, 0, 0, 269, 0f, 0f, 0, default(Color), 1f);
                        Main.dust[num112].scale = 1.5f;
                        Main.dust[num112].noLight = true;
                        Main.dust[num112].noGravity = true;
                        Main.dust[num112].position = projectile.Center + vector14;
                        Main.dust[num112].velocity = Main.dust[num112].velocity * 4f + projectile.velocity * 0.3f;
                        int num = num111;
                        num111 = num + 1;
                    }
                }
            }
            if (projectile.alpha > 0)
            {
                projectile.alpha -= 50;
            }
            else
            {
                projectile.extraUpdates = 0;
            }
            if (projectile.alpha < 0)
            {
                projectile.alpha = 0;
            }
            float num372 = projectile.position.X;
            float num373 = projectile.position.Y;
            float num374 = 100000f;
            bool flag10 = false;
            projectile.ai[0] += 1f;
            if (projectile.ai[0] > 30f)
            {
                projectile.ai[0] = 30f;
                int num3;
                for (int num375 = 0; num375 < 200; num375 = num3 + 1)
                {
                    if (Main.npc[num375].CanBeChasedBy(projectile, false) && (!Main.npc[num375].wet))
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

            projectile.friendly = true;

            float num379 = 12f;
            float num380 = 0.2f;
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
            else if (projectile.velocity.X > num381)
            {
                projectile.velocity.X = projectile.velocity.X - num380;
                if (projectile.velocity.X > 0f && num381 < 0f)
                {
                    projectile.velocity.X = projectile.velocity.X - num380 * 2f;
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
            else if (projectile.velocity.Y > num382)
            {
                projectile.velocity.Y = projectile.velocity.Y - num380;
                if (projectile.velocity.Y > 0f && num382 < 0f)
                {
                    projectile.velocity.Y = projectile.velocity.Y - num380 * 2f;
                    return;
                }

            }
            projectile.ai[1]++;
            if (projectile.ai[1] >= 70)
            {
                projectile.Kill();
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                int num137 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 269, projectile.oldVelocity.X * 0.05f, projectile.oldVelocity.Y * 0.05f);
                Main.dust[num137].noGravity = true;
            }
            for (int k = 0; k < 5; k++)
            {
                int num138 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 133, projectile.oldVelocity.X * 0.05f, projectile.oldVelocity.Y * 0.05f);
                Main.dust[num138].noGravity = true;
            }
            for (int k = 0; k < 5; k++)
            {
                int num139 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 38, projectile.oldVelocity.X * 0.05f, projectile.oldVelocity.Y * 0.05f);
                Main.dust[num139].noGravity = true;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            projectile.Kill();
            return false;
        }
    }
}