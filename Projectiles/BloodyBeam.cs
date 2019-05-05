using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class BloodyBeam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vampire Beam");
        }
        public override void SetDefaults()
        {
            projectile.width = 4;
            projectile.height = 4;
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
            int num3;
            for (int num452 = 0; num452 < 4; num452 = num3 + 1)
            {
                Vector2 vector36 = projectile.position;
                vector36 -= projectile.velocity * ((float)num452 * 0.25f);
                projectile.alpha = 255;
                int num453 = Dust.NewDust(vector36, 1, 1, 12, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num453].position = vector36;
                Main.dust[num453].scale = (float)Main.rand.Next(70, 110) * 0.013f;
                Dust dust3 = Main.dust[num453];
                dust3.velocity *= 0f;
                dust3.noGravity = true;
                num3 = num452;
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
            if (Main.rand.Next(3) == 0)
            {
                int healAmount = (Main.rand.Next(1) + 1);
                player.statLife += healAmount;
                player.HealEffect(healAmount);
            }
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
				