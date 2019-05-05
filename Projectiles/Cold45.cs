using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class Cold45 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Round");
        }
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 26;
            projectile.timeLeft = 70;
            projectile.penetrate = 2;
            aiType = ProjectileID.Bullet;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.hostile = false;
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
            int num;
            if (projectile.ai[1] == 0f)
            {
                int num003;
                projectile.ai[1] = 1f;
                projectile.localAI[0] = -(float)Main.rand.Next(48);
                Main.PlaySound(SoundID.Item34, projectile.position);
                for (int num731 = 0; num731 < 6; num731 = num003 + 1)
                {
                    int num732 = Dust.NewDust(projectile.Center, 0, 0, 156, 0f, 0f, 100, default(Color), 1.5f);
                    Main.dust[num732].noGravity = true;
                    Dust dust = Main.dust[num732];
                    dust.velocity *= 3f;
                    num732 = Dust.NewDust(projectile.Center, 0, 0, 156, 0f, 0f, 100, default(Color), 0.5f);
                    dust = Main.dust[num732];
                    dust.velocity *= 1f;
                    num003 = num731;
                }
            }
            projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;

            Player owner = Main.player[projectile.owner]; //Makes a player variable of owner set as the player using the projectile
            {
                if (projectile.alpha <= 240)
                {
                    projectile.alpha += 2;
                }
                if (projectile.alpha >= 240)
                {
                    projectile.Kill();
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
                int newDust = Dust.NewDust(new Vector2(projectile.oldPosition.X - x, projectile.oldPosition.Y - y), 8, 8, 156, projectile.oldVelocity.X, projectile.oldVelocity.Y, 58, default(Color), 2.2f);
                Main.dust[newDust].noGravity = true;
                Main.dust[newDust].velocity *= 0.5f;
            }
        }
    }
}