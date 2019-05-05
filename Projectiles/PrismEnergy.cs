using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class PrismEnergy : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prismatic Energy");
        }
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.friendly = true;
            projectile.alpha = 255;
            projectile.penetrate = -1;
			            projectile.light = 0.25f;
            projectile.timeLeft = 80;
            projectile.thrown = true;
        }

        public override void AI()
        {
            projectile.velocity.X *= 0.935f;
            projectile.velocity.Y *= 0.935f;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 135, projectile.velocity.X * 1f, projectile.velocity.Y * 1f);
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 112, projectile.velocity.X * 1f, projectile.velocity.Y * 1f);
        }
    }
}