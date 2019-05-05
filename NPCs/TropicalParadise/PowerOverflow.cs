using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.TropicalParadise
{
    public class PowerOverflow : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Power Overflow");
        }

        public override void SetDefaults()
        {
            projectile.width = 75;
            projectile.height = 75;
            projectile.hostile = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 120;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 3;
        }
        public override void AI()
        {
            int num3;
            for (int num731 = 0; num731 < 3; num731 = num3 + 1)
            {
                int num732 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 89, 0f, 0f, 100, default(Color), 1.25f);
                Main.dust[num732].noGravity = true;
                Dust dust = Main.dust[num732];
                dust.velocity *= 3.5f;
                num732 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 89, 0f, 0f, 100, default(Color), 1.5f);
                dust = Main.dust[num732];
                Main.dust[num732].noGravity = true;
                dust.velocity *= 2.5f;
                num3 = num731;
            }

        }
    }
}