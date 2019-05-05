using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class ScourgeoftheShadow : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 72;
            projectile.friendly = true;
            projectile.aiStyle = 1;
            aiType = ProjectileID.Bullet;
            projectile.tileCollide = false;
            projectile.melee = true;
            projectile.penetrate = 5;      //this is how many enemy this projectile penetrate before desapear 
            projectile.extraUpdates = 1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scourge of the Shadows");
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Main.PlaySound(3, (int)projectile.position.X, (int)projectile.position.Y, 1, 1f, 0f);
            int num3;
            for (int num622 = 0; num622 < 20; num622 = num3 + 1)
            {
                int num623 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 184, 0f, 0f, 0, default(Color), 1f);
                Dust dust = Main.dust[num623];
                dust.scale *= 1.2f;
                Main.dust[num623].noGravity = true;
                num3 = num622;
            }
            for (int num622 = 0; num622 < 20; num622 = num3 + 1)
            {
                int num623 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 173, 0f, 0f, 0, default(Color), 1.1f);
                Dust dust = Main.dust[num623];
                dust.scale *= 1.2f;
                Main.dust[num623].noGravity = true;
                num3 = num622;
            }
            for (int num624 = 0; num624 < 30; num624 = num3 + 1)
            {
                int num625 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 184, 0f, 0f, 0, default(Color), 1f);
                Dust dust = Main.dust[num625];
                dust.velocity *= 2.5f;
                dust = Main.dust[num625];
                dust.scale *= 0.9f;
                Main.dust[num625].noGravity = true;
                num3 = num624;
            }
            if (projectile.owner == Main.myPlayer)
            {
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
                for (int num627 = 0; num627 < num626; num627 = num3 + 5)
                {
                    float num628 = (float)Main.rand.Next(-35, 36) * 0.02f;
                    float num629 = (float)Main.rand.Next(-35, 36) * 0.02f;
                    num628 *= 20f;
                    num629 *= 20f;
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, num628, num629, 307, (int)((double)projectile.damage * 0.75), (float)((int)((double)projectile.knockBack * 0.35)), Main.myPlayer, 0f, 0f);
                    num3 = num627;
                }
                for (int num627 = 0; num627 < num626; num627 = num3 + 5)
                {
                    float num628 = (float)Main.rand.Next(-35, 36) * 0.02f;
                    float num629 = (float)Main.rand.Next(-35, 36) * 0.02f;
                    num628 *= 20f;
                    num629 *= 20f;
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, num628, num629, 307, (int)((double)projectile.damage * 0.75), (float)((int)((double)projectile.knockBack * 0.35)), Main.myPlayer, 0f, 0f);
                    num3 = num627;
                }
                for (int num627 = 0; num627 < num626; num627 = num3 + 5)
                {
                    float num628 = (float)Main.rand.Next(-35, 36) * 0.02f;
                    float num629 = (float)Main.rand.Next(-35, 36) * 0.02f;
                    num628 *= 20f;
                    num629 *= 20f;
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, num628, num629, 307, (int)((double)projectile.damage * 0.75), (float)((int)((double)projectile.knockBack * 0.35)), Main.myPlayer, 0f, 0f);
                    num3 = num627;
                }
            }
        }
        public override void AI()
        {
            if (projectile.alpha <= 200)
            {
                int num3;
                for (int num20 = 0; num20 < 4; num20 = num3 + 1)
                {
                    float num21 = projectile.velocity.X / 4f * (float)num20;
                    float num22 = projectile.velocity.Y / 4f * (float)num20;
                    int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 184, 0f, 0f, 0, default(Color), 1.6f);
                    Main.dust[num23].position.X = projectile.Center.X - num21;
                    Main.dust[num23].position.Y = projectile.Center.Y - num22;
                    Dust dust3 = Main.dust[num23];
                    dust3.velocity *= 0f;
                    Main.dust[num23].scale = 0.7f;
                    num3 = num20;
                }
                for (int num20 = 0; num20 < 4; num20 = num3 + 1)
                {
                    float num21 = projectile.velocity.X / 4f * (float)num20;
                    float num22 = projectile.velocity.Y / 4f * (float)num20;
                    int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 173, 0f, 0f, 0, default(Color), 1.3f);
                    Main.dust[num23].position.X = projectile.Center.X - num21;
                    Main.dust[num23].position.Y = projectile.Center.Y - num22;
                    Dust dust3 = Main.dust[num23];
                    dust3.velocity *= 0f;
                    Main.dust[num23].scale = 0.7f;
                    num3 = num20;
                }
            }
            projectile.alpha -= 50;
            if (projectile.alpha < 0)
            {
                projectile.alpha = 0;
            }
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 0.785f;

        }
    }
}