using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class BloodOrb : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloodlight Orbstone");
        }
        public override void SetDefaults()
        {
            projectile.width = 38;
            projectile.height = 38;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 4800;
            projectile.alpha = 100;
            projectile.minion = true;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
            for (int num621 = 0; num621 < 15; num621++)
            {
                int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 115, 0f, 0f, 100, default(Color), 1.2f);
                Main.dust[num622].velocity *= 3f;
            }
        }
        public override void AI()
        {
            if (projectile.ai[0] == 0f)
            {
                projectile.ai[0] = projectile.velocity.X;
                projectile.ai[1] = projectile.velocity.Y;
            }
            if (projectile.velocity.X > 0f)
            {
                projectile.rotation += (Math.Abs(projectile.velocity.Y) + Math.Abs(projectile.velocity.X)) * 0.001f;
            }
            else
            {
                projectile.rotation -= (Math.Abs(projectile.velocity.Y) + Math.Abs(projectile.velocity.X)) * 0.001f;
            }
            int num3 = projectile.frameCounter;
            projectile.frameCounter = num3 + 1;
            if (projectile.frameCounter > 6)
            {
                projectile.frameCounter = 0;
                num3 = projectile.frame;
                projectile.frame = num3 + 1;
                if (projectile.frame > 4)
                {
                    projectile.frame = 0;
                }
            }
            if (Math.Sqrt((double)(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y)) > 2.0)
            {
                projectile.velocity *= 0.98f;
            }
            for (int num432 = 0; num432 < 1000; num432 = num3 + 1)
            {
                if (num432 != projectile.whoAmI && Main.projectile[num432].active && Main.projectile[num432].owner == projectile.owner && Main.projectile[num432].type == projectile.type && projectile.timeLeft > Main.projectile[num432].timeLeft && Main.projectile[num432].timeLeft > 30)
                {
                    Main.projectile[num432].timeLeft = 30;
                }
                num3 = num432;
            }

        }
    }
}