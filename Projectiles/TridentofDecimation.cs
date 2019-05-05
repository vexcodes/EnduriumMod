using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{	
	public class TridentofDecimation : ModProjectile 
	{		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Trident of Decimation");
		}
		public override void SetDefaults()
		{
			projectile.width = 74; 
			projectile.height = 74;
			projectile.timeLeft = 350;
			projectile.penetrate = 7;
			projectile.friendly = true; 
			projectile.hostile = false; 
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.thrown = true;
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
            target.AddBuff(mod.BuffType("AccretionBurn"), 300);

            target.immune[projectile.owner] = 2;
            float positionX = target.position.X + (float)(target.width / 2);
            float positionY = target.position.Y - (float)(target.height / 2);
            Projectile.NewProjectile(positionX, target.position.Y + (float)(target.height / 2), 3f, 3f, mod.ProjectileType("AccretionBolt"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
            Projectile.NewProjectile(positionX, target.position.Y + (float)(target.height / 2), 3f, -3f, mod.ProjectileType("AccretionBolt"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
            Projectile.NewProjectile(positionX, target.position.Y + (float)(target.height / 2), -3f, 3f, mod.ProjectileType("AccretionBolt"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
            Projectile.NewProjectile(positionX, target.position.Y + (float)(target.height / 2), -3f, -3f, mod.ProjectileType("AccretionBolt"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
        }

        public override void AI()
        {
            Player owner = Main.player[projectile.owner];
            projectile.rotation = projectile.velocity.ToRotation() + 0.7853982f;
            {
                if (projectile.alpha < 170)
                {
                    int drust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 90, 0f, 0f, 100, default(Color), 1.5f);
                    Main.dust[drust].velocity *= 1f;
                    Main.dust[drust].fadeIn *= 1.2f;
                    Main.dust[drust].noGravity = true;
                }
            }                                         
		}

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 105);
            {
                projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
                projectile.width = 84;
                projectile.height = 84;
                projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
                int num3;
                for (int num731 = 0; num731 < 5; num731 = num3 + 1)
                {
                    int num732 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 90, 0f, 0f, 100, default(Color), 2.5f);
                    Main.dust[num732].noGravity = true;
                    Dust dust = Main.dust[num732];
                    dust.velocity *= 7f;
                    num732 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 90, 0f, 0f, 100, default(Color), 1.5f);
                    dust = Main.dust[num732];
                    dust.velocity *= 3f;
                    num3 = num731;
                }
            }
        }
    } 
}