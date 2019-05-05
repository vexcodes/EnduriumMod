using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class AccretionArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Accretion Arrow");
        }

        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 48;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.tileCollide = false;
            projectile.penetrate = 2;
            projectile.alpha = 120;
            projectile.timeLeft = 200;
            projectile.aiStyle = -1;
            projectile.extraUpdates = 1;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D glowmask = Main.projectileTexture[projectile.type];
            int glownum = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
            int y7 = glownum * projectile.frame;
            Main.spriteBatch.Draw(glowmask, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y7, glowmask.Width, glownum)), projectile.GetAlpha(Color.White), projectile.rotation, new Vector2((float)glowmask.Width / 2f, (float)glownum / 2f), projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            target.AddBuff(mod.BuffType("AccretionBurn"), 300);
            target.immune[projectile.owner] = 1;
            Main.PlaySound(SoundID.Item62, projectile.position);
            int num3;
            for (int num731 = 0; num731 < 7; num731 = num3 + 1)
            {
                int num732 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 90, 0f, 0f, 100, default(Color), 1.2f);
                Main.dust[num732].noGravity = true;
                Dust dust = Main.dust[num732];
                dust.velocity *= 1.8f;
                num3 = num731;
            }

        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 105);
            {
                projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
                projectile.width = 30;
                projectile.height = 30;
                projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
                int num3;
                for (int num731 = 0; num731 < 18; num731 = num3 + 1)
                {
                    int num732 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 90, 0f, 0f, 100, default(Color), 2.5f);
                    Main.dust[num732].noGravity = true;
                    Dust dust = Main.dust[num732];
                    dust.velocity *= 4f;
                    num732 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 90, 0f, 0f, 100, default(Color), 1.5f);
                    dust = Main.dust[num732];
                    dust.velocity *= 1f;
                    num3 = num731;
                }
            }
        }

        public override void AI()
        {
            int num3 = -1;
            if (projectile.ai[0] == 8f)
            {
                for (int num633 = 0; num633 < 4; num633 = num3 + 1)
                {
                    int num634 = Utils.SelectRandom<int>(Main.rand, new int[]
                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                226,
                                                                                                                                                                                                                                                228,
                                                                                                                                                                                                                                                75
                                                                                                                                                                                                                                            });
                    int num635 = Dust.NewDust(projectile.Center, 0, 0, 90, 0f, 0f, 0, default(Color), 1f);
                    Dust dust80 = Main.dust[num635];
                    Vector2 value12 = Vector2.One.RotatedBy((double)((float)num633 * 1.57079637f), default(Vector2)).RotatedBy((double)projectile.rotation, default(Vector2));
                    dust80.position = projectile.Center + value12;
                    dust80.velocity = value12 * 1f;
                    dust80.scale = 0.6f + Main.rand.NextFloat() * 0.5f;
                    dust80.noGravity = true;
                    num3 = num633;
                }
            }

            {
                float num29 = 5f;
                float num30 = 250f;
                float scaleFactor = 6f;
                Vector2 value7 = new Vector2(8f, 10f);
                float num31 = 1.2f;
                Vector3 rgb = new Vector3(0.7f, 0.1f, 0.5f);
                int num32 = 4 * projectile.MaxUpdates;
                int num33 = Utils.SelectRandom<int>(Main.rand, new int[]
                {
                    242,
                    73,
                    72,
                    71,
                    255
                });
                int num34 = 255;
                int num;
                if (projectile.ai[1] == 0f)
                {
                    int num003;
                    projectile.ai[1] = 1f;
                    projectile.localAI[0] = -(float)Main.rand.Next(48);
                    Main.PlaySound(SoundID.Item34, projectile.position);
                    for (int num731 = 0; num731 < 12; num731 = num003 + 1)
                    {
                        int num732 = Dust.NewDust(projectile.Center, 0, 0, 90, 0f, 0f, 100, default(Color), 1.5f);
                        Main.dust[num732].noGravity = true;
                        Dust dust = Main.dust[num732];
                        dust.velocity *= 3f;
                        num732 = Dust.NewDust(projectile.Center, 0, 0, 90, 0f, 0f, 100, default(Color), 0.5f);
                        dust = Main.dust[num732];
                        dust.velocity *= 1f;
                        num003 = num731;
                    }
                }

                if (projectile.ai[1] >= 1f && projectile.ai[1] < num29)
                {
                    projectile.ai[1] += 1f;
                    if (projectile.ai[1] == num29)
                    {
                        projectile.ai[1] = 1f;
                    }
                }
                projectile.alpha -= 40;
                if (projectile.alpha < 0)
                {
                    projectile.alpha = 0;
                }
                projectile.spriteDirection = projectile.direction;
                num = projectile.frameCounter;
                projectile.frameCounter = num + 1;
                projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;
                Lighting.AddLight(projectile.Center, rgb);
                projectile.localAI[0] += 1f;
                if (projectile.localAI[0] == 48f)
                {
                    projectile.localAI[0] = 0f;
                }
                else
                {
                    if (projectile.alpha == 0)
                    {
                        for (int num41 = 0; num41 < 2; num41 = num + 1)
                        {
                            Vector2 value8 = Vector2.UnitX * 35f;
                            value8 = -Vector2.UnitY.RotatedBy((double)(projectile.localAI[0] * 0.1308997f + (float)num41 * 3.14159274f), default(Vector2)) * value7 - projectile.rotation.ToRotationVector2() * 10f;
                            int num42 = Dust.NewDust(projectile.Center, projectile.width / 2, projectile.height / 2, 90, 0f, 0f, 160, default(Color), 1f);
                            Main.dust[num42].scale = num31;
                            Main.dust[num42].noGravity = true;
                            Main.dust[num42].position = projectile.Center - value8;
                            Main.dust[num42].velocity = Vector2.Normalize(projectile.Center + projectile.velocity * 2.5f * 12f - Main.dust[num42].position) * 2.5f + projectile.velocity * 2.5f;
                            num = num41;
                        }
                    }
                }
            }
        }
    }
}