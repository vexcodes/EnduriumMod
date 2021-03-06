using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class DarkCleaver : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 18;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 800;
            projectile.light = 0.25f;
            projectile.extraUpdates = 1;
            projectile.aiStyle = 2;
            aiType = 48;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Cleaver");
        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("Shiver"), 699);
        }

        public override bool PreAI()
        {
            if (projectile.ai[0] == 0)
            {
                projectile.ai[0] = 1;
                int num3;
                for (int num731 = 0; num731 < 5; num731 = num3 + 1)
                {
                    int num732 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 242, 0f, 0f, 100, default(Color), 1.5f);
                    Main.dust[num732].noGravity = true;
                    Dust dust = Main.dust[num732];
                    dust.velocity *= 2f;
                    num732 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 242, 0f, 0f, 100, default(Color), 0.5f);
                    dust = Main.dust[num732];
                    dust.velocity *= 1f;
                    num3 = num731;
                }
            }
            Player owner = Main.player[projectile.owner]; //Makes a player variable of owner set as the player using the projectile

            if (projectile.alpha < 170)
            {
                int num;
                for (int num164 = 0; num164 < 2; num164 = num + 1)
                {
                    float x2 = projectile.position.X - projectile.velocity.X / 10f * (float)num164;
                    float y2 = projectile.position.Y - projectile.velocity.Y / 2f * (float)num164;
                    int num165 = Dust.NewDust(new Vector2(x2, y2), projectile.width, projectile.height, 242, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[num165].alpha = projectile.alpha;
                    Main.dust[num165].position.X = x2;
                    Main.dust[num165].position.Y = y2;
                    Dust dust3 = Main.dust[num165];
                    dust3.velocity *= 0f;
                    Main.dust[num165].noGravity = true;
                    num = num164;
                }
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
            return false;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 60);

            for (int num621 = 0; num621 < 15; num621++)
            {
                int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 242, 0f, 0f, 156, default(Color), 1.2f);
                Main.dust[num622].velocity *= 3f;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }
    }
}