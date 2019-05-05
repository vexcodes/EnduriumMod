using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class TropicSpike : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 24;
            projectile.hostile = false;
            projectile.thrown = true;
            projectile.penetrate = -1;
            projectile.friendly = true;
            aiType = ProjectileID.ThrowingKnife;
            projectile.timeLeft = 180;
            projectile.aiStyle = 1;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tropic Spike");
        }
        public override void AI()
        {
            if (projectile.ai[0] == 0f)
            {
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 18);

            }
        }
    }
}