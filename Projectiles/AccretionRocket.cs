using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class AccretionRocket : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Accretion Missile");
            Main.projFrames[projectile.type] = 3;
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 150;
            projectile.ranged = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("AccretionBurn"), 300);
        }
        public override void AI()
        {
            if (projectile.ai[0] == 0)
            {
                projectile.ai[0] = 1;
                int num3;
                for (int num731 = 0; num731 < 5; num731 = num3 + 1)
                {
                    int num732 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 90, 0f, 0f, 100, default(Color), 1.5f);
                    Main.dust[num732].noGravity = true;
                    Dust dust = Main.dust[num732];
                    dust.velocity *= 2f;
                    num732 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 90, 0f, 0f, 100, default(Color), 0.5f);
                    dust = Main.dust[num732];
                    dust.velocity *= 1f;
                    num3 = num731;
                }
            }
            Player owner = Main.player[projectile.owner]; //Makes a player variable of owner set as the player using the projectile

            if (projectile.alpha < 170)
            {
                int num;
                for (int num164 = 0; num164 < 2; num164 = num + 1)
                {
                    float x2 = projectile.position.X - projectile.velocity.X / 10f * (float)num164;
                    float y2 = projectile.position.Y - projectile.velocity.Y / 2f * (float)num164;
                    int num165 = Dust.NewDust(new Vector2(x2, y2), projectile.width, projectile.height, 90, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[num165].alpha = projectile.alpha;
                    Main.dust[num165].position.X = x2;
                    Main.dust[num165].position.Y = y2;
                    Dust dust3 = Main.dust[num165];
                    dust3.velocity *= 0f;
                    Main.dust[num165].noGravity = true;
                    num = num164;
                }
            }

            projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;

            //new projectile ai

        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item62, projectile.position);
            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 12;
            projectile.height = 12;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            int num3;
            for (int num731 = 0; num731 < 5; num731 = num3 + 1)
            {
                int num732 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 90, 0f, 0f, 100, default(Color), 2.5f);
                Main.dust[num732].noGravity = true;
                Dust dust = Main.dust[num732];
                dust.velocity *= 7f;
                num732 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 90, 0f, 0f, 100, default(Color), 1.5f);
                dust = Main.dust[num732];
                dust.velocity *= 3f;
                num3 = num731;
            }
        }
    }
}