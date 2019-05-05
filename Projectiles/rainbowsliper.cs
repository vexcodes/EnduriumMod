using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class rainbowsliper : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pure Rainbow");
        }
        public override void SetDefaults()
        {
            projectile.width = 4;
            projectile.height = 4;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 800;
            projectile.extraUpdates = 100;
            projectile.ignoreWater = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 1;
        }
        public override void AI()
        {
            int num3 = 0;
            for (int num452 = 0; num452 < 4; num452 = num3 + 1)
            {
                float x2 = projectile.position.X - projectile.velocity.X / 10f * (float)num452;
                float y2 = projectile.position.Y - projectile.velocity.Y / 10f * (float)num452;
                Vector2 vector36 = projectile.position;
                vector36 -= projectile.velocity * ((float)num452 * 0.25f);
                projectile.alpha = 255;
                int num453 = Dust.NewDust(new Vector2(x2, y2), 1, 1, 66, 0f, 0f, 0, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 0.8f);
                Main.dust[num453].position = vector36;
                Main.dust[num453].scale = (float)Main.rand.Next(70, 110) * 0.013f;
                Dust dust3 = Main.dust[num453];
                dust3.velocity *= 0f;
                dust3.noGravity = true;
                num3 = num452;
            }
            return;

        }
    }
}
			