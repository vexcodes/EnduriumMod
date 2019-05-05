using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class BloodTissue : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Clot");
        }
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 38;
            projectile.friendly = true;
            projectile.penetrate = 1;
            Main.projFrames[projectile.type] = 5;
            projectile.timeLeft = 400;
            projectile.aiStyle = 1;
            projectile.minion = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 6;
        }
        public override void AI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > 5)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 4)
            {
                projectile.frame = 0;
            }

            int num288 = Main.rand.Next(5, 10);
            int num3;
            for (int num289 = 0; num289 < num288; num289 = num3 + 1)
            {
                int num290 = Dust.NewDust(projectile.Center, 0, 0, 5, 0f, 0f, 100, default(Color), 0.5f);
                Dust dust = Main.dust[num290];
                dust.velocity *= 1.6f;
                Dust dust27 = Main.dust[num290];
                dust27.velocity.Y = dust27.velocity.Y - 1f;
                dust = Main.dust[num290];
                dust.position -= Vector2.One * 4f;
                Main.dust[num290].position = Vector2.Lerp(Main.dust[num290].position, projectile.Center, 0.5f);
                Main.dust[num290].noGravity = true;
                num3 = num289;
            }
        }
    }
}