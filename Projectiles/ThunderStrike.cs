using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class ThunderStrike : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 56;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.extraUpdates = 1;
            projectile.penetrate = 1;
            projectile.aiStyle = 1;
            aiType = 1;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thunder Strike");
        }
        public override void AI()
        {
            int num;
            Vector2 position = projectile.Center + Vector2.Normalize(projectile.velocity) * 26f;
            Dust dust37 = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, 132, 0f, 0f, 100, default(Color), 1f)];
            dust37.position = position;
            dust37.velocity *= 0f;
            Dust dust3 = dust37;
            dust3.position += projectile.velocity.RotatedBy(1.5707963705062866, default(Vector2));
            dust37.noGravity = true;
            dust37 = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, 132, 0f, 0f, 100, default(Color), 1f)];
            dust37.position = position;
            dust37.velocity *= 0f;
            dust3 = dust37;
            dust3.position += projectile.velocity.RotatedBy(-1.5707963705062866, default(Vector2));
            dust37.noGravity = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("Shiver"), 60);
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 60);
            for (int num2 = 0; num2 < 15; num2++)
            {
                int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 132, 0f, 0f, 100, default(Color), 1.2f);
                Main.dust[num].velocity *= 3f;
                Main.dust[num].noGravity = true;
            }
        }
    }
}