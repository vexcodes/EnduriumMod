using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class NatureGuardian : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;

            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 99;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.melee = true;
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 11f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 270f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 13f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nature Guardian");
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int num621 = 0; num621 < 15; num621++)
            {
                int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 38, 0f, 0f, 95, default(Color), 0.4f);
                Main.dust[num622].velocity *= 2f;
            }
        }
    }
}
