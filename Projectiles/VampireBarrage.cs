using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class VampireBarrage : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.alpha = 255;
            projectile.penetrate = 1;
            projectile.timeLeft = 20;
            projectile.aiStyle = 1;
            aiType = 1;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vampire Barrage");
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("BloodFangFlame"), 360);
        }
        public override void AI()
        {
            projectile.ai[1] += 1;
            if (projectile.ai[1] <= 5)
            {
                int b = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 182, projectile.velocity.X * 0.25f, projectile.velocity.Y * 0.15f);
                Main.dust[b].noGravity = true;
            }
            float num94 = projectile.velocity.X / 3f;
            float num95 = projectile.velocity.Y / 3f;
            int num96 = 4;
            int num97 = Dust.NewDust(new Vector2(projectile.position.X + (float)num96, projectile.position.Y + (float)num96), projectile.width - num96 * 2, projectile.height - num96 * 2, 182, 0f, 0f, 100, default(Color), 1.2f);
            Main.dust[num97].noGravity = true;
            Dust dust3 = Main.dust[num97];
            dust3.velocity *= 0.1f;
            dust3.noGravity = true;
            dust3 = Main.dust[num97];
            dust3.velocity += projectile.velocity * 0.1f;
            Dust dust6 = Main.dust[num97];
            dust6.position.X = dust6.position.X - num94;
            Dust dust7 = Main.dust[num97];
            dust7.position.Y = dust7.position.Y - num95;
        }
    }
}