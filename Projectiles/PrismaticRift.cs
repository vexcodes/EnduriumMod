using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class PrismaticRift : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prismatic Rift");
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.tileCollide = false;
            projectile.penetrate = 2;
            projectile.aiStyle = 0;
            projectile.timeLeft = 4500;
        }
        public override bool? CanHitNPC(NPC target)
        {
            return false;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D glowmask = Main.projectileTexture[projectile.type];
            int glownum = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
            int y7 = glownum * projectile.frame;
            Main.spriteBatch.Draw(glowmask, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y7, glowmask.Width, glownum)), projectile.GetAlpha(Color.White), projectile.rotation, new Vector2((float)glowmask.Width / 2f, (float)glownum / 2f), projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            return false;
        }
        public override void AI()
        {
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.05f) / 255f, ((255 - projectile.alpha) * 0.5f) / 255f, ((255 - projectile.alpha) * 0.75f) / 255f);
            {
                projectile.ai[0] += 1f;
                if (projectile.ai[0] <= 50f)
                {
                    if (Main.rand.Next(4) == 0)
                    {
                        Vector2 vector119 = Vector2.UnitY.RotatedByRandom(6.2831854820251465);
                        Dust dust108 = Main.dust[Dust.NewDust(projectile.Center - vector119 * 30f, 0, 0, 229, 0f, 0f, 100, default(Color), 1f)];
                        dust108.noGravity = true;
                        dust108.position = projectile.Center - vector119 * (float)Main.rand.Next(10, 21);
                        dust108.velocity = vector119.RotatedBy(1.5707963705062866, default(Vector2)) * 4f;
                        dust108.scale = 0.5f + Main.rand.NextFloat();
                        dust108.fadeIn = 0.5f;
                    }
                    if (Main.rand.Next(4) == 0)
                    {
                        Vector2 vector120 = Vector2.UnitY.RotatedByRandom(6.2831854820251465);
                        Dust dust109 = Main.dust[Dust.NewDust(projectile.Center - vector120 * 30f, 0, 0, 89, 0f, 0f, 100, default(Color), 1f)];
                        dust109.noGravity = true;
                        dust109.position = projectile.Center - vector120 * 30f;
                        dust109.velocity = vector120.RotatedBy(-1.5707963705062866, default(Vector2)) * 2f;
                        dust109.scale = 0.5f + Main.rand.NextFloat();
                        dust109.fadeIn = 0.5f;
                    }

                }
                else if (projectile.ai[0] <= 90f)
                {
                    projectile.scale = (projectile.ai[0] - 50f) / 40f;
                    projectile.alpha = 255 - (int)(255f * projectile.scale);
                    projectile.rotation -= 0.157079637f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Vector2 vector124 = Vector2.UnitY.RotatedByRandom(6.2831854820251465);
                        Dust dust111 = Main.dust[Dust.NewDust(projectile.Center - vector124 * 30f, 0, 0, 229, 0f, 0f, 100, default(Color), 1f)];
                        dust111.noGravity = true;
                        dust111.position = projectile.Center - vector124 * (float)Main.rand.Next(10, 21);
                        dust111.velocity = vector124.RotatedBy(1.5707963705062866, default(Vector2)) * 6f;
                        dust111.scale = 0.5f + Main.rand.NextFloat();
                        dust111.fadeIn = 0.5f;
                        dust111.customData = projectile.Center;
                    }
                    if (Main.rand.Next(2) == 0)
                    {
                        Vector2 vector125 = Vector2.UnitY.RotatedByRandom(6.2831854820251465);
                        Dust dust112 = Main.dust[Dust.NewDust(projectile.Center - vector125 * 30f, 0, 0, 89, 0f, 0f, 100, default(Color), 1f)];
                        dust112.noGravity = true;
                        dust112.position = projectile.Center - vector125 * 30f;
                        dust112.velocity = vector125.RotatedBy(-1.5707963705062866, default(Vector2)) * 3f;
                        dust112.scale = 0.5f + Main.rand.NextFloat();
                        dust112.fadeIn = 0.5f;
                        dust112.customData = projectile.Center;
                    }

                }
                else
                {
                    if (projectile.ai[0] > 120f)
                    {
                        projectile.scale = 1f - (projectile.ai[0] - 120f) / 60f;
                        projectile.alpha = 255 - (int)(255f * projectile.scale);
                        projectile.rotation -= 0.104719758f;
                        if (projectile.alpha >= 255)
                        {
                            int[] array = new int[20];
                            int num433 = 0;
                            float num434 = 10000f;
                            bool flag14 = false;
                            int num3 = projectile.frameCounter;
                            for (int num435 = 0; num435 < 200; num435 = num3 + 1)
                            {
                                if (Main.npc[num435].CanBeChasedBy(projectile, false))
                                {
                                    float num436 = Main.npc[num435].position.X + (float)(Main.npc[num435].width / 2);
                                    float num437 = Main.npc[num435].position.Y + (float)(Main.npc[num435].height / 2);
                                    float num438 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num436) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num437);
                                    if (num438 < num434 && Collision.CanHit(projectile.Center, 1, 1, Main.npc[num435].Center, 1, 1))
                                    {
                                        if (num433 < 20)
                                        {
                                            array[num433] = num435;
                                            num3 = num433;
                                            num433 = num3 + 1;
                                        }
                                        flag14 = true;
                                    }
                                }
                                num3 = num435;
                            }
                            if (flag14)
                            {
                                int num439 = Main.rand.Next(num433);
                                num439 = array[num439];
                                float num440 = Main.npc[num439].position.X + (float)(Main.npc[num439].width / 2);
                                float num441 = Main.npc[num439].position.Y + (float)(Main.npc[num439].height / 2);
                                projectile.localAI[0] += 1f;
                                projectile.penetrate--;
                                projectile.localAI[0] = 0f;
                                float num442 = 6f;
                                Vector2 vector32 = new Vector2(projectile.position.X + (float)projectile.width, projectile.position.Y + (float)projectile.height);
                                vector32 += projectile.velocity * 4f;
                                float num443 = num440 - vector32.X;
                                float num444 = num441 - vector32.Y;
                                float num445 = (float)Math.Sqrt((double)(num443 * num443 + num444 * num444));
                                num445 = num442 / num445;
                                num443 *= num445;
                                num444 *= num445;
                                int num1111 = Projectile.NewProjectile(vector32.X, vector32.Y, num443, num444, mod.ProjectileType("CosmicDischarge"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
                                Main.projectile[num1111].penetrate = 1;
                            }
                            Main.PlaySound(3, (int)projectile.position.X, (int)projectile.position.Y, 53);
                            projectile.Kill();
                        }
                        int num4;
                        for (int num961 = 0; num961 < 2; num961 = num4 + 1)
                        {
                            int num962 = Main.rand.Next(3);
                            if (num962 == 0)
                            {
                                Vector2 vector129 = Vector2.UnitY.RotatedByRandom(6.2831854820251465) * projectile.scale;
                                Dust dust114 = Main.dust[Dust.NewDust(projectile.Center - vector129 * 30f, 0, 0, 229, 0f, 0f, 100, default(Color), 1f)];
                                dust114.noGravity = true;
                                dust114.position = projectile.Center - vector129 * (float)Main.rand.Next(10, 21);
                                dust114.velocity = vector129.RotatedBy(1.5707963705062866, default(Vector2)) * 6f;
                                dust114.scale = 0.5f + Main.rand.NextFloat();
                                dust114.fadeIn = 0.5f;
                                dust114.customData = projectile.Center;
                            }
                            else if (num962 == 1)
                            {
                                Vector2 vector130 = Vector2.UnitY.RotatedByRandom(6.2831854820251465) * projectile.scale;
                                Dust dust115 = Main.dust[Dust.NewDust(projectile.Center - vector130 * 30f, 0, 0, 89, 0f, 0f, 100, default(Color), 1f)];
                                dust115.noGravity = true;
                                dust115.position = projectile.Center - vector130 * 30f;
                                dust115.velocity = vector130.RotatedBy(-1.5707963705062866, default(Vector2)) * 3f;
                                dust115.scale = 0.5f + Main.rand.NextFloat();
                                dust115.fadeIn = 0.5f;
                                dust115.customData = projectile.Center;
                            }
                            num4 = num961;
                        }
                        return;
                    }
                    projectile.scale = 1f;
                    projectile.alpha = 0;
                    projectile.rotation -= 0.05235988f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Vector2 vector131 = Vector2.UnitY.RotatedByRandom(6.2831854820251465);
                        Dust dust116 = Main.dust[Dust.NewDust(projectile.Center - vector131 * 30f, 0, 0, 229, 0f, 0f, 100, default(Color), 1f)];
                        dust116.noGravity = true;
                        dust116.position = projectile.Center - vector131 * (float)Main.rand.Next(10, 21);
                        dust116.velocity = vector131.RotatedBy(1.5707963705062866, default(Vector2)) * 6f;
                        dust116.scale = 0.5f + Main.rand.NextFloat();
                        dust116.fadeIn = 0.5f;
                        dust116.customData = projectile.Center;
                        return;
                    }
                    Vector2 vector132 = Vector2.UnitY.RotatedByRandom(6.2831854820251465);
                    Dust dust117 = Main.dust[Dust.NewDust(projectile.Center - vector132 * 30f, 0, 0, 89, 0f, 0f, 100, default(Color), 1f)];
                    dust117.noGravity = true;
                    dust117.position = projectile.Center - vector132 * 30f;
                    dust117.velocity = vector132.RotatedBy(-1.5707963705062866, default(Vector2)) * 3f;
                    dust117.scale = 0.5f + Main.rand.NextFloat();
                    dust117.fadeIn = 0.5f;
                    dust117.customData = projectile.Center;
                    return;
                }
            }
        }
    }
}