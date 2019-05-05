using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class EruptionAfterblast : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eruption Afterblast");
            Main.projFrames[projectile.type] = 3;
        }

        public override void SetDefaults()
        {
            projectile.width = 100;
            projectile.height = 100;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.timeLeft = 15;
            projectile.ranged = true;
        }
        public override void AI()
        {
            int num;
            if (Main.netMode != 1)
            {
                for (int num1446 = 0; num1446 < 10; num1446 = num + 1)
                {
                    int num1447 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 133, default(Color), 1.5f);
                    Main.dust[num1447].noGravity = true;
                    Main.dust[num1447].fadeIn = 1f;
                    Dust dust3 = Main.dust[num1447];
                    dust3.velocity *= 4f;
                    Main.dust[num1447].noLight = true;
                    num = num1446;
                }
            }
        }
    }
}