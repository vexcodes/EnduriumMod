using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class NuclearPlague : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nuclear Plague");
        }
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 10;
            projectile.timeLeft = 1;
            projectile.extraUpdates = 1;
            aiType = ProjectileID.Bullet;
        }
        public override void AI()
        {
            projectile.velocity.X *= 0.975f;
            projectile.velocity.Y *= 0.975f;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 89, projectile.velocity.X * 0f, projectile.velocity.Y * 0f);
        }
        public override void Kill(int timeLeft)
        {
            int numProj = 3;
            float rotation = MathHelper.ToRadians(Main.rand.Next(1, 360));
            for (int i = 0; i < numProj + 1; i++)
            {
                Vector2 perturbedSpeed = new Vector2(projectile.velocity.X * 3f, projectile.velocity.Y * 3f).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numProj - 1)));
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("NuclearPlague1"), (int)((double)projectile.damage * 0.8f), projectile.knockBack, projectile.owner, 0f, 0f);

            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("whACk"), 120);
            for (int num621 = 0; num621 < 15; num621++)
            {
                int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 89, 0f, 0f, 95, default(Color), 0.9f);
                Main.dust[num622].velocity *= 2f;
            }
            for (int num623 = 0; num623 < 30; num623++)
            {
                int num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 89, 0f, 0f, 100, default(Color), 0.5f);
                Main.dust[num624].noGravity = true;
                Main.dust[num624].velocity *= 2f;
                num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 89, 0f, 0f, 100, default(Color), 1.25f);
                Main.dust[num624].velocity *= 1f;
            }
            if (projectile.penetrate >= 9)
            {
                int numProj = 6;
                float rotation = MathHelper.ToRadians(Main.rand.Next(1, 360));
                for (int i = 0; i < numProj + 3; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numProj - 1)));
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("NuclearPlague1"), (int)((double)projectile.damage * 1f), projectile.knockBack, projectile.owner, 0f, 0f);
                }
            }

        }
    }
}