using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class DesertPierce : ModProjectile
    {
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 6;
            target.AddBuff(69, 20);
            for (int num2 = 0; num2 < 8; num2++)
            {
                int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 133, 0f, 0f, 175, default(Color), 1.2f);
                Main.dust[num].velocity *= 3f;
                Main.dust[num].noGravity = true;
            }
        }
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 24;
            projectile.aiStyle = 1;
            aiType = ProjectileID.Bullet;
            projectile.friendly = true;
            projectile.tileCollide = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.penetrate = 4;
            projectile.alpha = 75;
            projectile.timeLeft = 200;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Desert Pierce");
        }
        public override void AI()
        {
            if (projectile.alpha <= 200)
            {
                int num3;
                for (int num20 = 0; num20 < 2; num20 = num3 + 1)
                {
                    float num21 = projectile.velocity.X / 4f * (float)num20;
                    float num22 = projectile.velocity.Y / 4f * (float)num20;
                    int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 269, 0f, 0f, 0, default(Color), 1.6f);
                    Main.dust[num23].position.X = projectile.Center.X - num21;
                    Main.dust[num23].position.Y = projectile.Center.Y - num22;
                    Dust dust3 = Main.dust[num23];
                    dust3.velocity *= 0f;
                    dust3.noGravity = true;
                    Main.dust[num23].scale = 0.8f;
                    num3 = num20;
                }
            }
            projectile.alpha -= 50;
            if (projectile.alpha < 0)
            {
                projectile.alpha = 0;
            }

        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            for (int num2 = 0; num2 < 8; num2++)
            {
                int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 133, 0f, 0f, 175, default(Color), 1.2f);
                Main.dust[num].velocity *= 3f;
                Main.dust[num].noGravity = true;
            }
            return true;
        }
    }
}
