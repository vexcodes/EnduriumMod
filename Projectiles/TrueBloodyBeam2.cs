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
            DisplayName.SetDefault("True Vampire Beam");
        }
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 400;
            projectile.alpha = 225;
            projectile.light = 0.0f;
            projectile.extraUpdates = 100;
            projectile.ignoreWater = true;
        }
        public override void AI()
        {

            int num;
            for (int num1 = 0; num1 < 10; num1 = num + 1)
            {
                float x2 = projectile.position.X - projectile.velocity.X / 10f * (float)num1;
                float y2 = projectile.position.Y - projectile.velocity.Y / 10f * (float)num1;
                int num2 = Dust.NewDust(new Vector2(x2, y2), 1, 1, 12, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num2].alpha = projectile.alpha;
                Main.dust[num2].position.X = x2;
                Main.dust[num2].position.Y = y2;
                Dust dust3 = Main.dust[num2];
                dust3.velocity *= 0f;
                Main.dust[num2].noGravity = true;
                num = num1;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            int healAmount = (Main.rand.Next(1) + 2);
            player.statLife += healAmount;
            player.HealEffect(healAmount);
        }
    }
}