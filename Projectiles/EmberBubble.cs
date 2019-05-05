using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class EmberBubble : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flare Bubble");
        }
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.friendly = true;
            projectile.alpha = 255;
            projectile.penetrate = 5;
            projectile.timeLeft = 180;
            projectile.magic = true;
			projectile.scale = 0.75f;
        }

        public override void AI()
        {
            int num795 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 158, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.dust[num795].velocity *= 1f;
            Main.dust[num795].scale = 1f;
            Main.dust[num795].noGravity = true;
        }
    }
}