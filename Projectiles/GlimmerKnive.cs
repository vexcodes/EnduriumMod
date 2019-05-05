using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class GlimmerKnive : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 34;
            projectile.friendly = true;
            projectile.alpha = 0;
            projectile.timeLeft = 200;
            projectile.thrown = true;
            projectile.penetrate = 2;      //this is how many enemy this projectile penetrate before desapear 
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glimmer Knive");
        }


        public override void AI()
        {
            projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 20f)       //how much time the projectile can travel before landing
            {
                projectile.velocity.Y *= 0.95f;   // projectile fall velocity
                projectile.velocity.X *= 0.95f;    // projectile velocity
                projectile.rotation += 0.1f;
            }
            else
            {
                projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();// sound that the projectile make when hiting the terrain
            int a = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 156, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 10);
            return false;
        }
    }
}