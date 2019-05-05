using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{	
	public class AccretionOrb : ModProjectile 
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Accretion Orb");
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
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 1;
            target.AddBuff(mod.BuffType("AccretionBurn"), 300);
            //target.immune[projectile.owner] = 69lolfuckmyass;
        }

        public override void AI()
        {
            int num;
            if (projectile.alpha < 100)
            {
                projectile.velocity.X *= 1.04f;
                projectile.velocity.Y *= 1.04f;
            }

            projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;

            Player owner = Main.player[projectile.owner]; //Makes a player variable of owner set as the player using the projectile

            if (projectile.alpha < 240)
            {
                projectile.localAI[0] += 1f;
                if (projectile.localAI[0] >= 24f)
                {
                    projectile.localAI[0] = 0f;
                    for (int l = 0; l < 12; l = num + 1)
                    {
                        Vector2 vector3 = Vector2.UnitX * -(float)projectile.width / 2f;
                        vector3 += -Vector2.UnitY.RotatedBy((double)((float)l * 3.14159274f / 6f), default(Vector2)) * new Vector2(8f, 16f);
                        vector3 = vector3.RotatedBy((double)(projectile.rotation - 1.57079637f), default(Vector2));
                        int num9 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 90, 0f, 0f, projectile.alpha, default(Color), 1.5f);

                        Main.dust[num9].scale = 1.4f;
                        Main.dust[num9].noGravity = true;
                        Main.dust[num9].position = projectile.Center + vector3;
                        Main.dust[num9].velocity = projectile.velocity * 0.25f;
                        Main.dust[num9].velocity = Vector2.Normalize(projectile.Center - projectile.velocity * 3f - Main.dust[num9].position) * 1.25f;
                        num = l;
                    }
                }
            }
            if (projectile.alpha <= 240)
            {
                projectile.alpha += 2;
            }
            if (projectile.alpha >= 240)
            {
                projectile.Kill();
            }
            if (projectile.alpha > 50)
            {
                float num166 = (float)Math.Sqrt((double)(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y));
                float num167 = projectile.localAI[0];
                if (num167 == 0f)
                {
                    projectile.localAI[0] = num166;
                    num167 = num166;
                }
                float num168 = projectile.position.X;
                float num169 = projectile.position.Y;
                float num170 = 300f;
                bool flag4 = false;
                int num171 = 0;
                if (projectile.ai[1] == 0f)
                {
                    for (int num172 = 0; num172 < 200; num172 = num + 1)
                    {
                        if (Main.npc[num172].CanBeChasedBy(projectile, false) && (projectile.ai[1] == 0f || projectile.ai[1] == (float)(num172 + 1)))
                        {
                            float num173 = Main.npc[num172].position.X + (float)(Main.npc[num172].width / 2);
                            float num174 = Main.npc[num172].position.Y + (float)(Main.npc[num172].height / 2);
                            float num175 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num173) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num174);
                            if (num175 < num170 && Collision.CanHit(new Vector2(projectile.position.X + (float)(projectile.width / 2), projectile.position.Y + (float)(projectile.height / 2)), 1, 1, Main.npc[num172].position, Main.npc[num172].width, Main.npc[num172].height))
                            {
                                num170 = num175;
                                num168 = num173;
                                num169 = num174;
                                flag4 = true;
                                num171 = num172;
                            }
                        }
                        num = num172;
                    }
                    if (flag4)
                    {
                        projectile.ai[1] = (float)(num171 + 1);
                    }
                    flag4 = false;
                }
                if (projectile.ai[1] > 0f)
                {
                    int num176 = (int)(projectile.ai[1] - 1f);
                    if (Main.npc[num176].active && Main.npc[num176].CanBeChasedBy(projectile, true) && !Main.npc[num176].dontTakeDamage)
                    {
                        float num177 = Main.npc[num176].position.X + (float)(Main.npc[num176].width / 2);
                        float num178 = Main.npc[num176].position.Y + (float)(Main.npc[num176].height / 2);
                        float num179 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num177) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num178);
                        if (num179 < 1000f)
                        {
                            flag4 = true;
                            num168 = Main.npc[num176].position.X + (float)(Main.npc[num176].width / 2);
                            num169 = Main.npc[num176].position.Y + (float)(Main.npc[num176].height / 2);
                        }
                    }
                    else
                    {
                        projectile.ai[1] = 0f;
                    }
                }
                if (!projectile.friendly)
                {
                    flag4 = false;
                }
                if (flag4)
                {
                    float num180 = num167;
                    Vector2 vector19 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                    float num181 = num168 - vector19.X;
                    float num182 = num169 - vector19.Y;
                    float num183 = (float)Math.Sqrt((double)(num181 * num181 + num182 * num182));
                    num183 = num180 / num183;
                    num181 *= num183;
                    num182 *= num183;
                    int num184 = 8;
                    projectile.velocity.X = (projectile.velocity.X * (float)(num184 - 1) + num181) / (float)num184;
                    projectile.velocity.Y = (projectile.velocity.Y * (float)(num184 - 1) + num182) / (float)num184;
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
            Vector2 vector19 = projectile.position;
            Vector2 oldVelocity = projectile.oldVelocity;
            oldVelocity.Normalize();
            vector19 += oldVelocity * 16f;
            int num3;
            for (int num355 = 0; num355 < 30; num355 = num3 + 1)
            {
                int num356 = Dust.NewDust(vector19, projectile.width, projectile.height, 90, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num356].position = (Main.dust[num356].position + projectile.Center) / 2f;
                Dust dust = Main.dust[num356];
                dust.velocity += projectile.oldVelocity * 1.4f;
                dust = Main.dust[num356];
                dust.velocity *= 0.8f;
                dust.fadeIn *= 2.8f;
                Main.dust[num356].noGravity = true;
                vector19 -= oldVelocity * 2f;
                num3 = num355;
            }
        }
    } 
}