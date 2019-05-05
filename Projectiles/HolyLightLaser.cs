using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class HolyLightLaser : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Queso Laser");
        }
        public override void SetDefaults()
        {
            projectile.width = 4;
            projectile.height = 4;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 10;
            projectile.timeLeft = 200;
            projectile.alpha = 225;
            projectile.light = 0.0f;
            projectile.extraUpdates = 100;
            projectile.ignoreWater = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 1;
        }
        public override void AI()
        {
            projectile.ai[0]++;
            if (projectile.ai[0] >= 2)
            {
                int num;
                for (int num1 = 0; num1 < 10; num1 = num + 1)
                {
                    float x2 = projectile.position.X - projectile.velocity.X / 10f * (float)num1;
                    float y2 = projectile.position.Y - projectile.velocity.Y / 10f * (float)num1;
                    int num2 = Dust.NewDust(new Vector2(x2, y2), 1, 1, 114, 0f, 0f, 0, default(Color), 0.5f);
                    Main.dust[num2].alpha = projectile.alpha;
                    Main.dust[num2].position.X = x2;
                    Main.dust[num2].position.Y = y2;
                    Dust dust3 = Main.dust[num2];
                    dust3.velocity *= 0f;
                    Main.dust[num2].noGravity = true;
                    num = num1;
                }
            }
        }
    }
}
				