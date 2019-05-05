using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
	public class HolyLight : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Light");
        }
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.alpha = 255;
            projectile.penetrate = 10;
            projectile.timeLeft /= 2;
            projectile.magic = true;
        }

        public override void AI()
        {
            int num3;
            for (int num93 = 0; num93 < 5; num93 = num3 + 1)
            {
                float num94 = projectile.velocity.X / 3f * (float)num93;
                float num95 = projectile.velocity.Y / 3f * (float)num93;
                int num96 = 4;
                int num97 = Dust.NewDust(new Vector2(projectile.position.X + (float)num96, projectile.position.Y + (float)num96), projectile.width - num96 * 2, projectile.height - num96 * 2, 114, 0f, 0f, 100, default(Color), 1.2f);
                Main.dust[num97].noGravity = true;
                Dust dust3 = Main.dust[num97];
                dust3.velocity *= 0.1f;
                dust3 = Main.dust[num97];
                dust3.velocity += projectile.velocity * 0.1f;
                Dust dust6 = Main.dust[num97];
                dust6.position.X = dust6.position.X - num94;
                Dust dust7 = Main.dust[num97];
                dust7.position.Y = dust7.position.Y - num95;
                num3 = num93;
            }
            if (Main.rand.Next(5) == 0)
            {
                int num98 = 4;
                int num99 = Dust.NewDust(new Vector2(projectile.position.X + (float)num98, projectile.position.Y + (float)num98), projectile.width - num98 * 2, projectile.height - num98 * 2, 269, 0f, 0f, 100, default(Color), 0.6f);
                Dust dust3 = Main.dust[num99];
                dust3.velocity *= 0.25f;
                dust3 = Main.dust[num99];
                dust3.velocity += projectile.velocity * 0.5f;
            }
        }



        public override void Kill(int timeLeft)
        {
        	Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);
            for (int k = 0; k < 12; k++)
            {
            	Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 228, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
            }
        }
    }
}