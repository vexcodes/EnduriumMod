using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class HellstormBolt : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 72;
            projectile.friendly = true;
            projectile.aiStyle = 1;
            aiType = ProjectileID.Bullet;
            projectile.tileCollide = false;
            projectile.ranged = true;
            projectile.penetrate = 10;      //this is how many enemy this projectile penetrate before desapear 
            projectile.extraUpdates = 3;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellstorm Fury");
        }
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 0.785f;
            if (projectile.alpha <= 200)
            {
                int num3;
                for (int num20 = 0; num20 < 4; num20 = num3 + 1)
                {
                    float num21 = projectile.velocity.X / 4f * (float)num20;
                    float num22 = projectile.velocity.Y / 4f * (float)num20;
                    int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, 0f, 0f, 0, default(Color), 1.3f);
                    Main.dust[num23].position.X = projectile.Center.X - num21;
                    Main.dust[num23].position.Y = projectile.Center.Y - num22;
                    Dust dust3 = Main.dust[num23];
                    dust3.velocity *= 0f;
                    Main.dust[num23].scale = 0.7f;
                    num3 = num20;
                }
            }
            projectile.alpha -= 50;
            if (projectile.alpha < 0)
            {
                projectile.alpha = 0;
            }
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 0.785f;

        }
    }
}