using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class PutridSpore : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Putrid Spore");
        }
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 10;
            projectile.timeLeft = 100;
            projectile.extraUpdates = 1;
            aiType = ProjectileID.Bullet;
        }
        public override void AI()
        {
            projectile.velocity *= 0.94f;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 184, projectile.velocity.X * 0f, projectile.velocity.Y * 0f);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int num3;
            int num626 = 4;
            if (target.life <= 0)
            {
                for (int num627 = 0; num627 < num626; num627 = num3 + 4)
                {
                    float num628 = (float)Main.rand.Next(-35, 36) * 0.02f;
                    float num629 = (float)Main.rand.Next(-35, 36) * 0.02f;
                    num628 *= 20f;
                    num629 *= 20f;
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, num628, num629, mod.ProjectileType("PutridSpore"), (int)((double)projectile.damage * 0.75), (float)((int)((double)projectile.knockBack * 0.35)), Main.myPlayer, 0f, 0f);
                    num3 = num627;
                }
            }
            target.AddBuff(mod.BuffType("whACk"), 120);
            for (int num621 = 0; num621 < 8; num621++)
            {
                int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 184, 0f, 0f, 95, default(Color), 0.9f);
                Main.dust[num622].velocity *= 2f;
            }
        }
    }
}