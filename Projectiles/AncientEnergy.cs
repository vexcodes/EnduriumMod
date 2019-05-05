using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class AncientEnergy : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Powers");
        }
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = 4;
            projectile.timeLeft = 35;
            projectile.extraUpdates = 1;
            aiType = ProjectileID.Bullet;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 2;
        }
        public override void AI()
        {
            int num3;
            if (projectile.alpha > 0)
            {
                projectile.alpha -= 50;
            }
            else
            {
                projectile.extraUpdates = 0;
            }
            if (projectile.alpha < 0)
            {
                projectile.alpha = 0;
            }
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) - 1.57f;
            for (int num20 = 0; num20 < 5; num20 = num3 + 3)
            {
                float num21 = projectile.velocity.X / 4f * (float)num20;
                float num22 = projectile.velocity.Y / 4f * (float)num20;
                int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 114, 0f, 0f, 0, default(Color), 0.2f);
                Main.dust[num23].position.X = projectile.Center.X - num21;
                Main.dust[num23].position.Y = projectile.Center.Y - num22;
                Dust dust3 = Main.dust[num23];
                dust3.velocity *= 0f;
                Main.dust[num23].scale = 0.2f;
                num3 = num20;
            }
            if (Main.rand.Next(5) == 0)
            {
                int num98 = 4;
                int num99 = Dust.NewDust(new Vector2(projectile.position.X + (float)num98, projectile.position.Y + (float)num98), projectile.width - num98 * 2, projectile.height - num98 * 2, 114, 0f, 0f, 100, default(Color), 2.4f);
                Dust dust3 = Main.dust[num99];
                Main.dust[num99].noGravity = true;
                dust3.velocity *= 0.5f;
                dust3 = Main.dust[num99];
                dust3.velocity += projectile.velocity * 0.8f;
            }
            if (Main.rand.Next(5) == 0)
            {
                int num198 = 4;
                int num199 = Dust.NewDust(new Vector2(projectile.position.X + (float)num198, projectile.position.Y + (float)num198), projectile.width - num198 * 2, projectile.height - num198 * 2, 269, 0f, 0f, 100, default(Color), 2.4f);
                Dust dust13 = Main.dust[num199];
                Main.dust[num199].noGravity = true;
                dust13.velocity *= 0.5f;
                dust13 = Main.dust[num199];
                dust13.velocity += projectile.velocity * 0.8f;
            }
            float num166 = (float)Math.Sqrt((double)(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y));
            float num167 = projectile.localAI[0];
            if (num167 == 0f)
            {
                projectile.localAI[0] = num166;
                num167 = num166;
            }
            if (projectile.alpha > 0)
            {
                projectile.alpha -= 25;
            }
            if (projectile.alpha < 0)
            {
                projectile.alpha = 0;
            }
            float num168 = projectile.position.X;
            float num169 = projectile.position.Y;
            float num170 = 300f;
            bool flag4 = false;
            int num171 = 0;
            if (projectile.ai[1] == 0f)
            {
                int num;
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

}


