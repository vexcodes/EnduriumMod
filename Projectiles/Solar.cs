using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class Solar : ModProjectile
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
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 18f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 300f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 12f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solar");
        }
        public override void AI()
        {
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 500);
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] *= 1.03f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] *= 1.03f;
            projectile.velocity.X *= 1.03f;
            projectile.velocity.Y *= 1.03f;
        }
    }
}