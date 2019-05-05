using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class GraniteBolt : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Bolt");
        }
        public override void SetDefaults()
        {
            projectile.width = 4;
            projectile.height = 4;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 200;
            projectile.alpha = 225;
            projectile.light = 0.0f;
            projectile.extraUpdates = 100;
            projectile.ignoreWater = true;
        }
        public override void AI()
        {
            int num3;
            for (int num452 = 0; num452 < 4; num452 = num3 + 1)
            {
                Vector2 vector36 = projectile.position;
                vector36 -= projectile.velocity * ((float)num452 * 0.25f);
                projectile.alpha = 255;
                int num453 = Dust.NewDust(vector36, 1, 1, 56, 0f, 0f, 0, default(Color), 0.5f);
                Main.dust[num453].position = vector36;
                Main.dust[num453].scale = (float)Main.rand.Next(70, 110) * 0.013f;
                Dust dust3 = Main.dust[num453];
                dust3.velocity *= 0f;
                dust3.noGravity = true;
                num3 = num452;
            }
            return;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("GraniteShatter"), 360);
        }
    }
}