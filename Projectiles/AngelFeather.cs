using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class AngelFeather : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 24;
            projectile.hostile = true;
            projectile.penetrate = -1;
            projectile.CloneDefaults(38);
            projectile.timeLeft = 1200;
            aiType = 38;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Angel Feather");
        }
    }
}