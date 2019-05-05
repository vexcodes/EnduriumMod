using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class LeechingDagger : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 34;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = 1;
            projectile.aiStyle = 1;
            projectile.timeLeft = 600;
            projectile.alpha = 40;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            if (Main.rand.Next(3) == 0)
            {
                int GEY = (Main.rand.Next(1) + 1);
                player.statLife += GEY;
                player.HealEffect(GEY);
            }
        }
        public override void AI()
        {
            int b = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 35, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            projectile.ai[1] += 1f;
            if (projectile.ai[1] >= 40f)
            {
                projectile.alpha += 2;
                if (projectile.alpha > 255)
                {
                    projectile.alpha = 255;
                    projectile.Kill();
                }
            }

        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.ai[0] += 3f;
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = -oldVelocity.X;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.velocity.Y = -oldVelocity.Y;
            }
            return false;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Leeching Dagger");
        }
    }
}