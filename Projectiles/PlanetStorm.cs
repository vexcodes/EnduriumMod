using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class PlanetStorm : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Planet Bolt");
        }
        public override void SetDefaults()
        {
            projectile.width = 4;
            projectile.height = 4;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 200;
            projectile.alpha = 225;
            projectile.light = 0.0f;
            projectile.extraUpdates = 100;
            projectile.ignoreWater = true;
        }
        public override void AI()
        {
            int num3 = 0;
            for (int num136 = 0; num136 < 3; num136++)
            {
                float x2 = projectile.position.X - projectile.velocity.X / 10f * (float)num136;
                float y2 = projectile.position.Y - projectile.velocity.Y / 10f * (float)num136;
                int num137 = Dust.NewDust(new Vector2(x2, y2), 16, 255, 56, 0f, 0f, 0, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 0.82f);
                Main.dust[num137].alpha = projectile.alpha;
                Main.dust[num137].position.X = x2;
                Main.dust[num137].position.Y = y2;
                Main.dust[num137].velocity *= 1f;
                Main.dust[num137].noGravity = true;
            }
            return;

        }

    }
}
				