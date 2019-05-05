using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class Ice : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 40;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 400;
            Main.projFrames[projectile.type] = 6;
            projectile.light = 0.0f;
            projectile.extraUpdates = 1;
            projectile.ignoreWater = true;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D glowmask = Main.projectileTexture[projectile.type];
            int glownum = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
            int y7 = glownum * projectile.frame;
            Main.spriteBatch.Draw(glowmask, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y7, glowmask.Width, glownum)), projectile.GetAlpha(Color.White), projectile.rotation, new Vector2((float)glowmask.Width / 2f, (float)glownum / 2f), projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            return false;
        }
        public int pleaseworkbastard = 0;
        public override void AI()
        {
            if (pleaseworkbastard == 0)
            {
                pleaseworkbastard += 1;
                projectile.frame = Main.rand.Next(6);
            }
            int num;
            projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;
            int a = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 156, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.dust[a].noGravity = true;
            Main.dust[a].velocity *= 0.15f;
            Main.dust[a].scale *= 0.4f;
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
        public override void Kill(int timeLeft)
        {
            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 18;
            projectile.height = 18;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            int num3;
            for (int num731 = 0; num731 < 6; num731 = num3 + 1)
            {
                int num732 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 156, 0f, 0f, 100, default(Color), 1.2f);
                Main.dust[num732].noGravity = true;
                Dust dust = Main.dust[num732];
                dust.velocity *= 0.65f;
                num3 = num731;
            }
        }
    }
}