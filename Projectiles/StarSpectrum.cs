using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class StarSpectrum : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 46;
            projectile.aiStyle = 1;
            projectile.light = 0.25f;
            projectile.friendly = false;
            projectile.tileCollide = false;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.penetrate = 1;
            projectile.alpha = 250;
            projectile.timeLeft = 500;
            aiType = ProjectileID.Bullet;
        }
        public override void Kill(int timeLeft)
        {
            for (int num621 = 0; num621 < 12; num621++)
            {
                int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 156, 0f, 0f, 100, default(Color), 1.2f);
                Main.dust[num622].velocity *= 3f;
            }
            for (int num623 = 0; num623 < 15; num623++)
            {
                int num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 156, 0f, 0f, 100, default(Color), 1.7f);
                Main.dust[num624].noGravity = true;
                Main.dust[num624].velocity *= 3f;
                num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 156, 0f, 0f, 100, default(Color), 1f);
                Main.dust[num624].velocity *= 1f;
                Main.dust[num624].noGravity = true;
                Main.dust[num624].fadeIn = 0.7f;
            }
        }
        public override void AI()
        {
            if (projectile.alpha >= 120)
            {
                projectile.alpha -= 10;
            }
            int num4324;
            int num;
            for (int num20 = 0; num20 < 4; num20 = num4324 + 1)
            {
                float num21 = projectile.velocity.X / 4f * (float)num20;
                float num22 = projectile.velocity.Y / 4f * (float)num20;
                int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 156, 0f, 0f, 0, default(Color), 0.28f);
                Main.dust[num23].position.X = projectile.Center.X - num21;
                Main.dust[num23].position.Y = projectile.Center.Y - num22;
                Dust dust3 = Main.dust[num23];
                dust3.velocity *= 0f;
                Main.dust[num23].scale = 0.28f;
                Main.dust[num23].velocity *= 0.28f;
                Main.dust[num23].noGravity = true;
                num4324 = num20;
            }
            if (projectile.ai[1] == 0f)
            {
                projectile.ai[1] = 1f;
                Main.PlaySound(SoundID.Item91, projectile.position);
            }
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Spectrum");
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }
    }
}