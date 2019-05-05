using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class Dark45 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Round");
        }
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 26;
            projectile.timeLeft = 110;
            projectile.penetrate = 1;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.hostile = false;
            aiType = ProjectileID.Bullet;
            projectile.tileCollide = true;
            projectile.ignoreWater = false;
            projectile.magic = true;
            projectile.alpha = 20;
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
            int num3;
            int num;
            if (projectile.ai[1] == 0f)
            {
                int num003;
                projectile.ai[1] = 1f;
                projectile.localAI[0] = -(float)Main.rand.Next(48);
                Main.PlaySound(SoundID.Item34, projectile.position);
                for (int num731 = 0; num731 < 12; num731 = num003 + 1)
                {
                    int num732 = Dust.NewDust(projectile.Center, 0, 0, 242, 0f, 0f, 100, default(Color), 1.5f);
                    Main.dust[num732].noGravity = true;
                    Dust dust = Main.dust[num732];
                    dust.velocity *= 3f;
                    num732 = Dust.NewDust(projectile.Center, 0, 0, 242, 0f, 0f, 100, default(Color), 0.5f);
                    dust = Main.dust[num732];
                    dust.velocity *= 1f;
                    num003 = num731;
                }
            }
            projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;

            Player owner = Main.player[projectile.owner]; //Makes a player variable of owner set as the player using the projectile

            float num372 = projectile.position.X;
            float num373 = projectile.position.Y;
            float num374 = 100000f;
            bool flag10 = false;

            for (int num375 = 0; num375 < 200; num375 = num3 + 1)
            {
                if (Main.npc[num375].CanBeChasedBy(projectile, false) && (!Main.npc[num375].wet || projectile.type == 307))
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
            if (flag10)
            {
                projectile.friendly = true;

                float num379 = 14f;
                float num380 = 0.28f;
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
                else if (projectile.velocity.X > num381)
                {
                    projectile.velocity.X = projectile.velocity.X - num380;
                    if (projectile.velocity.X > 0f && num381 < 0f)
                    {
                        projectile.velocity.X = projectile.velocity.X - num380 * 2f;
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
                else if (projectile.velocity.Y > num382)
                {
                    projectile.velocity.Y = projectile.velocity.Y - num380;
                    if (projectile.velocity.Y > 0f && num382 < 0f)
                    {
                        projectile.velocity.Y = projectile.velocity.Y - num380 * 2f;
                        return;
                    }
                }
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();

            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1, 1f, 0f);
            return true;
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 4; i < 31; i++)
            {
                float x = projectile.oldVelocity.X * (20f / i);
                float y = projectile.oldVelocity.Y * (20f / i);
                int newDust = Dust.NewDust(new Vector2(projectile.oldPosition.X - x, projectile.oldPosition.Y - y), 8, 8, 242, projectile.oldVelocity.X, projectile.oldVelocity.Y, 58, default(Color), 2.2f);
                Main.dust[newDust].noGravity = true;
                Main.dust[newDust].velocity *= 0.5f;
            }
        }
    }
}