using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class SkyShatterCircle : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Sky Shatter");
        }
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.timeLeft = 120;
            projectile.penetrate = 1;
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
            projectile.netUpdate = true;
            int num;
            projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;
            Player owner = Main.player[projectile.owner]; //Makes a player variable of owner set as the player using the projectile
            for (int l = 0; l < 12; l = num + 1)
            {
                Vector2 vector3 = Vector2.UnitX * -(float)projectile.width / 2f;
                vector3 += -Vector2.UnitY.RotatedBy((double)((float)l * 3.14159274f / 6f), default(Vector2)) * new Vector2(8f, 16f);
                vector3 = vector3.RotatedBy((double)(projectile.rotation - 1.57079637f), default(Vector2));
                int num9 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 132, 0f, 0f, projectile.alpha, default(Color), 1.5f);

                Main.dust[num9].scale = 1.4f;
                Main.dust[num9].noGravity = true;
                Main.dust[num9].position = projectile.Center + vector3;
                Main.dust[num9].velocity = projectile.velocity * 0.25f;
                Main.dust[num9].velocity = Vector2.Normalize(projectile.Center - projectile.velocity * 3f - Main.dust[num9].position) * 1.25f;
                num = l;
            }
            projectile.Kill();


        }
    }
}