using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class SoulPurge : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul Purge");
        }
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 22;
            projectile.timeLeft = 120;
            projectile.penetrate = 2;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = false;
            projectile.magic = true;
            projectile.alpha = 20;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(5) == 0)
            {
                target.AddBuff(mod.BuffType("Purge"), 600);
            }
            if (target.life <= 0)
            {
                int num414 = (int)(projectile.position.X);
                Main.PlaySound(SoundID.Item62, projectile.position);
                int num415 = (int)(projectile.position.Y);
                Projectile.NewProjectile((float)num414, (float)num415, 0f, 0f, mod.ProjectileType("PurgeRecover"), 0, 0f, Main.myPlayer);
                projectile.netUpdate = true;
            }

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
            projectile.velocity.X *= 0.99f;
            projectile.velocity.Y *= 0.99f;


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
            int num;
            for (int num1446 = 0; num1446 < 20; num1446 = num + 1)
            {
                int num1447 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 173, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 90, default(Color), 2.5f);
                Main.dust[num1447].noGravity = true;
                Main.dust[num1447].fadeIn = 1f;
                Dust dust3 = Main.dust[num1447];
                dust3.velocity *= 4f;
                Main.dust[num1447].noLight = true;
                num = num1446;
            }
        }
    }
}