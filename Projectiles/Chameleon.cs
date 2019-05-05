using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class Chameleon : ModProjectile
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
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 9.5f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 220f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 14f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chameleon");
        }
    }
}
