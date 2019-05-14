using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class HeavenRupture : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 1200;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heaven Rupture");
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            int num3;
            projectile.ai[0] += 1f;
            projectile.localAI[0] -= 1f;
            if (projectile.ai[0] == 1f)
            {
                Main.PlaySound(SoundID.Item9, projectile.Center);
            }
            if (projectile.localAI[0] <= 0f)
            {
                projectile.localAI[0] = 12f;
                int num;
                for (int l = 0; l < 12; l = num + 1)
                {
                    Vector2 vector3 = Vector2.UnitX * -(float)projectile.width / 2f;
                    vector3 += -Vector2.UnitY.RotatedBy((double)((float)l * 3.14159274f / 6f), default(Vector2)) * new Vector2(8f, 16f);
                    vector3 = vector3.RotatedBy((double)(projectile.rotation - 1.57079637f), default(Vector2));
                    int num9 = Dust.NewDust(projectile.Center, 0, 0, 156, 0f, 0f, 160, default(Color), 1f);
                    Main.dust[num9].scale = 1.1f;
                    Main.dust[num9].noGravity = true;
                    Main.dust[num9].position = projectile.Center + vector3;
                    Main.dust[num9].velocity = projectile.velocity * 1.5f;
                    Main.dust[num9].velocity = Vector2.Normalize(projectile.Center - projectile.velocity * 3f - Main.dust[num9].position) * 1.25f;
                    num = l;
                }
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {                                                           // sound that the projectile make when hiting the terrain

            projectile.Kill();
            int a = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 156, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 10);

            return false;
        }
    }
}