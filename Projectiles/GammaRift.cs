using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class GammaRift : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gammaburst");
        }

        public override void SetDefaults()
        {
            projectile.width = 94;
            projectile.height = 94;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.tileCollide = false;
            projectile.penetrate = 6;
            projectile.alpha = 120;
            projectile.timeLeft = 4500;
            projectile.aiStyle = -1;
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
            target.immune[projectile.owner] = 4;
            Main.PlaySound(SoundID.Item62, projectile.position);
            int num3;
            for (int num731 = 0; num731 < 5; num731 = num3 + 1)
            {
                int num732 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 173, 0f, 0f, 100, default(Color), 2.5f);
                Main.dust[num732].noGravity = true;
                Dust dust = Main.dust[num732];
                dust.velocity *= 4f;
                num732 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 173, 0f, 0f, 100, default(Color), 1.5f);
                dust = Main.dust[num732];
                dust.velocity *= 2f;
                num3 = num731;
            }

        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 105);
            {
                projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
                projectile.width = 120;
                projectile.height = 120;
                projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
                int num3;
                for (int num731 = 0; num731 < 25; num731 = num3 + 1)
                {
                    int num732 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 173, 0f, 0f, 100, default(Color), 2.5f);
                    Main.dust[num732].noGravity = true;
                    Dust dust = Main.dust[num732];
                    dust.velocity *= 7f;
                    num732 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 173, 0f, 0f, 100, default(Color), 1.5f);
                    dust = Main.dust[num732];
                    dust.velocity *= 3f;
                    num3 = num731;
                }
            }
        }

        public override void AI()
        {
            projectile.scale += 0.003f;
            float num372 = projectile.position.X;
            float num373 = projectile.position.Y;
            float num374 = 100000f;
            bool flag10 = false;
            projectile.ai[0] += 1;
                int num3;
                for (int num375 = 0; num375 < 200; num375 = num3 + 1)
                {
                    if (Main.npc[num375].CanBeChasedBy(projectile, false))
                    {
                        float num376 = Main.npc[num375].position.X + (float)(Main.npc[num375].width / 2);
                        float num377 = Main.npc[num375].position.Y + (float)(Main.npc[num375].height / 2);
                        float num378 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num376) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num377);
                        if (num378 < 800f && num378 < num374 && Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[num375].position, Main.npc[num375].width, Main.npc[num375].height))
                        {
                            num374 = num378;
                            num372 = num376;
                            num373 = num377;
                            flag10 = true;
                        }
                    }
                    num3 = num375;
                }
            
            if (!flag10)
            {
                num372 = projectile.position.X + (float)(projectile.width / 2) + projectile.velocity.X * 250f;
                num373 = projectile.position.Y + (float)(projectile.height / 2) + projectile.velocity.Y * 250f;
            }
            float num379 = 7f;
            float num380 = 0.06f;
            Vector2 vector29 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
            float num381 = num372 - vector29.X;
            float num382 = num373 - vector29.Y;
            float num383 = (float)Math.Sqrt((double)(num381 * num381 + num382 * num382));
            num383 = num379 / num383;
            num381 *= num383;
            num382 *= num383;
            if (projectile.velocity.X < num381)
            {
                projectile.velocity.X = projectile.velocity.X + num380;
                if (projectile.velocity.X < 0f && num381 > 0f)
                {
                    projectile.velocity.X = projectile.velocity.X + num380 * 2f;
                }
            }
            else
            {
                if (projectile.velocity.X > num381)
                {
                    projectile.velocity.X = projectile.velocity.X - num380;
                    if (projectile.velocity.X > 0f && num381 < 0f)
                    {
                        projectile.velocity.X = projectile.velocity.X - num380 * 2f;
                    }
                }
            }
            if (projectile.velocity.Y < num382)
            {
                projectile.velocity.Y = projectile.velocity.Y + num380;
                if (projectile.velocity.Y < 0f && num382 > 0f)
                {
                    projectile.velocity.Y = projectile.velocity.Y + num380 * 2f;
                    return;
                }
            }
            else
            {
                if (projectile.velocity.Y > num382)
                {
                    projectile.velocity.Y = projectile.velocity.Y - num380;
                    if (projectile.velocity.Y > 0f && num382 < 0f)
                    {
                        projectile.velocity.Y = projectile.velocity.Y - num380 * 2f;
                        return;
                    }
                }
            }
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.05f) / 255f, ((255 - projectile.alpha) * 0.5f) / 255f, ((255 - projectile.alpha) * 0.75f) / 255f);
            projectile.rotation += 0.08f;
            projectile.ai[1] += 0.5f;
            if (projectile.ai[1] >= 10f && projectile.ai[1] <= 25f)
            {
                projectile.velocity.X *= 1.02f;
                projectile.velocity.Y *= 1.02f;
            }
            if (projectile.ai[1] >= 35f)
            {
                projectile.velocity.X *= 0.96f;
                projectile.velocity.Y *= 0.96f;
            }
            if (projectile.ai[1] <= 35f)
            {
                if (projectile.alpha > 40)
                {
                    projectile.alpha -= 2;
                }
            }
            if (projectile.ai[1] >= 10f)
            {
                int drust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 173, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[drust].velocity *= 1f;
                Main.dust[drust].fadeIn *= 1.8f;
                Main.dust[drust].noGravity = true;

                int drust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 173, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[drust2].velocity *= 4f;
                Main.dust[drust2].fadeIn *= 2.8f;
                Main.dust[drust2].noGravity = true;
                projectile.rotation += 0.03f;
            }
            if (projectile.ai[1] >= 20f)
            {
                projectile.rotation += 0.03f;
            }
            if (projectile.ai[1] >= 40f)
            {
                projectile.rotation += 0.03f;
            }
            if (projectile.ai[1] >= 80f)
            {
                projectile.rotation += 0.03f;
                projectile.alpha += 2;
            }
            if (projectile.ai[1] >= 120f)
            {
                projectile.Kill();
            }
        }
    }
}