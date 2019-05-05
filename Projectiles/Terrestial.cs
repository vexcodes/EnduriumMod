using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class Terrestial : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terrestial Energy");
        }
        public override void SetDefaults()
        {
            projectile.width = 2;
            projectile.height = 2;
            projectile.friendly = true;
            projectile.alpha = 255;
            projectile.penetrate = 1;
            projectile.timeLeft = 680;
            projectile.ranged = true;
            projectile.aiStyle = 1;
            aiType = 1;
        }

        public override void AI()
        {
            projectile.velocity.X *= 1.03f;
            projectile.velocity.Y *= 1.03f;
            int num3;
            for (int num20 = 0; num20 < 12; num20 = num3 + 1)
            {
                float num21 = projectile.velocity.X / 4f * (float)num20;
                float num22 = projectile.velocity.Y / 4f * (float)num20;
                int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 74, 0f, 0f, 0, default(Color), 1.6f);
                Main.dust[num23].position.X = projectile.Center.X - num21;
                Main.dust[num23].position.Y = projectile.Center.Y - num22;
                Dust dust3 = Main.dust[num23];
                dust3.velocity *= 0f;
                Main.dust[num23].scale = 0.5f;
                num3 = num20;
            }
        }
    }
}