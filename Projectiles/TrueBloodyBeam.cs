using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class TrueBloodyBeam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Vampire Beam");
        }
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 3;
            projectile.timeLeft = 200;
            projectile.alpha = 225;
            projectile.light = 0.0f;
            projectile.extraUpdates = 100;
            projectile.ignoreWater = true;
        }
        public override void AI()
        {
            int num;
            for (int num1 = 0; num1 < 10; num1 = num + 1)
            {
                float x2 = projectile.position.X - projectile.velocity.X / 10f * (float)num1;
                float y2 = projectile.position.Y - projectile.velocity.Y / 10f * (float)num1;
                int num2 = Dust.NewDust(new Vector2(x2, y2), 1, 1, 12, 0f, 0f, 0, default(Color), 1.65f);
                Main.dust[num2].alpha = projectile.alpha;
                Main.dust[num2].position.X = x2;
                Main.dust[num2].position.Y = y2;
                Dust dust3 = Main.dust[num2];
                dust3.velocity *= 0f;
                Main.dust[num2].noGravity = true;
                num = num1;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int num3;
            int num626 = 2;
            if (Main.rand.Next(10) == 0)
            {
                num3 = num626;
                num626 = num3 + 1;
            }
            if (Main.rand.Next(10) == 0)
            {
                num3 = num626;
                num626 = num3 + 1;
            }
            if (Main.rand.Next(10) == 0)
            {
                num3 = num626;
                num626 = num3 + 1;
            }
            Player player = Main.player[projectile.owner];
            int healAmount = (Main.rand.Next(1) + 2);
            player.statLife += healAmount;
            player.HealEffect(healAmount);
            float numberProjectiles = 3; // 3, 4, or 5 shots
            float rotation = MathHelper.ToRadians(45);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .9f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("TrueBloodyBeam2"), (int)((double)projectile.damage * 0.75f), projectile.knockBack, projectile.owner, 0f, 0f);
            }
        }
    }
}
				