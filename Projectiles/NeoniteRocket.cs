using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class NeoniteRocket : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 4;
            projectile.aiStyle = 1;
            projectile.extraUpdates = 5;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neonite Rocket");
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10, projectile.position);
            for (int num2 = 0; num2 < 15; num2++)
            {
                int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 57, 0f, 0f, 100, default(Color), 1.2f);
                Main.dust[num].velocity *= 3f;
                Main.dust[num].noGravity = true;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 6;
        }
        public override void AI()
        {
            int num3;
            if (Main.rand.Next(5) == 0)
            {
                int num98 = 4;
                int num99 = Dust.NewDust(new Vector2(projectile.position.X + (float)num98, projectile.position.Y + (float)num98), projectile.width - num98 * 2, projectile.height - num98 * 2, 27, 0f, 0f, 100, default(Color), 1.7f);
                Dust dust3 = Main.dust[num99];
                dust3.velocity *= 0.05f;
                dust3 = Main.dust[num99];
                dust3.velocity += projectile.velocity * 0.5f;
            }
        }
    }
}