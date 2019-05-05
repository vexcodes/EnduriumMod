using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class CometPulsar : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.aiStyle = 1;
			projectile.alpha = 100;
            projectile.ranged = true;
            projectile.penetrate = 1;      //this is how many enemy this projectile penetrate before desapear 
            projectile.extraUpdates = 1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Comet Pulsar");
        }
        public override void AI()
        {
            int a = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 27, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 50f)       //how much time the projectile can travel before landing
            {
                projectile.velocity.Y = projectile.velocity.Y + 3.15f;    // projectile fall velocity
                projectile.velocity.X = projectile.velocity.X * 2f;    // projectile velocity
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {                                                           // sound that the projectile make when hiting the terrain
            {
                projectile.Kill();
                int a = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 27, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 10);
            }
            return false;
        }
    }
}
