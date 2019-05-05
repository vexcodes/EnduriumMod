using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class BloomlightYoyo : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.extraUpdates = 1;

            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 99;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.melee = true;
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 20f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 170f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 15f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloomlight Yoyo");
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int num2 = 0; num2 < 10; num2++)
            {
                int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 61, 0f, 0f, 125, default(Color), 1.2f);
                Main.dust[num].velocity *= 3f;
            }
        }
    }
}
