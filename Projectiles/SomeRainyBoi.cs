using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class SomeRainyBoi : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 2;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.extraUpdates = 1;
            projectile.penetrate = 1;
            projectile.ignoreWater = true;
            projectile.timeLeft = 24;
            projectile.alpha = 255;
        }
        public override void AI()
        {
            projectile.velocity.Y += 0.2f;
            int num3;
            for (int num20 = 0; num20 < 2; num20 = num3 + 1)
            {
                float num21 = projectile.velocity.X / 4f * (float)num20;
                float num22 = projectile.velocity.Y / 4f * (float)num20;
                int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 33, 0f, 0f, 0, default(Color), 1.6f);
                Main.dust[num23].position.X = projectile.Center.X - num21;
                Main.dust[num23].position.Y = projectile.Center.Y - num22;
                Dust dust3 = Main.dust[num23];
                dust3.velocity *= 0f;
                dust3.noGravity = true;
                Main.dust[num23].scale = 1.1f;
                num3 = num20;
            }
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Some Rainy Boi");
        }
    }
}