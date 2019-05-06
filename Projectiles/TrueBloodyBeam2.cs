using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class TrueBloodyBeam2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul Leeching Beam");
        }
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.friendly = true;
            projectile.aiStyle = -1;
            projectile.magic = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 400;
            projectile.alpha = 225;
            projectile.light = 0.0f;
            projectile.extraUpdates = 4;
            projectile.ignoreWater = true;
        }
        public override void AI()
        {
            if (projectile.timeLeft > 295)
            {
                int num16 = 0;
                Vector2 value6 = projectile.Center;
                for (int k = 0; k < num16 + 1; k++)
                {
                    int num18 = 90;
                    float num19 = 1.1f;
                    Vector2 vector14 = value6 + ((float)Main.rand.NextDouble() * 6.28318548f).ToRotationVector2() * ((19f) - (float)(num16 * 2));
                    int num20 = Dust.NewDust(vector14 - Vector2.One * 8f, 16, 16, num18, projectile.velocity.X / 2f, projectile.velocity.Y / 2f, 0, default(Color), 0.6f);
                    Main.dust[num20].velocity = Vector2.Normalize(value6 - vector14) * 1.5f * (10f - (float)num16 * 2f) / 10f;
                    Main.dust[num20].noGravity = true;
                    Main.dust[num20].scale = num19;
                }
            }
            if (projectile.timeLeft == 295)
            {
                Vector2 value11 = Main.screenPosition + new Vector2((float)Main.mouseX, Main.mouseY);
                projectile.velocity = Vector2.Normalize(value11 - projectile.Center) * 8;
            }
            if (projectile.timeLeft < 295)
            {
                Vector2 vector36 = projectile.position;
                projectile.alpha = 255;
                int num453 = Dust.NewDust(vector36, 1, 1, 90, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num453].position = vector36;
                Main.dust[num453].scale = (float)Main.rand.Next(70, 110) * 0.013f;
                Dust dust3 = Main.dust[num453];
                dust3.velocity *= 0f;
                dust3.noGravity = true;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            int heal = (Main.rand.Next(1) + 2);
            player.HealEffect(heal);
            player.statLife += heal;
        }
    }
}