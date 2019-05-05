using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class CrystalSplit : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 20;
            projectile.light = 0.25f;
            projectile.extraUpdates = 1;
            projectile.aiStyle = 1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Split");
        }

        public override bool PreAI()
        {
            int num3;
            for (int num20 = 0; num20 < 8; num20 = num3 + 8)
            {
                float num21 = projectile.velocity.X / 4f * (float)num20;
                float num22 = projectile.velocity.Y / 4f * (float)num20;
                int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, 0f, 0f, 0, default(Color), 1.2f);
                Main.dust[num23].position.X = projectile.Center.X - num21;
                Main.dust[num23].position.Y = projectile.Center.Y - num22;
                Dust dust3 = Main.dust[num23];
                dust3.velocity *= 0f;
                Main.dust[num23].scale = 1.2f;
                Main.dust[num23].noGravity = true;
                num3 = num20;
            }
            return false;
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 4; i < 42; i++)
            {
                float x = projectile.oldVelocity.X * (20f / i);
                float y = projectile.oldVelocity.Y * (20f / i);
                int newDust = Dust.NewDust(new Vector2(projectile.oldPosition.X - x, projectile.oldPosition.Y - y), 8, 8, 15, projectile.oldVelocity.X, projectile.oldVelocity.Y, 58, default(Color), 1.8f);
                Main.dust[newDust].noGravity = true;
                Main.dust[newDust].velocity *= 0.5f;
            }
            int num3;
            {
                int numProj = 2;
                if (Main.rand.Next(2) == 0)
                {
                    numProj += 1;
                }
                float rotation = MathHelper.ToRadians(10);
                for (int i = 0; i < numProj + 1; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedByRandom(MathHelper.Lerp(-rotation, rotation, i / (numProj - 1)));
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("CrystalBall"), (int)((double)projectile.damage), projectile.knockBack, projectile.owner, 0f, 0f);
                }
            }
        }
    }
}
