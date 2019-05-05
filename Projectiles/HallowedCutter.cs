using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class HallowedCutter : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 9;
            projectile.height = 19;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = 10;
            projectile.aiStyle = 2;
            projectile.timeLeft = 1200;
            aiType = 48;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hallowed Cutter");
        }

        public override void AI()
        {
            projectile.ai[0] += 1f;
            projectile.rotation *= 1.005f;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {                                                           // sound that the projectile make when hiting the terrain
            projectile.Kill();
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 10);
            return false;
        }
    }
}