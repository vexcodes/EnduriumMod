using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class BloodyRocket : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vampire Bullet");
        }
        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 32;
            projectile.friendly = true;
            projectile.aiStyle = 1;
            projectile.ranged = true;
            projectile.penetrate = 2;      //this is how many enemy this projectile penetrate before desapear 
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;
            projectile.ai[1] += 1;
            if (projectile.ai[1] <= 5)
            {
                int b = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 182, projectile.velocity.X * 0.25f, projectile.velocity.Y * 0.15f);
                Main.dust[b].noGravity = true;
            }
            int a = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 182, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.dust[a].velocity *= 0.1f;
            Main.dust[a].scale *= 0.6f;
            Main.dust[a].noGravity = true;
            projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 20f)       //how much time the projectile can travel before landing
            {
                projectile.velocity.Y = projectile.velocity.Y + 3.15f;    // projectile fall velocity
                projectile.velocity.X = projectile.velocity.X * 2f;    // projectile velocity
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            target.AddBuff(mod.BuffType("BloodFangFlame"), 200);

            if (Main.rand.Next(3) == 0)
            {
                Player player = Main.player[projectile.owner];
                player.statLife += 1;
                player.HealEffect(1);
            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 60);


            for (int num2 = 0; num2 < 3; num2++)
            {
                int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 34, 0f, 0f, 100, default(Color), 1.2f);
                Main.dust[num].velocity *= 3f;
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[num].scale = 0.5f;
                    Main.dust[num].fadeIn = 1f;
                }
            }
        }
    }
}