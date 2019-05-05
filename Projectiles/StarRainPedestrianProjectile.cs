using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class StarRainPedestrianProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Rune");
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 32;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = 5;
            projectile.timeLeft = 120;
        }
        public override void AI()
        {
            Lighting.AddLight(projectile.Center, new Vector3(0.075f, 0.3f, 0.5f));
            projectile.velocity *= 0.985f;
            projectile.rotation += projectile.velocity.X * 0.2f;
            if (projectile.velocity.X > 0f)
            {
                projectile.rotation += 0.08f;
            }
            else
            {
                projectile.rotation -= 0.08f;
            }
            projectile.ai[1] += 1f;
            if (projectile.ai[1] > 30f)
            {
                projectile.alpha += 10;
                if (projectile.alpha >= 255)
                {
                    projectile.alpha = 255;
                    projectile.Kill();
                    return;
                }
            }
        }
    }
}