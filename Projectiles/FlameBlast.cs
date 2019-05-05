using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Achievements;


namespace EnduriumMod.Projectiles
{
    public class FlameBlast : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flaming Blast");
        }

        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.height = 46;
            projectile.width = 46;
            aiType = 696;
            projectile.magic = true;
            Main.projFrames[projectile.type] = 11;
        }
        public override void AI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter == 11)
            {
                projectile.Kill();
            }
        }
    }
}