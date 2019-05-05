using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class StarChain : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Chain");
        }
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 32;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
            projectile.extraUpdates = 0;
            projectile.ignoreWater = true;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 6;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void AI()
        {
            {
                if (Main.player[projectile.owner].dead)
                {
                    projectile.Kill();
                    return;
                }
                if (projectile.alpha == 0)
                {
                    if (projectile.position.X + (float)(projectile.width / 2) > Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2))
                    {
                        Main.player[projectile.owner].ChangeDir(1);
                    }
                    else
                    {
                        Main.player[projectile.owner].ChangeDir(-1);
                    }
                }
                if (projectile.ai[0] == 0f)
                {
                    projectile.extraUpdates = 0;
                }
                else
                {
                    projectile.extraUpdates = 1;
                }

                Vector2 vector15 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                float num167 = Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) - vector15.X;
                float num168 = Main.player[projectile.owner].position.Y + (float)(Main.player[projectile.owner].height / 2) - vector15.Y;
                float num169 = (float)Math.Sqrt((double)(num167 * num167 + num168 * num168));
                if (projectile.ai[0] == 0f)
                {
                    if (num169 > 700f)
                    {
                        projectile.ai[0] = 1f;
                    }
                    else if (num169 > 650f)
                    {
                        projectile.ai[0] = 1f;
                    }
                    projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
                    projectile.ai[1] += 1f;
                    if (projectile.ai[1] > 9f)
                    {
                        projectile.alpha = 0;
                    }
                    if (projectile.ai[1] > 14f)
                    {
                        projectile.ai[1] = 14f;
                    }
                }
                else if (projectile.ai[0] == 1f)
                {
                    projectile.tileCollide = false;
                    projectile.rotation = (float)Math.Atan2((double)num168, (double)num167) - 1.57f;
                    float num170 = 40f;
                    if (num169 < 50f)
                    {
                        projectile.Kill();
                    }
                    num169 = num170 / num169;
                    num167 *= num169;
                    num168 *= num169;
                    projectile.velocity.X = num167;
                    projectile.velocity.Y = num168;
                }
            }
        }
    }
}
	

			