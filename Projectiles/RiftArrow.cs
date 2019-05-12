using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class RiftArrow : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 1;
            projectile.aiStyle = -1;
            projectile.alpha = 255;
            projectile.timeLeft = 345;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rift Arrow");
        }
        public override void AI()
        {
            if (projectile.ai[0] == 0)
            {
                projectile.ai[0] = 1;
                projectile.scale *= (float)Main.rand.NextFloat(0.8f, 1.2f);
            }

            if (projectile.alpha >= 45)
            {
                projectile.alpha -= 10;
            }
            projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;
            if (projectile.timeLeft == 330)
            {
                int num3;
                for (int num20 = 0; num20 < 10; num20 = num3 + 1)
                {
                    float num21 = projectile.velocity.X / 4f * (float)num20;
                    float num22 = projectile.velocity.Y / 4f * (float)num20;
                    int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 173, 0f, 0f, 0, default(Color), 1.3f);
                    Main.dust[num23].position.X = projectile.Center.X - num21;
                    Main.dust[num23].position.Y = projectile.Center.Y - num22;
                    Dust dust3 = Main.dust[num23];
                    dust3.velocity *= 0.6f;
                    Main.dust[num23].scale = 0.6f;
                    Main.dust[num23].noLight = true;
                    Main.dust[num23].fadeIn = 0.4f;
                    num3 = num20;
                }
                float posX = (float)projectile.ai[0] + Main.rand.Next(-25, 26);
                float posY = (float)projectile.ai[1] + Main.rand.Next(-25, 26);
                Player player = Main.player[Main.myPlayer];
                Vector2 value11 = Main.screenPosition + new Vector2(posX, posY);
                projectile.velocity = Vector2.Normalize(value11 - projectile.Center) * 18;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(153, 300);
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 60);
            for (int num2 = 0; num2 < 15; num2++)
            {
                int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 21, 0f, 0f, 100, default(Color), 1.2f);
                Main.dust[num].velocity *= 3f;
            }
        }
    }
}