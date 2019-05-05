using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class VitalBlast : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vital Blast");
        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.penetrate = 4;
            projectile.timeLeft = 300;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //If collide with tile, reduce the penetrate.
            //So the projectile can reflect at most 5 times
            projectile.penetrate--;
            if (projectile.penetrate <= 0)
            {
                projectile.Kill();
            }
            else
            {
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
            }
            return false;
        }
        float num1 = 0f;
        float num2 = 0f;
        float num300 = 0f;
        public override void AI()
        {
            float num25 = num2 *= 0.5f;
            if (projectile.ai[1] == 1f)
            {
                num1 += 0.02f;
                num2 += 0.06f;
                if (Main.rand.Next(2) == 0)
                {
                    num1 += 0.01f;
                }
                if (Main.rand.Next(4) == 0)
                {
                    num1 += 0.01f;
                }
                if (Main.rand.Next(5) == 0)
                {
                    num2 += 0.02f;
                }
                if (Main.rand.Next(7) == 0)
                {
                    num2 += 0.03f;
                }
                if (num1 >= 0.5f || num2 >= 0.6f)
                {
                    if (Main.rand.Next(8) == 0)
                    {
                        projectile.ai[1] = 2f;
                    }
                }
            }
            if (projectile.ai[1] == 2f)
            {
                num1 -= 0.01f;
                num2 -= 0.04f;
                if (Main.rand.Next(2) == 0)
                {
                    num1 -= 0.01f;
                }
                if (Main.rand.Next(3) == 0)
                {
                    num1 -= 0.01f;
                }
                if (Main.rand.Next(6) == 0)
                {
                    num2 -= 0.02f;
                }
                if (Main.rand.Next(7) == 0)
                {
                    num2 -= 0.03f;
                }
                if (num1 <= -0.1f || num2 <= -0.25f)
                {
                    if (Main.rand.Next(8) == 0)
                    {
                        projectile.ai[1] = 1f;
                    }
                }
            }
            if (projectile.ai[0] == 9f)
            {
                projectile.ai[1] = 1f;
            }
            if (projectile.ai[0] > 7f)
            {
                projectile.ai[0] += 1f;
                for (int num22 = 0; num22 < 2; num22++)
                {
                    int num299 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 235, projectile.velocity.X * num1, projectile.velocity.Y * num1, 120, default(Color), 0.85f);
                    if (Main.rand.Next(2) == 0)
                    {
                        int num345 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 235, projectile.velocity.X * num25, projectile.velocity.Y * num25, 60, default(Color), 1f);
                        Main.dust[num345].noGravity = true;
                        if (Main.rand.Next(2) == 0)
                        {
                            Main.dust[num345].velocity += projectile.velocity;
                        }
                    }
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[num299].velocity += projectile.velocity;
                    }

                    Main.dust[299].noGravity = true;
                    
                }

            }
            else
            {
                projectile.ai[0] += 1f;
            }
            projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;
            return;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 8;
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1, 1f, 0f);
            Vector2 vector19 = projectile.position;
            Vector2 oldVelocity = projectile.oldVelocity;
            oldVelocity.Normalize();
            vector19 += oldVelocity * 16f;
            int num3;
            for (int num355 = 0; num355 < 12; num355 = num3 + 1)
            {
                int num356 = Dust.NewDust(vector19, projectile.width, projectile.height, 235, 0f, 0f, 60, default(Color), 1f);
                Main.dust[num356].position = (Main.dust[num356].position + projectile.Center) / 2f;
                Dust dust = Main.dust[num356];
                dust.velocity += projectile.oldVelocity * 1.4f;
                dust = Main.dust[num356];
                dust.velocity *= 2.5f;
                Main.dust[num356].noGravity = true;
                vector19 -= oldVelocity * 8f;
                num3 = num355;
            }
        }
    }
}