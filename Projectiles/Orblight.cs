using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class Orblight : ModProjectile
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
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 6f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 270f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 15f;
        }

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Orblight");
    }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(5) == 0)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 16f, Main.rand.Next(-7, 9) * .25f, Main.rand.Next(-8, -3) * .25f, mod.ProjectileType("Orblighter"), (int)(projectile.damage * .5f), 0, projectile.owner);
            }
        }
    }
}
