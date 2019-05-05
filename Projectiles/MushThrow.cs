using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class MushThrow : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;

            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 99;
            projectile.friendly = true;
            projectile.penetrate = 20;
            projectile.melee = true;
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 18f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 280f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 13f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Devil's Glaze");
        }
        public override void AI()
        {

            for (int num723 = 0; num723 < 30; num723++)
            {
                int num724 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 15, 0f, 0f, 100, default(Color), 0.25f);
                Main.dust[num724].noGravity = true;
                Main.dust[num724].velocity *= 5f;
                num724 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 15, 0f, 0f, 100, default(Color), 0.25f);
                Main.dust[num724].velocity *= 2f;
            }
        }

    }
}
