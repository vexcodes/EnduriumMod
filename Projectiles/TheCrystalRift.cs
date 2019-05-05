using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class TheCrystalRift : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 22;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 1;
            projectile.aiStyle = 1;
            projectile.alpha = 255;
            aiType = 1;
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 4; i < 12; i++)
            {
                float x = projectile.oldVelocity.X * (20f / i);
                float y = projectile.oldVelocity.Y * (20f / i);
                int newDust = Dust.NewDust(new Vector2(projectile.oldPosition.X - x, projectile.oldPosition.Y - y), 8, 8, 173, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, default(Color), 2.2f);
                Main.dust[newDust].noGravity = true;
                Main.dust[newDust].velocity *= 0.5f;
            }
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Crystal Rift");
        }
        public override void AI()
        {
            if (projectile.alpha >= 0)
            {
                projectile.alpha -= 10;
            }
            int num3;
            for (int num20 = 0; num20 < 2; num20 = num3 + 1)
            {
                float num21 = projectile.velocity.X / 4f * (float)num20;
                float num22 = projectile.velocity.Y / 4f * (float)num20;
                int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 173, 0f, 0f, projectile.alpha, default(Color), 0.2f);
                Main.dust[num23].position.X = projectile.Center.X - num21;
                Main.dust[num23].position.Y = projectile.Center.Y - num22;
                Dust dust3 = Main.dust[num23];
                dust3.velocity *= 0.25f;
                Main.dust[num23].scale = 0.8f;
                num3 = num20;
            }
        }
    }
}