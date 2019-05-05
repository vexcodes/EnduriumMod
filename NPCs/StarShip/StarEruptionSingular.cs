using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.StarShip
{
    public class StarEruptionSingular : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 80;
            projectile.height = 80;
            Main.projFrames[projectile.type] = 5;
            projectile.hostile = true;
            projectile.tileCollide = false;
            projectile.penetrate = 5;      //this is how many enemy this projectile penetrate before desapear 
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Eruption");
        }
        public override void AI()
        {
            if (projectile.ai[0] == 0)
            {
                projectile.ai[0] = 1;
                projectile.rotation += Main.rand.NextFloat(-7200f, 7200f);
            }
            projectile.alpha += 12;
            projectile.scale += 0.025f;
            if (projectile.alpha > 255)
            {
                projectile.Kill();
            }
            projectile.frameCounter++;
            if (projectile.frameCounter > 5)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 4)
            {
                projectile.Kill();
                projectile.frame = 0;
            }

        }
    }
}
