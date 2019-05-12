using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class VoidRift : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul Rift");
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.width = 68;
            projectile.height = 68;
            projectile.friendly = true;
            projectile.penetrate = 12;
            projectile.tileCollide = false;
            projectile.timeLeft = 200;
            projectile.magic = true;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
            for (int num623 = 0; num623 < 10; num623++)
            {
                int num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 21, 0f, 0f, 100, default(Color), 1.7f);
                Main.dust[num624].noGravity = true;
                Main.dust[num624].velocity *= 4f;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(153, 300);
            target.immune[projectile.owner] = 12;
        }
        public override void AI()
        {

            if (projectile.ai[0] == 0f)
            {
                projectile.ai[0] = projectile.velocity.X;
                projectile.ai[1] = projectile.velocity.Y;
            }
            if (projectile.velocity.X > 0f)
            {
                projectile.rotation += (Math.Abs(projectile.velocity.Y) + Math.Abs(projectile.velocity.X)) * 0.002f;
            }
            else
            {
                projectile.rotation -= (Math.Abs(projectile.velocity.Y) + Math.Abs(projectile.velocity.X)) * 0.002f;
            }
            int num3 = projectile.frameCounter;
            projectile.frameCounter = num3 + 1;
            if (projectile.frameCounter > 4)
            {
                projectile.frameCounter = 0;
                num3 = projectile.frame;
                projectile.frame = num3 + 1;
                if (projectile.frame > 2)
                {
                    projectile.frame = 0;
                }
            }
            int[] array = new int[20];
            int num433 = 0;
            float num434 = 800f;
            bool flag14 = false;
            for (int num435 = 0; num435 < 200; num435 = num3 + 1)
            {
                if (Main.npc[num435].CanBeChasedBy(projectile, false))
                {
                    float num436 = Main.npc[num435].position.X + (float)(Main.npc[num435].width / 2);
                    float num437 = Main.npc[num435].position.Y + (float)(Main.npc[num435].height / 2);
                    float num438 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num436) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num437);
                    if (num438 < num434 && Collision.CanHit(projectile.Center, 1, 1, Main.npc[num435].Center, 1, 1))
                    {
                        if (num433 < 20)
                        {
                            array[num433] = num435;
                            num3 = num433;
                            num433 = num3 + 1;
                        }
                        flag14 = true;
                    }
                }
                num3 = num435;
            }
            if (projectile.timeLeft < 50)
            {
                flag14 = false;
            }
            if (flag14)
            {
                int num439 = Main.rand.Next(num433);
                num439 = array[num439];
                float num440 = Main.npc[num439].position.X + (float)(Main.npc[num439].width / 2);
                float num441 = Main.npc[num439].position.Y + (float)(Main.npc[num439].height / 2);
                projectile.localAI[0] += 1f;
                if (projectile.localAI[0] > 10f)
                {
                    projectile.penetrate--;
                    projectile.localAI[0] = 0f;
                    float num442 = 6f;
                    Vector2 vector32 = new Vector2(projectile.position.X + (float)projectile.width, projectile.position.Y + (float)projectile.height);
                    vector32 += projectile.velocity * 1f;
                    float num443 = num440 - vector32.X;
                    float num444 = num441 - vector32.Y;
                    float num445 = (float)Math.Sqrt((double)(num443 * num443 + num444 * num444));
                    num445 = num442 / num445;
                    num443 *= num445;
                    num444 *= num445;
                    int num1111 = Projectile.NewProjectile(vector32.X, vector32.Y, num443, num444, mod.ProjectileType("LostSoul"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
                    Main.projectile[num1111].magic = true;
                    Main.projectile[num1111].ranged = false;
                    return;
                }
            }
        }
    }
}