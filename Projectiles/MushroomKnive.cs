using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class MushroomKnive : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 9;
            projectile.height = 19;
            projectile.friendly = true;
            projectile.thrown = true;

            projectile.penetrate = 3;
            projectile.aiStyle = 1;
            projectile.timeLeft = 1200;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gleam Dagger");
        }

        public override void AI()
        {
            int a = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Shrooms"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 20)
            {
                projectile.rotation *= 1.055f;
                projectile.velocity.Y = projectile.velocity.X / 3f;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {                                                           // sound that the projectile make when hiting the terrain
            for (int num622 = 0; num622 < 20; num622 = 2)
            {
                int a = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Shrooms"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 10);
            }
            return false;
        }
    }
}