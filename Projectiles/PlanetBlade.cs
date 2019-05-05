using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class PlanetBlade : ModProjectile
    {
    	
        public override void SetDefaults()
        {
            projectile.width = 38;
            projectile.height = 38;
            projectile.aiStyle = 27;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = 1;
			projectile.alpha = 150;
            projectile.timeLeft = 600;
        }
		    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Planet Storm");
    }
        public override void AI()
        {
		Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.3f) / 255f, ((255 - projectile.alpha) * 0.3f) / 255f, ((255 - projectile.alpha) * 0f) / 255f);
            if (Main.rand.Next(4) == 0)
            {
            	Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 156, projectile.velocity.X * 0f, projectile.velocity.Y * 0f);
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
            	Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 66, projectile.oldVelocity.X * 0f, projectile.oldVelocity.Y * 0f);
            }
        }
    }
}