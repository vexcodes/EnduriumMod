using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class AcidPlasma : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sulphuric Inferno");
        }

        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.ranged = true;
            projectile.penetrate = 1;
            projectile.extraUpdates = 3;
            projectile.timeLeft = 100;
        }

        public override void AI()
        {
        	Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.15f) / 255f, ((255 - projectile.alpha) * 0.45f) / 255f, ((255 - projectile.alpha) * 0.05f) / 255f);
			if (projectile.ai[0] > 9f)
			{
				projectile.ai[0] += 1f;
                if (Main.rand.Next(2) == 0)
				{
                    for (int num22 = 0; num22 < 1; num22++)
					{
                        int num299 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 220, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 0.85f);
                        int num345 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 107, projectile.velocity.X * 0.8f, projectile.velocity.Y * 0.8f, 100, default(Color), 1f);
                        Main.dust[num345].velocity += projectile.velocity;
                        Main.dust[num299].velocity += projectile.velocity;
                        Main.dust[299].noGravity = true;
                        Main.dust[num345].noGravity = true;
                    }
				}
			}
			else
			{
				projectile.ai[0] += 1f;
			}
			projectile.rotation += 0.3f * (float)projectile.direction;
			return;	
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1, 1f, 0f);
            Vector2 vector19 = projectile.position;
            Vector2 oldVelocity = projectile.oldVelocity;
            oldVelocity.Normalize();
            vector19 += oldVelocity * 16f;
            int num3;
            for (int num355 = 0; num355 < 10; num355 = num3 + 1)
            {
                int num356 = Dust.NewDust(vector19, projectile.width, projectile.height, 107, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num356].position = (Main.dust[num356].position + projectile.Center) / 2f;
                Dust dust = Main.dust[num356];
                dust.velocity += projectile.oldVelocity * 1.4f;
                dust = Main.dust[num356];
                dust.velocity *= 2.5f;
                Main.dust[num356].noGravity = true;
                vector19 -= oldVelocity * 8f;
                num3 = num355;
            }
        }
    }
}