using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class MarbleDagger : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = 1;
            projectile.aiStyle = -1;
            projectile.timeLeft = 50;
            projectile.alpha = 255;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rosy Gold Dagger");
        }

        public override void AI()
        {
            if (projectile.ai[0] <= 0.5f)
            {
                projectile.ai[0] = 1f;
            }
            projectile.ai[0] += 0.025f;
            projectile.ai[1] += 0.15f;
            projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;

            int a = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.dust[a].noGravity = true;
            Main.dust[a].velocity *= 0f;
            Main.dust[a].scale *= 1.2f;
            projectile.damage *= (int)projectile.ai[0];
            if (projectile.ai[1] >= 1.8f)
            {
                projectile.netUpdate = true;
                int num3;
                for (int num731 = 0; num731 < 8; num731 = num3 + 1)
                {
                    int num732 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.2f);
                    Main.dust[num732].noGravity = true;
                    Dust dust = Main.dust[num732];
                    dust.velocity *= 0.65f;
                    num3 = num731;
                }
                projectile.Kill();
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