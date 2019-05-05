using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.TropicalParadise.HardMode
{
    public class StoneFeather : ModProjectile
    {
    	
        public override void SetDefaults()
        {
            projectile.width = 9;
            projectile.height = 19;
            projectile.hostile = true;
            projectile.thrown = true;
            projectile.penetrate = 5;
            projectile.aiStyle = 1;
            projectile.timeLeft = 1200;
            aiType = 48;
        }

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Fossilized Feather");
    }
        public override void AI()
        {
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.penetrate--;
            if (projectile.penetrate <= 0)
            {
                projectile.Kill();
            }
            else
            {
                projectile.ai[0] += 0.2f;
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
            }
            return false;
        }
        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 3, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
            }
		}
    }
}
