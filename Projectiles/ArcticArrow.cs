using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class ArcticArrow : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 5;
            projectile.aiStyle = 1;
            aiType = 1;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arctic Arrow");
        }
        public override void AI()
        {
            int num;
            if (projectile.ai[1] == 0f)
            {
                int num003;
                projectile.ai[1] = 1f;
                projectile.localAI[0] = -(float)Main.rand.Next(48);
                for (int num731 = 0; num731 < 12; num731 = num003 + 1)
                {
                    int num732 = Dust.NewDust(projectile.Center, 0, 0, 156, 0f, 0f, 100, default(Color), 1.5f);
                    Main.dust[num732].noGravity = true;
                    Dust dust = Main.dust[num732];
                    dust.velocity *= 3f;
                    num732 = Dust.NewDust(projectile.Center, 0, 0, 156, 0f, 0f, 100, default(Color), 0.5f);
                    dust = Main.dust[num732];
                    dust.velocity *= 1f;
                    num003 = num731;
                }
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("Shiver"), 360);
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 60);
            for (int num2 = 0; num2 < 15; num2++)
            {
                int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 156, 0f, 0f, 100, default(Color), 1.2f);
                Main.dust[num].velocity *= 1f;
                Main.dust[num].noGravity = true;
            }
        }
    }
}