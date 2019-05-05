using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class ErodedEnergy : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 24;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 800;
            projectile.light = 0.25f;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 2;
            ProjectileID.Sets.TrailingMode[projectile.type] = 5;
            aiType = 48;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eroded Energy");
        }

        public override void AI()
        {
            {
                if (projectile.wet)
                {
                    projectile.Kill();
                    return;
                }
                int num;
                if (projectile.localAI[1] == 0f)
                {
                    projectile.localAI[1] += 1f;
                    Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 43);
                    for (int num113 = 0; num113 < 15; num113 = num + 1)
                    {
                        if (Main.rand.Next(4) != 0)
                        {
                            Dust dust12 = Dust.NewDustDirect(projectile.Center - projectile.Size / 4f, projectile.width / 2, projectile.height / 2, Utils.SelectRandom<int>(Main.rand, new int[]
                            {
                                21,
                                21,
                                21
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
                if (projectile.alpha <= 0)
                {
                    
                    Vector2 vector15 = new Vector2(0f, (float)Math.Cos((double)((float)projectile.frameCounter * 6.28318548f / 40f - 1.57079637f))) * 16f;
                    vector15 = vector15.RotatedBy((double)projectile.rotation, default(Vector2));
                    Vector2 value16 = projectile.velocity.SafeNormalize(Vector2.Zero);
                    for (int num115 = 0; num115 < 1; num115 = num + 1)
                    {
                        Dust dust14 = Dust.NewDustDirect(projectile.Center - projectile.Size / 4f, projectile.width / 2, projectile.height / 2, 21, 0f, 0f, 0, default(Color), 1f);
                        dust14.noGravity = true;
                        dust14.position = projectile.Center + vector15;
                        Dust dust3 = dust14;
                        dust3.velocity *= 0f;
                        dust14.fadeIn = 1.4f;
                        dust14.scale = 1.15f;
                        dust14.noLight = true;
                        dust3 = dust14;
                        dust3.position += projectile.velocity * 1.2f;
                        dust3 = dust14;
                        dust3.velocity += value16 * 2f;
                        dust14 = Dust.NewDustDirect(projectile.Center - projectile.Size / 4f, projectile.width / 2, projectile.height / 2, 21, 0f, 0f, 0, default(Color), 1f);
                        dust14.noGravity = true;
                        dust14.position = projectile.Center + vector15;
                        dust3 = dust14;
                        dust3.velocity *= 0f;
                        dust14.fadeIn = 1.4f;
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
                num = projectile.frameCounter + 1;
                projectile.frameCounter = num;
                if (num >= 40)
                {
                    projectile.frameCounter = 0;
                }
                projectile.frame = projectile.frameCounter / 5;
                if (projectile.alpha > 0)
                {
                    projectile.alpha -= 55;
                    if (projectile.alpha < 0)
                    {
                        projectile.alpha = 0;
                        float num116 = 16f;
                        int num117 = 0;
                        while ((float)num117 < num116)
                        {
                            Vector2 vector16 = Vector2.UnitX * 0f;
                            vector16 += -Vector2.UnitY.RotatedBy((double)((float)num117 * (6.28318548f / num116)), default(Vector2)) * new Vector2(1f, 4f);
                            vector16 = vector16.RotatedBy((double)projectile.velocity.ToRotation(), default(Vector2));
                            int num118 = Dust.NewDust(projectile.Center, 0, 0, 21, 0f, 0f, 0, default(Color), 1f);
                            Main.dust[num118].scale = 1.5f;
                            Main.dust[num118].noLight = true;
                            Main.dust[num118].noGravity = true;
                            Main.dust[num118].position = projectile.Center + vector16;
                            Main.dust[num118].velocity = Main.dust[num118].velocity * 4f;
                            num = num117;
                            num117 = num + 1;
                        }
                    }
                }
                DelegateMethods.v3_1 = new Vector3(1f, 0.6f, 0.2f);
                Utils.PlotTileLine(projectile.Center, projectile.Center + projectile.velocity * 4f, 40f, new Utils.PerLinePoint(DelegateMethods.CastLightOpen));
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 12; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 45, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.3f);
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int num3;
            if (Main.rand.Next(3) == 0)
            {
                if (projectile.owner == Main.myPlayer)
                {
                    int num626 = 2;
                    if (Main.rand.Next(4) == 0)
                    {
                        num3 = num626;
                        num626 = num3 + 1;
                    }
                    if (Main.rand.Next(4) == 0)
                    {
                        num3 = num626;
                        num626 = num3 + 1;
                    }
                    if (Main.rand.Next(4) == 0)
                    {
                        num3 = num626;
                        num626 = num3 + 1;
                    }
                    for (int num627 = 0; num627 < num626; num627 = num3 + 5)
                    {
                        float num628 = (float)Main.rand.Next(-35, 36) * 0.02f;
                        float num629 = (float)Main.rand.Next(-35, 36) * 0.02f;
                        num628 *= 20f;
                        num629 *= 20f;
                        Projectile.NewProjectile(projectile.position.X, projectile.position.Y, num628, num629, mod.ProjectileType("ErodedBolt"), (int)((double)projectile.damage * 0.75), (float)((int)((double)projectile.knockBack * 0.35)), Main.myPlayer, 0f, 0f);
                        num3 = num627;
                    }
                }
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }
    }
}
