using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class TruePutridSpore : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Putrid Spore");
        }
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 10;
            projectile.timeLeft = 140;
            projectile.extraUpdates = 1;
            aiType = ProjectileID.Bullet;
        }
        public override void AI()
        {
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 184, projectile.velocity.X * 0f, projectile.velocity.Y * 0f);
        }
        public override void Kill(int timeLeft)
        {
            int num3;
            int num626 = 4;
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
            for (int num627 = 0; num627 < num626; num627 = num3 + 3)
            {
                float num628 = (float)Main.rand.Next(-35, 36) * 0.02f;
                float num629 = (float)Main.rand.Next(-35, 36) * 0.02f;
                num628 *= 20f;
                num629 *= 20f;
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, num628, num629, mod.ProjectileType("PutridSpore"), (int)((double)projectile.damage * 0.75), (float)((int)((double)projectile.knockBack * 0.35)), Main.myPlayer, 0f, 0f);
                num3 = num627;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("whACk"), 120);
            for (int num621 = 0; num621 < 15; num621++)
            {
                int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 184, 0f, 0f, 95, default(Color), 0.9f);
                Main.dust[num622].velocity *= 2f;
            }
            for (int num623 = 0; num623 < 30; num623++)
            {
                int num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 163, 0f, 0f, 100, default(Color), 0.5f);
                Main.dust[num624].noGravity = true;
                Main.dust[num624].velocity *= 2f;
                num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 184, 0f, 0f, 100, default(Color), 1.25f);
                Main.dust[num624].velocity *= 1f;
            }
            if (projectile.penetrate >= 9)
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
                for (int num627 = 0; num627 < num626; num627 = num3 + 7)
                {
                    float num628 = (float)Main.rand.Next(-1, 360) * 0.02f;
                    float num629 = (float)Main.rand.Next(-1, 360) * 0.02f;
                    num628 *= 20f;
                    num629 *= 20f;
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, num628, num629, mod.ProjectileType("TruePutridSpore1"), (int)((double)projectile.damage * 0.75), (float)((int)((double)projectile.knockBack * 0.35)), Main.myPlayer, 0f, 0f);
                    num3 = num627;
                }
            }

        }
    }
}