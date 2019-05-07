using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.TheSwarm
{
    public class PlagueEnergy : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plague Energy");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 1;
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 4; i < 15; i++)
            {
                float x = projectile.oldVelocity.X * (20f / i);
                float y = projectile.oldVelocity.Y * (20f / i);
                int newDust = Dust.NewDust(new Vector2(projectile.oldPosition.X - x, projectile.oldPosition.Y - y), 0, 0, 61, projectile.oldVelocity.X, projectile.oldVelocity.Y, 0, default(Color), 1.8f);
                Main.dust[newDust].noGravity = true;
                Main.dust[newDust].velocity *= 0.1f;
            }
        }
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 22;
            projectile.hostile = true;
            projectile.penetrate = 4;
            projectile.timeLeft = 200;
            projectile.ranged = true;
        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            int num;
            float[] arg_56E6_0 = projectile.localAI;
            int arg_56E6_1 = 0;
            if (projectile.localAI[1] == 0f)
            {
                projectile.localAI[1] += 1f;
                Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 102, 1f, 0f);
                for (int num113 = 0; num113 < 15; num113 = num + 1)
                {
                    if (Main.rand.Next(4) != 0)
                    {
                        Dust dust12 = Dust.NewDustDirect(projectile.Center - projectile.Size / 4f, projectile.width / 2, projectile.height / 2, Utils.SelectRandom<int>(Main.rand, new int[]
                            {
                                89,
                                61
                            }), 0f, 0f, 0, default(Color), 1f);
                        dust12.noGravity = true;
                        Dust dust3 = dust12;
                        dust3.velocity *= 2.3f;
                        dust12.fadeIn = 1.5f;
                        dust12.noLight = true;
                    }
                    num = num113;
                }
            }
            num = projectile.frameCounter + 1;
            projectile.frameCounter = num;
            if (num >= 40)
            {
                projectile.frameCounter = 0;
            }
            int num0004;
            num0004 = projectile.frameCounter + 1;
            projectile.frameCounter = num0004;
            if (num0004 >= 40)
            {
                projectile.frameCounter = 0;
            }
            projectile.frame = projectile.frameCounter / 5;
            Player owner = Main.player[projectile.owner]; //Makes a player variable of owner set as the player using the projectile
            if (projectile.alpha < 170)
            {
                Vector2 vector15 = new Vector2(0f, (float)Math.Cos((double)((float)projectile.frameCounter * 6.28318548f / 40f - 1.57079637f))) * 16f;
                vector15 = vector15.RotatedBy((double)projectile.rotation, default(Vector2));
                Vector2 value16 = projectile.velocity.SafeNormalize(Vector2.Zero);
                for (int num115 = 0; num115 < 1; num115 = num + 1)
                {
                    Dust dust14 = Dust.NewDustDirect(projectile.Center - projectile.Size / 4f, projectile.width / 2, projectile.height / 2, 89, 0f, 0f, 0, default(Color), 1f);
                    dust14.noGravity = true;
                    dust14.position = projectile.Center + vector15;
                    Dust dust3 = dust14;
                    dust3.velocity *= 0f;
                    dust14.fadeIn = 0.9f;
                    dust14.scale = 1.15f;
                    dust14.noLight = true;
                    dust3 = dust14;
                    dust3.position += projectile.velocity * 1.2f;
                    dust3 = dust14;
                    dust3.velocity += value16 * 2f;
                    dust14 = Dust.NewDustDirect(projectile.Center - projectile.Size / 4f, projectile.width / 2, projectile.height / 2, 89, 0f, 0f, 0, default(Color), 1f);
                    dust14.noGravity = true;
                    dust14.position = projectile.Center + vector15;
                    dust3 = dust14;
                    dust3.velocity *= 0f;
                    dust14.fadeIn = 0.9f;
                    dust14.scale = 1.15f;
                    dust14.noLight = true;
                    dust3 = dust14;
                    dust3.position += projectile.velocity * 0.5f;
                    dust3 = dust14;
                    dust3.position += projectile.velocity * 1.2f;
                    dust3 = dust14;
                    dust3.velocity += value16 * 2f;
                    num = num115;
                }
              
            }
        }
    }
}