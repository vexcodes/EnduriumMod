using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class NatureKnive : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 34;
            projectile.friendly = true;
            projectile.aiStyle = 1;
            projectile.thrown = true;
            projectile.penetrate = 1;      //this is how many enemy this projectile penetrate before desapear 
            projectile.extraUpdates = 1;
            aiType = ProjectileID.ThrowingKnife;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tropical Dagger");
        }
        public override void AI()
        {
            int a = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 3, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.dust[a].scale = 0.5f;
            Main.dust[a].position = projectile.Center;
            Main.dust[a].velocity *= 0f;
            projectile.ai[0] += 1f;
            projectile.rotation *= 1.005f;
            if (projectile.ai[0] >= 20f)       //how much time the projectile can travel before landing
            {  // projectile fall velocity
                projectile.velocity.Y = projectile.velocity.X / 6f;    // projectile velocity
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {                                                           // sound that the projectile make when hiting the terrain
            projectile.Kill();
            int a = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 3, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 10);
            return false;
        }
    }
}