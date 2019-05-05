using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.TheSwarm
{
    public class LeafBloomParticle : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 42;
            projectile.height = 42;
            projectile.hostile = true;
            projectile.tileCollide = false;
            projectile.penetrate = 5;      //this is how many enemy this projectile penetrate before desapear 
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Leaf Bloom");
        }
        public override void AI()
        {
            if (projectile.ai[0] == 0)
            {
                projectile.ai[0] = 1;
                projectile.rotation += Main.rand.NextFloat(-7200f, 7200f);
            }
            projectile.alpha += 8;
            projectile.scale += 0.025f; 
            if (projectile.alpha > 255)
            {
                projectile.Kill();
            }

        }
    }
}
