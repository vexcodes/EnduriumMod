using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class HellshardScepter : ModProjectile
    {
        public int pleaseworkbastard = 0;
        public override void SetDefaults()
        {
            projectile.extraUpdates = 1;

            projectile.width = 18;
            projectile.height = 32;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            Main.projFrames[projectile.type] = 6;
            projectile.penetrate = 1;
            projectile.magic = true;
        }
        public override void AI()
        {

            projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;

            projectile.ai[1] += 1;
            if (projectile.ai[1] <= 4)
            {
                for (int num621 = 0; num621 < 5; num621++)
                {
                    int b = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 127, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                    Main.dust[b].noGravity = true;
                    Main.dust[b].scale *= 1.5f;
                    Main.dust[b].velocity *= 1.5f;
                }
            }
            if (pleaseworkbastard == 0)
            {
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 60);
                pleaseworkbastard += 1;
                projectile.frame = Main.rand.Next(5);
            }
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellshard");
        }
        public override void Kill(int timeLeft)
        {
            for (int num621 = 0; num621 < 5; num621++)
            {
                int b = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 127, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                Main.dust[b].noGravity = true;
                Main.dust[b].scale *= 1.5f;
                Main.dust[b].velocity *= 1.5f;
            }
        }
    }
}
