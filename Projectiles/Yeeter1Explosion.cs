using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class Yeeter1Explosion : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Explosion");
        }

        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.tileCollide = false;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 4;
            projectile.thrown = true;
        }
        public override bool? CanHitNPC(NPC target)
        {
            if (projectile.penetrate == 1)
            {
                return false;
            }
            return true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 2;
        }
        public override void AI()
        {
            float num3 = 10;
            float num4 = 6.28318548f * Main.rand.NextFloat();
            Vector2 value = new Vector2(32f, 32f);
            for (float num5 = 0f; num5 < num3; num5 += 1f)
            {
                Dust dust = Main.dust[Dust.NewDust(projectile.Center, 0, 0, 75, 0f, 0f, 0, default(Color), 1f)];
                Vector2 vector = Vector2.UnitY.RotatedBy((double)(num5 * 6.28318548f / num3 + num4), default(Vector2));
                dust.position = projectile.Center + vector * value / 2f;
                dust.velocity = vector;
                dust.noGravity = true;
                dust.scale = 1.25f;
                dust.velocity *= dust.scale;
                dust.fadeIn = Main.rand.NextFloat() * 0.5f;
            }

        }
    }
}