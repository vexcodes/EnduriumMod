using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class BloomlightKunai : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.friendly = true;
            projectile.aiStyle = 1;
            projectile.thrown = true;
            projectile.penetrate = 2;      //this is how many enemy this projectile penetrate before desapear 
            projectile.extraUpdates = 1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloomlight Kunai");
        }


        public override void AI()
        {
            int num33 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 61, 0f, 0f, 125);
            Main.dust[num33].scale = 0.5f;
            Main.dust[num33].velocity *= 0.1f;
            if (Main.rand.Next(2) == 0)
            {
                Main.dust[num33].noGravity = true;
            }
            else
            {
                Main.dust[num33].noGravity = false;
            }

            projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 30f)       //how much time the projectile can travel before landing
            {
                projectile.rotation = projectile.rotation *= 1.04f;
                projectile.velocity.Y = projectile.velocity.Y + 3.15f;    // projectile fall velocity
                projectile.velocity.X = projectile.velocity.X * 0.9f;    // projectile velocity
            }
            else
            {
                projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {                                                           // sound that the projectile make when hiting the terrain

            projectile.Kill();
            int dustAmount = 10; // 4 or 5 shots
            for (int i = 0; i < dustAmount; i++)
            {
                int a = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 61, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 10);
            }
            return false;
        }
    }
}
