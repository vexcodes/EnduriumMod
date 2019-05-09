using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class Yeeter2Explosion : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Explosion");
        }

        public override void SetDefaults()
        {
            projectile.width = 60;
            projectile.height = 60;
            projectile.tileCollide = false;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.timeLeft = 6;
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
            target.immune[projectile.owner] = 1;
        }
        public override void AI()
        {
            float num3 = 8;
            float num4 = 6.28318548f * Main.rand.NextFloat();
            Vector2 value = new Vector2(32f, 32f);
            for (float num5 = 0f; num5 < num3; num5 += 1f)
            {
                Dust dust = Main.dust[Dust.NewDust(projectile.Center, 0, 0, 170, 0f, 0f, 0, default(Color), 1f)];
                Vector2 vector = Vector2.UnitY.RotatedBy((double)(num5 * 6.28318548f / num3 + num4), default(Vector2));
                dust.position = projectile.Center + vector * value / 2f;
                dust.velocity = vector;
                dust.noGravity = true;
                dust.scale = 1.5f;
                dust.velocity *= dust.scale;
                dust.fadeIn = Main.rand.NextFloat() * 0.6f;
            }

            int num44 = projectile.frameCounter;
            for (int num432 = 0; num432 < 1000; num432 = num44 + 1)
            {
                if (num432 != projectile.whoAmI && Main.projectile[num432].active && Main.projectile[num432].owner == projectile.owner && Main.projectile[num432].type == projectile.type && projectile.timeLeft > Main.projectile[num432].timeLeft && Main.projectile[num432].timeLeft > 1)
                {
                    Main.projectile[num432].timeLeft = 1;
                }
                num44 = num432;
            }
        }
    }
}