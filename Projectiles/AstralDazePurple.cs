using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class AstralDazePurple : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 18;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 800;
            projectile.light = 0.25f;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 2;
            ProjectileID.Sets.TrailingMode[projectile.type] = 5;
            projectile.aiStyle = 2;
            aiType = 48;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Death");
        }
        // 54 14 70 0.8
        public override bool PreAI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;
            projectile.ai[0] += 1;

            if (projectile.ai[0] < 20)
            {
                Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.ToRadians(1));
                projectile.velocity.Y = perturbedSpeed.Y;
                projectile.velocity.X = perturbedSpeed.X;
            }
            else if (projectile.ai[0] >= 20 && projectile.ai[0] < 40)
            {
                Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.ToRadians(-2));
                projectile.velocity.Y = perturbedSpeed.Y;
                projectile.velocity.X = perturbedSpeed.X;

            }
            if (projectile.ai[0] >= 40 && projectile.ai[0] < 60)
            {
                Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.ToRadians(1));
                projectile.velocity.Y = perturbedSpeed.Y;
                projectile.velocity.X = perturbedSpeed.X;
            }
            if (projectile.ai[0] >= 60)
            {
                projectile.ai[0] = 0;
            }
            while (projectile.velocity.X >= 12f || projectile.velocity.X <= -12f || projectile.velocity.Y >= 12f || projectile.velocity.Y < -12f)
            {
                Projectile projectile2 = projectile;
                projectile2.velocity.X = projectile2.velocity.X * 0.97f;
                Projectile projectile3 = projectile;
                projectile3.velocity.Y = projectile3.velocity.Y * 0.97f;
            }
            return false;
        }

        public override void Kill(int timeLeft)
        {
            Vector2 vector19 = projectile.position;
            Vector2 oldVelocity = projectile.oldVelocity;
            oldVelocity.Normalize();
            vector19 += oldVelocity * 16f;
            int num3;
            for (int num355 = 0; num355 < 4; num355 = num3 + 1)
            {
                int num356 = Dust.NewDust(vector19, projectile.width, projectile.height, 173, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num356].position = (Main.dust[num356].position + projectile.Center) / 2f;
                Dust dust = Main.dust[num356];
                dust.velocity += projectile.oldVelocity * 1.4f;
                dust = Main.dust[num356];
                dust.velocity *= 0.8f;
                dust.fadeIn *= 2.8f;
                Main.dust[num356].noGravity = true;
                vector19 -= oldVelocity * 2f;
                num3 = num355;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }
    }
}
