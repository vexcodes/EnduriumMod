using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System.IO;

namespace EnduriumMod.Projectiles
{
    public class PlagueHeart : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;
			            projectile.CloneDefaults(ProjectileID.TheEyeOfCthulhu);
            projectile.width = 12;
            projectile.height = 12;
            projectile.aiStyle = 99;
            projectile.friendly = true;
			projectile.scale = 1f;
            projectile.penetrate = 9;
            projectile.melee = true;
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 10f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 310f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 10f;
        }
				        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
        	target.AddBuff(mod.BuffType("BloodFangFlame"), 60);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plague Heart");
        }
    }
}