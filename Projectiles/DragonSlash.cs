using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class DragonSlash : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 30;
            projectile.aiStyle = 27;
            projectile.friendly = true;
            projectile.tileCollide = false;
			projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            projectile.alpha = 175;
            projectile.timeLeft = 800;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon Slash");
        }

        public override void AI()
        {
             projectile.velocity.Y += projectile.ai[0];
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }
    }
}
