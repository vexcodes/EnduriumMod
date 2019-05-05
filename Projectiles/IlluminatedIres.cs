using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class IlluminatedIres : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.aiStyle = 1;
            projectile.timeLeft = 100;
            projectile.magic = true;
            projectile.penetrate = 2;      //this is how many enemy this projectile penetrate before desapear 
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 4;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Illuminated Iris");
        }


        public override void AI()
        {
            if (projectile.ai[0] == 0)
            {
                projectile.ai[0] = 1;
                for (int num623 = 0; num623 < 7; num623++)
                {
                    int num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 15, 0f, 0f, 100, default(Color), 0.4f);
                    Main.dust[num624].noGravity = true;
                    Main.dust[num624].velocity *= 5f;

                    int num626 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 228, 0f, 0f, 100, default(Color), 0.7f);
                    Main.dust[num626].noGravity = true;
                    Main.dust[num626].velocity *= 4f;
                }
            }
            for (int i = 4; i < 5; i++)
            {
                int b = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 58, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.6f);
                Main.dust[b].velocity *= 0f;
                Main.dust[b].noGravity = true;
            }
            for (int i = 4; i < 6; i++)
            {
                int a = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 228, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.6f);
                Main.dust[a].velocity *= 0.2f;
                Main.dust[a].noGravity = true;
            }
            projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 30f)       //how much time the projectile can travel before landing
            {
                projectile.velocity.Y = projectile.velocity.Y + 3.15f;    // projectile fall velocity
                projectile.velocity.X = projectile.velocity.X * 2f;    // projectile velocity
            }
            int num3;
            float num372 = projectile.position.X;
            float num373 = projectile.position.Y;
            float num374 = 100000f;
            bool flag10 = false;
            projectile.ai[0] += 1f;
            if (projectile.ai[0] > 30f)
            {
                projectile.ai[0] = 30f;

                for (int num375 = 0; num375 < 200; num375 = num3 + 1)
                {
                    if (Main.npc[num375].CanBeChasedBy(projectile, false) && (!Main.npc[num375].wet || projectile.type == 307))
                    {
                        float num376 = Main.npc[num375].position.X + (float)(Main.npc[num375].width / 2);
                        float num377 = Main.npc[num375].position.Y + (float)(Main.npc[num375].height / 2);
                        float num378 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num376) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num377);
                        if (num378 < 800f && num378 < num374 && Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[num375].position, Main.npc[num375].width, Main.npc[num375].height))
                        {
                            num374 = num378;
                            num372 = num376;
                            num373 = num377;
                            flag10 = true;
                        }
                    }
                    num3 = num375;
                }
            }
            if (!flag10)
            {
                num372 = projectile.position.X + (float)(projectile.width / 2) + projectile.velocity.X * 100f;
                num373 = projectile.position.Y + (float)(projectile.height / 2) + projectile.velocity.Y * 100f;
            }

            projectile.friendly = true;
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 4; i < 5; i++)
            {
                float x = projectile.oldVelocity.X * (20f / i);
                float y = projectile.oldVelocity.Y * (20f / i);
                int newDust = Dust.NewDust(new Vector2(projectile.oldPosition.X - x, projectile.oldPosition.Y - y), 8, 8, 15, projectile.oldVelocity.X, projectile.oldVelocity.Y, 33, default(Color), 1.1f);
                Main.dust[newDust].noGravity = true;
                Main.dust[newDust].velocity *= 0.5f;
            }
            for (int i = 4; i < 5; i++)
            {
                float x = projectile.oldVelocity.X * (20f / i);
                float y = projectile.oldVelocity.Y * (20f / i);
                int newDust = Dust.NewDust(new Vector2(projectile.oldPosition.X - x, projectile.oldPosition.Y - y), 8, 8, 58, projectile.oldVelocity.X, projectile.oldVelocity.Y, 58, default(Color), 0.8f);
                Main.dust[newDust].noGravity = true;
                Main.dust[newDust].velocity *= 0.5f;
            }
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //If collide with tile, reduce the penetrate.
            //So the projectile can reflect at most 5 times
            for (int i = 4; i < 8; i++)
            {
                float x = projectile.oldVelocity.X * (20f / i);
                float y = projectile.oldVelocity.Y * (20f / i);
                int newDust = Dust.NewDust(new Vector2(projectile.oldPosition.X - x, projectile.oldPosition.Y - y), 8, 8, 33, projectile.oldVelocity.X, projectile.oldVelocity.Y, 58, default(Color), 1.8f);
                Main.dust[newDust].noGravity = true;
                Main.dust[newDust].velocity *= 0.5f;
            }

            projectile.penetrate--;
            projectile.velocity.Y += 3f;
            projectile.velocity.X += 3f;
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = -oldVelocity.X;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.velocity.Y = -oldVelocity.Y;
            }
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);

            return false;
        }
    }
}