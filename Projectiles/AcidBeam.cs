using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class AcidBeam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Acid Beam");
        }
        public override void SetDefaults()
        {
            projectile.width = 4;
            projectile.height = 4;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 200;
            projectile.extraUpdates = 100;
            projectile.ignoreWater = true;
        }
        public override void AI()
        {
            int num;
            for (int num143 = 0; num143 < 2; num143 = num + 1)
            {
                int num144 = Utils.SelectRandom<int>(Main.rand, new int[]
                {
                        107,
                        89
                });
                Dust dust23 = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, num144, projectile.velocity.X, projectile.velocity.Y, 25, default(Color), 1f)];
                dust23.velocity = dust23.velocity / 4f + projectile.velocity / 2f;
                dust23.noGravity = true;
                dust23.scale = 1.15f;
                dust23.position = projectile.Center;
                num = num143;
            }
        }
    }
    
}

			