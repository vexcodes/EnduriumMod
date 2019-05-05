using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class DragonBeam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fiery Flux");
        }
        public override void SetDefaults()
        {
            projectile.width = 4;
            projectile.height = 4;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 200;
            projectile.ignoreWater = true;
        }
        float num1150 = 1f;
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //If collide with tile, reduce the penetrate.
            //So the projectile can reflect at most 5 times
            projectile.velocity.Y += 5f;
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
                Main.PlaySound(SoundID.Item10, projectile.position);
            }
            return false;
        }
        public override void AI()
        {
            projectile.ai[0] += 1;
            if (projectile.ai[0] == 15)
            {
                num1150 = 1.3f;
                projectile.damage = (int)(projectile.damage * 1.1f);
            }
            if (projectile.ai[0] == 30)
            {
                num1150 = 1.6f;
                projectile.damage = (int)(projectile.damage * 1.3f);
            }
            if (projectile.ai[0] == 60)
            {
                num1150 = 2f;
                projectile.damage = (int)(projectile.damage * 1.6f);
            }
            if (projectile.ai[0] == 100)
            {
                num1150 = 2.6f;
                projectile.damage = (int)(projectile.damage * 2f);
            }
            for (float num1152 = 0f; num1152 < 3f; num1152 += 1f)
            {
                if (Main.rand.Next(3) == 0)
                {
                    Dust dust141 = Main.dust[Dust.NewDust(projectile.Center, 0, 0, 127, 0f, -2f, 0, default(Color), 1f)];
                    dust141.position = projectile.Center + Vector2.UnitY.RotatedBy((double)(num1152 * 6.28318548f / 3f + projectile.ai[1]), default(Vector2)) * 10f;
                    dust141.noGravity = true;
                    dust141.velocity = projectile.DirectionFrom(dust141.position);
                    dust141.scale = num1150;
                    dust141.fadeIn = 0.5f;
                }
            }


            return;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("ImperialInferno"), 360);
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 60);
            if (projectile.ai[0] >= 15)
            {
                for (int num2 = 0; num2 < 15; num2++)
                {
                    int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 127, 0f, 0f, 100, default(Color), 1.2f);
                    Main.dust[num].velocity *= 3f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[num].scale = num1150;
                        Main.dust[num].fadeIn = 1f;
                    }
                }
            }
        }
    }
}

			