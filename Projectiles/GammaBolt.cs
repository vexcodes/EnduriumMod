using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class GammaBolt : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gammaburst");
        }

        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 24;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.tileCollide = true;
            projectile.penetrate = 3;
            projectile.alpha = 120;
            projectile.timeLeft = 200;
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
            target.immune[projectile.owner] = 1;
            Main.PlaySound(SoundID.Item62, projectile.position);
            int num3;
            for (int num731 = 0; num731 < 7; num731 = num3 + 1)
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
                projectile.width = 60;
                projectile.height = 60;
                projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
                int num3;
                for (int num731 = 0; num731 < 18; num731 = num3 + 1)
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
            int num3;
            int num323 = (int)projectile.ai[0];
            for (int num324 = 0; num324 < 4; num324 = num3 + 1)
            {
                int num325 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 173, projectile.velocity.X, projectile.velocity.Y, num323, default(Color), 1.2f);
                Main.dust[num325].position = (Main.dust[num325].position + projectile.Center) / 2f;
                Main.dust[num325].noGravity = true;
                Dust dust3 = Main.dust[num325];
                dust3.velocity *= 0.5f;
                num3 = num324;
            }
            for (int num326 = 0; num326 < 3; num326 = num3 + 1)
            {
                int num327 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 173, projectile.velocity.X, projectile.velocity.Y, num323, default(Color), 0.4f);
                if (num326 == 0)
                {
                    Main.dust[num327].position = (Main.dust[num327].position + projectile.Center * 5f) / 6f;
                }
                else
                {
                    if (num326 == 1)
                    {
                        Main.dust[num327].position = (Main.dust[num327].position + (projectile.Center + projectile.velocity / 2f) * 5f) / 6f;
                    }
                }
                Dust dust3 = Main.dust[num327];
                dust3.velocity *= 0.1f;
                Main.dust[num327].noGravity = true;
                Main.dust[num327].fadeIn = 1f;
                num3 = num326;
            }
            return;

        }
    }
}