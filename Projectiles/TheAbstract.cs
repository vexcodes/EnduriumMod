using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class TheAbstract : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 40;
            projectile.light = 0.25f;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.penetrate = 1;
            projectile.alpha = 255;
            projectile.timeLeft = 345;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Abstract");
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }

        public override void Kill(int timeLeft)
        {
            int num3;
            for (int num20 = 0; num20 < 10; num20 = num3 + 1)
            {
                float num21 = projectile.velocity.X / 4f * (float)num20;
                float num22 = projectile.velocity.Y / 4f * (float)num20;
                int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 173, 0f, 0f, 0, default(Color), 1.3f);
                Main.dust[num23].position.X = projectile.Center.X - num21;
                Main.dust[num23].position.Y = projectile.Center.Y - num22;
                Dust dust3 = Main.dust[num23];
                dust3.velocity *= 0.6f;
                Main.dust[num23].scale = 0.6f;
                Main.dust[num23].noLight = true;
                Main.dust[num23].fadeIn = 0.4f;
                num3 = num20;
            }
            for (int num20 = 0; num20 < 5; num20 = num3 + 1)
            {
                float num21 = projectile.velocity.X / 4f * (float)num20;
                float num22 = projectile.velocity.Y / 4f * (float)num20;
                int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 173, 0f, 0f, 0, default(Color), 1.3f);
                Main.dust[num23].position.X = projectile.Center.X - num21;
                Main.dust[num23].position.Y = projectile.Center.Y - num22;
                Dust dust3 = Main.dust[num23];
                dust3.velocity *= 0.66f;
                Main.dust[num23].scale = 0.76f;
                Main.dust[num23].noLight = true;
                Main.dust[num23].fadeIn = 0.4f;
                num3 = num20;
            }
        }
        public override void AI()
        {
            if (projectile.alpha >= 45)
            {
                projectile.alpha -= 10;
            }
            projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;
            if (projectile.timeLeft == 335)
            {
                int num3;
                for (int num20 = 0; num20 < 10; num20 = num3 + 1)
                {
                    float num21 = projectile.velocity.X / 4f * (float)num20;
                    float num22 = projectile.velocity.Y / 4f * (float)num20;
                    int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 173, 0f, 0f, 0, default(Color), 1.3f);
                    Main.dust[num23].position.X = projectile.Center.X - num21;
                    Main.dust[num23].position.Y = projectile.Center.Y - num22;
                    Dust dust3 = Main.dust[num23];
                    dust3.velocity *= 0.6f;
                    Main.dust[num23].scale = 0.6f;
                    Main.dust[num23].noLight = true;
                    Main.dust[num23].fadeIn = 0.4f;
                    num3 = num20;
                }
                Player player = Main.player[Main.myPlayer];
                Vector2 value11 = Main.screenPosition + new Vector2((float)projectile.ai[0], (float)projectile.ai[1]);
                projectile.velocity = Vector2.Normalize(value11 - projectile.Center) * 18;
            }
        }
    }
}