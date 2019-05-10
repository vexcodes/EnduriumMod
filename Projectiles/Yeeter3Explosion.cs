using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class Yeeter3Explosion : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.friendly = true;
            projectile.timeLeft = 250;
            projectile.aiStyle = 1;
            projectile.tileCollide = false;
            projectile.extraUpdates = 100;
            projectile.thrown = true;
            projectile.penetrate = 1;      //this is how many enemy this projectile penetrate before desapear 
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Prophecy");
        }
        int num1 = 0;
        int num2 = 0;
        public override void AI()
        {
            if (num2 == 0)
            {
                num2 = 1;
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 93); //zap sound
            }
            float num372 = projectile.position.X;
            float num373 = projectile.position.Y;
            float num374 = 2000f;
            bool flag10 = false;
            float num376 = Main.npc[(int)projectile.ai[1]].position.X + (float)(Main.npc[(int)projectile.ai[1]].width / 2);
            float num377 = Main.npc[(int)projectile.ai[1]].position.Y + (float)(Main.npc[(int)projectile.ai[1]].height / 2);
            float num378 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num376) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num377);
            if (num378 < 800f && num378 < num374 && Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[(int)projectile.ai[1]].position, Main.npc[(int)projectile.ai[1]].width, Main.npc[(int)projectile.ai[1]].height))
            {
                num374 = num378;
                num372 = num376;
                num373 = num377;
                flag10 = true;
            }

            if (!flag10)
            {
                num372 = projectile.position.X + (float)(projectile.width / 2) + projectile.velocity.X * 100f;
                num373 = projectile.position.Y + (float)(projectile.height / 2) + projectile.velocity.Y * 100f;
            }


            float num379 = 9f;
            float num380 = 0.4f;
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

            if (num1 < 6)
            {
                projectile.velocity = Vector2.Normalize(Main.npc[(int)projectile.ai[1]].Center - projectile.Center) * 8;
            }
            if (num1 == 8)
            {
                Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedByRandom(MathHelper.ToRadians(85));
                float scale = 1f - (Main.rand.NextFloat() * .5f);
                perturbedSpeed = perturbedSpeed * scale;
                projectile.velocity.Y = perturbedSpeed.Y;
                projectile.velocity.X = perturbedSpeed.X;
            }
            num1 += 1;
            if (num1 == 12)
            {
                num1 = 0;
            }

            int num4;
            for (int num93 = 0; num93 < 1; num93 = num4 + 1)
            {
                float num94 = projectile.velocity.X / 3f * (float)num93;
                float num95 = projectile.velocity.Y / 3f * (float)num93;
                int num96 = 4;
                int num97 = Dust.NewDust(new Vector2(projectile.position.X + (float)num96, projectile.position.Y + (float)num96), projectile.width - num96 * 2, projectile.height - num96 * 2, 267, projectile.oldVelocity.X, projectile.oldVelocity.Y, 0, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 0.9f);
                Main.dust[num97].noGravity = true;
                Dust dust3 = Main.dust[num97];
                dust3.velocity *= 0.2f;
                dust3 = Main.dust[num97];
                dust3.velocity += projectile.velocity * 0.2f;
                Dust dust6 = Main.dust[num97];
                dust6.position.X = dust6.position.X - num94;
                Dust dust7 = Main.dust[num97];
                dust7.position.Y = dust7.position.Y - num95;
                num4 = num93;
            }
        }
    }
}