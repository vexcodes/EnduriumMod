using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;

namespace EnduriumMod.NPCs.TheSpiritOfBloom
{
    public class LeafBurst : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Leaf Burst");
        }
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 36;
            projectile.tileCollide = false;
            projectile.hostile = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 370;
            projectile.aiStyle = 1;
            aiType = ProjectileID.Bullet;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D glowmask = Main.projectileTexture[projectile.type];
            int glownum = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
            int y7 = glownum * projectile.frame;
            Main.spriteBatch.Draw(glowmask, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y7, glowmask.Width, glownum)), projectile.GetAlpha(Color.White), projectile.rotation, new Vector2((float)glowmask.Width / 2f, (float)glownum / 2f), projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            return false;
        }
        public int Spaget = 0;
        public override void AI()
        {
            projectile.spriteDirection = projectile.direction;
            int num4324;
            int num;
            projectile.alpha = 255;
            for (int num20 = 0; num20 < 1; num20 = num4324 + 1)
            {
                float num21 = projectile.velocity.X / 4f * (float)num20;
                float num22 = projectile.velocity.Y / 4f * (float)num20;
                int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 89, 0f, 0f, 0, default(Color), 0.9f);
                Main.dust[num23].position.X = projectile.Center.X - num21;
                Main.dust[num23].position.Y = projectile.Center.Y - num22;
                Dust dust3 = Main.dust[num23];
                dust3.velocity *= 0.4f;
                Main.dust[num23].scale = 1.48f;
                Main.dust[num23].noGravity = true;
                num4324 = num20;
            }




            if (projectile.ai[1] == 1f && Main.netMode != 1)
            {
                int num3 = -1;
                float num4 = 2000f;
                for (int k = 0; k < 255; k = num + 1)
                {
                    if (Main.player[k].active && !Main.player[k].dead)
                    {
                        Vector2 center = Main.player[k].Center;
                        float num5 = Vector2.Distance(center, projectile.Center);
                        if ((num5 < num4 || num3 == -1) && Collision.CanHit(projectile.Center, 1, 1, center, 1, 1))
                        {
                            num4 = num5;
                            num3 = k;
                        }
                    }
                    num = k;
                }
                if (num4 < 20f)
                {
                    projectile.Kill();
                    return;
                }
                if (num3 != -1)
                {
                    projectile.ai[1] = 21f;
                    projectile.ai[0] = (float)num3;
                    projectile.netUpdate = true;
                }
            }
            else if (projectile.ai[1] > 20f && projectile.ai[1] < 200f)
            {
                projectile.ai[1] += 1f;
                int num6 = (int)projectile.ai[0];
                if (!Main.player[num6].active || Main.player[num6].dead)
                {
                    projectile.ai[1] = 1f;
                    projectile.ai[0] = 0f;
                    projectile.netUpdate = true;
                }
                else
                {
                    float num7 = projectile.velocity.ToRotation();
                    Vector2 vector2 = Main.player[num6].Center - projectile.Center;
                    if (vector2.Length() < 20f)
                    {
                        projectile.Kill();
                        return;
                    }
                    float targetAngle = vector2.ToRotation();
                    if (vector2 == Vector2.Zero)
                    {
                        targetAngle = num7;
                    }
                    float num8 = num7.AngleLerp(targetAngle, 0.008f);
                    projectile.velocity = new Vector2(projectile.velocity.Length(), 0f).RotatedBy((double)num8, default(Vector2));
                }
            }
            if (projectile.ai[1] >= 1f && projectile.ai[1] < 20f)
            {
                projectile.ai[1] += 1f;
                if (projectile.ai[1] == 20f)
                {
                    projectile.ai[1] = 1f;
                }
            }

            int num1300 = 10;
            for (int num1301 = 0; num1301 < 1; num1301 = num + 1)
            {
                int num1302 = Dust.NewDust(projectile.position - new Vector2((float)num1300), projectile.width + num1300 * 2, projectile.height + num1300 * 2, 89, 0f, 0f, 100, default(Color), 1f);
                Main.dust[num1302].noGravity = true;
                Main.dust[num1302].noLight = true;
                num = num1301;
            }

            if (projectile.ai[1] == 0f)
            {
                projectile.ai[1] = 1f;
                Main.PlaySound(SoundID.Item91, projectile.position);
            }
            if (Spaget == 0 && projectile.timeLeft < 290)
            {
                Player player = Main.player[Main.myPlayer];
                float closestDist = 10000;
                int chosenPlayer = Main.myPlayer;
                for (int i = 0; i < 255; i++)
                {
                    if (i == 0) closestDist = Vector2.Distance(Main.player[i].Center, projectile.Center);
                    else if (Vector2.Distance(Main.player[i].Center, projectile.Center) < closestDist)
                    {
                        closestDist = Vector2.Distance(Main.player[i].Center, projectile.Center);
                        chosenPlayer = i;
                    }
                }
                player = Main.player[chosenPlayer];
                projectile.velocity = Vector2.Normalize(player.Center - projectile.Center) * 13;

                for (int num621 = 0; num621 < 2; num621++)
                {
                    int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 89, 0f, 0f, 100, default(Color), 1.2f);
                    Main.dust[num622].velocity *= 3f;
                }

                Spaget += 1;
            }
        }
    }
}