using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class NeoniteBlaster : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neonite Blast");
        }
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.alpha = 255;
            projectile.penetrate = 1;
            projectile.timeLeft /= 2;
            projectile.magic = true;
			projectile.extraUpdates = 3;
        }

        public override void Kill(int timeLeft)
        {
            int num3;
            for (int num20 = 0; num20 < 4; num20 = num3 + 1)
            {
                float num21 = projectile.velocity.X / 4f * (float)num20;
                float num22 = projectile.velocity.Y / 4f * (float)num20;
                int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 27, 0f, 0f, 0, default(Color), 1.8f);
                Main.dust[num23].position.X = projectile.Center.X - num21;
                Main.dust[num23].position.Y = projectile.Center.Y - num22;
                Dust dust3 = Main.dust[num23];
                dust3.velocity *= 0.6f;
                Main.dust[num23].scale = 0.3f;
                Main.dust[num23].fadeIn = 0.8f;
                num3 = num20;
            }
            for (int num20 = 0; num20 < 4; num20 = num3 + 1)
            {
                float num21 = projectile.velocity.X / 4f * (float)num20;
                float num22 = projectile.velocity.Y / 4f * (float)num20;
                int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 57, 0f, 0f, 0, default(Color), 1.8f);
                Main.dust[num23].position.X = projectile.Center.X - num21;
                Main.dust[num23].position.Y = projectile.Center.Y - num22;
                Dust dust3 = Main.dust[num23];
                dust3.velocity *= 0.66f;
                Main.dust[num23].scale = 0.36f;
                Main.dust[num23].fadeIn = 0.8f;
                num3 = num20;
            }
        }
        public override void AI()
        {
            int num3;
            for (int num93 = 0; num93 < 5; num93 = num3 + 1)
            {
                float num94 = projectile.velocity.X / 3f * (float)num93;
                float num95 = projectile.velocity.Y / 3f * (float)num93;
                int num96 = 4;
                int num97 = Dust.NewDust(new Vector2(projectile.position.X + (float)num96, projectile.position.Y + (float)num96), projectile.width - num96 * 2, projectile.height - num96 * 2, 27, 0f, 0f, 100, default(Color), 0.65f);
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
                int num99 = Dust.NewDust(new Vector2(projectile.position.X + (float)num98, projectile.position.Y + (float)num98), projectile.width - num98 * 2, projectile.height - num98 * 2, 57, 0f, 0f, 100, default(Color), 1.7f);
                Dust dust3 = Main.dust[num99];
                dust3.velocity *= 0.05f;
                dust3 = Main.dust[num99];
                dust3.velocity += projectile.velocity * 0.5f;
            }
        }
    }
}