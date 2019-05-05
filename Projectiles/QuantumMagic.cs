using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class QuantumMagic : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Quantum storm");
        }
        public override void SetDefaults()
        {
            projectile.width = 38;
            projectile.height = 38;
            projectile.friendly = true;
            projectile.penetrate = 4;
            projectile.timeLeft = 24;
            projectile.alpha = 100;
            projectile.extraUpdates = 2;
            projectile.magic = true;
        }
        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("QuantumExplosion"), (int)((double)projectile.damage * 0.25), projectile.knockBack, projectile.owner, 0f, 0f);
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
            for (int num621 = 0; num621 < 15; num621++)
            {
                int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 45, 0f, 0f, 100, default(Color), 1.2f);
                Main.dust[num622].velocity *= 3f;
            }
            for (int i = 4; i < 35; i++)
            {
                float x = projectile.oldVelocity.X * (20f / i);
                float y = projectile.oldVelocity.Y * (20f / i);
                int newDust = Dust.NewDust(new Vector2(projectile.oldPosition.X - x, projectile.oldPosition.Y - y), 8, 8, 45, projectile.oldVelocity.X, projectile.oldVelocity.Y, 58, default(Color), 1.4f);
                Main.dust[newDust].noGravity = true;
                Main.dust[newDust].velocity *= 0.5f;
            }
        }
        public override void AI()
        {
            int num3;
            for (int num20 = 0; num20 < 5; num20 = num3 + 3)
            {
                float num21 = projectile.velocity.X / 4f * (float)num20;
                float num22 = projectile.velocity.Y / 4f * (float)num20;
                int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 45, 0f, 0f, 0, default(Color), 0.4f);
                Main.dust[num23].position.X = projectile.Center.X - num21;
                Main.dust[num23].position.Y = projectile.Center.Y - num22;
                Dust dust3 = Main.dust[num23];
                dust3.velocity *= 0f;
                Main.dust[num23].scale = 0.2f;
                num3 = num20;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 6;
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("QuantumExplosion"), (int)((double)projectile.damage * 1.25), projectile.knockBack, projectile.owner, 0f, 0f);
            for (int i = 4; i < 35; i++)
            {
                float x = projectile.oldVelocity.X * (20f / i);
                float y = projectile.oldVelocity.Y * (20f / i);
                int newDust = Dust.NewDust(new Vector2(projectile.oldPosition.X - x, projectile.oldPosition.Y - y), 8, 8, 45, projectile.oldVelocity.X, projectile.oldVelocity.Y, 58, default(Color), 1.4f);
                Main.dust[newDust].noGravity = true;
                Main.dust[newDust].velocity *= 0.5f;
            }
        }

    }
}