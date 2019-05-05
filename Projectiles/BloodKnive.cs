using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class BloodKnive : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 34;
            projectile.friendly = true;
            projectile.aiStyle = 1;
            projectile.thrown = true;
            projectile.penetrate = 2;      //this is how many enemy this projectile penetrate before desapear 
            projectile.extraUpdates = 1;
            aiType = ProjectileID.ThrowingKnife;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Clot Knive");
        }
        public override void AI()
        {

            projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 50f)       //how much time the projectile can travel before landing
            {
                projectile.velocity.Y = projectile.velocity.Y + 3.15f;    // projectile fall velocity
                projectile.velocity.X = projectile.velocity.X * 2f;    // projectile velocity
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {                                                           // sound that the projectile make when hiting the terrain

            projectile.Kill();
         
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 10);

            return false;
        }
    }
}
