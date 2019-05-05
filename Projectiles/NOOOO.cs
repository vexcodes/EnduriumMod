using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class NOOOO : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("No one will know :>"); //hopefully...
        }
        public override void SetDefaults()
        {
            projectile.width = 50;
            projectile.height = 50;
            projectile.hostile = false;
            projectile.friendly = false;
            projectile.timeLeft = 1;
        }
    }
}