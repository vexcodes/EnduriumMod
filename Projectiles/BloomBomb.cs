using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace EnduriumMod.Projectiles
{
    public class BloomBomb : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloom Blast");
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.thrown = true;
            Main.projFrames[projectile.type] = 7;
        }
        public override void SetDefaults()
        {
            projectile.CloneDefaults(696);
            aiType = 696;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.thrown = true;
            projectile.timeLeft = 100;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 16, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
        }
    }
}