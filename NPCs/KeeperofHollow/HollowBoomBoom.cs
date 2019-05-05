using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.KeeperofHollow
{
    public class HollowBoomBoom : ModProjectile
    {
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("Shiver"), 80);
        }
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 40;
            projectile.aiStyle = 1;
            projectile.light = 0.25f;
            projectile.extraUpdates = 1;
            projectile.friendly = false;
            projectile.tileCollide = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            projectile.alpha = 50;
            projectile.timeLeft = 500;
            aiType = ProjectileID.Bullet;
        }
        public override void Kill(int timeLeft)
        {
            for (int num621 = 0; num621 < 6; num621++)
            {
                int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("HollowBurn"), 0f, 0f, 100, default(Color), 1.2f);
                Main.dust[num622].velocity *= 3f;
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[num622].scale = 0.5f;
                    Main.dust[num622].noGravity = true;
                    Main.dust[num622].fadeIn = 0.6f + (float)Main.rand.Next(10) * 0.1f;
                }
            }
        }
        public override void AI()
        {
            projectile.velocity *= 1.0005f;
            if (projectile.alpha >= 120)
            {
                projectile.alpha -= 10;
            }
            int num4324;
            int num;
            for (int num20 = 0; num20 < 2; num20 = num4324 + 1)
            {
                float num21 = projectile.velocity.X / 4f * (float)num20;
                float num22 = projectile.velocity.Y / 4f * (float)num20;
                int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("HollowBurn"), 0f, 0f, 0, default(Color), 0.6f);
                Main.dust[num23].position.X = projectile.Center.X - num21;
                Main.dust[num23].position.Y = projectile.Center.Y - num22;
                Dust dust3 = Main.dust[num23];
                dust3.velocity *= 0f;
                Main.dust[num23].scale = 0.68f;
                Main.dust[num23].velocity *= 0.48f;
                Main.dust[num23].noGravity = true;
                Main.dust[num23].fadeIn = 1f;
                num4324 = num20;
            }
            if (projectile.ai[1] == 0f)
            {
                projectile.ai[1] = 1f;
                Main.PlaySound(SoundID.Item91, projectile.position);
            }
            else if (projectile.ai[1] == 1f && Main.netMode != 1)
            {
                int num3 = -1;
                float num4 = 2000f;
                for (int k = 0; k < 255; k = num + 1)
                {
                    if (Main.player[k].active && !Main.player[k].dead)
                    {
                        Vector2 center = Main.player[k].Center;
                        float num5 = Vector2.Distance(center, projectile.Center);
                        if ((num5 < num4 || num3 == -1) && Collision.CanHit(projectile.Center, 1, 1, center, 1, 1))
                        {
                            num4 = num5;
                            num3 = k;
                        }
                    }
                    num = k;
                }
                if (num4 < 20f)
                {
                    projectile.Kill();
                    return;
                }
                if (num3 != -1)
                {
                    projectile.ai[1] = 21f;
                    projectile.ai[0] = (float)num3;
                    projectile.netUpdate = true;
                }
            }
            else if (projectile.ai[1] > 20f && projectile.ai[1] < 200f)
            {
                projectile.ai[1] += 1f;
                int num6 = (int)projectile.ai[0];
                if (!Main.player[num6].active || Main.player[num6].dead)
                {
                    projectile.ai[1] = 1f;
                    projectile.ai[0] = 0f;
                    projectile.netUpdate = true;
                }
                else
                {
                    float num7 = projectile.velocity.ToRotation();
                    Vector2 vector2 = Main.player[num6].Center - projectile.Center;
                    if (vector2.Length() < 20f)
                    {
                        projectile.Kill();
                        return;
                    }
                    float targetAngle = vector2.ToRotation();
                    if (vector2 == Vector2.Zero)
                    {
                        targetAngle = num7;
                    }
                    float num8 = num7.AngleLerp(targetAngle, 0.008f);
                    projectile.velocity = new Vector2(projectile.velocity.Length(), 0f).RotatedBy((double)num8, default(Vector2));
                }
            }
            if (projectile.ai[1] >= 1f && projectile.ai[1] < 20f)
            {
                projectile.ai[1] += 1f;
                if (projectile.ai[1] == 20f)
                {
                    projectile.ai[1] = 1f;
                }
            }
            projectile.alpha -= 40;
            if (projectile.alpha < 0)
            {
                projectile.alpha = 0;
            }
            projectile.spriteDirection = projectile.direction;
            Lighting.AddLight(projectile.Center, 1.1f, 0.9f, 0.4f);
            projectile.localAI[0] += 1f;
            if (projectile.localAI[0] == 6f)
            {
                projectile.localAI[0] = 0f;
                for (int l = 0; l < 12; l = num + 1)
                {
                    Vector2 vector3 = Vector2.UnitX * -(float)projectile.width / 2f;
                    vector3 += -Vector2.UnitY.RotatedBy((double)((float)l * 3.14159274f / 6f), default(Vector2)) * new Vector2(2f, 4f);
                    vector3 = vector3.RotatedBy((double)(projectile.rotation - 1.57079637f), default(Vector2));
                    int num9 = Dust.NewDust(projectile.Center, 0, 0, mod.DustType("HollowBurn"), 0f, 0f, 160, default(Color), 1f);
                    Main.dust[num9].scale = 1.2f;
                    Main.dust[num9].velocity *= 1.5f;
                    Main.dust[num9].noGravity = true;
                    Main.dust[num9].position = projectile.Center + vector3;
                    Main.dust[num9].velocity = projectile.velocity * 0.1f;
                    Main.dust[num9].velocity = Vector2.Normalize(projectile.Center - projectile.velocity * 3f - Main.dust[num9].position) * 1.25f;
                    num = l;
                }
            }
            for (int m = 0; m < 1; m = num + 1)
            {
                Vector2 value = -Vector2.UnitX.RotatedByRandom(0.19634954631328583).RotatedBy((double)projectile.velocity.ToRotation(), default(Vector2));
                int num10 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("HollowBurn"), 0f, 0f, 100, default(Color), 0.6f);
                Dust dust3 = Main.dust[num10];
                dust3.velocity *= 0.1f;
                Main.dust[num10].velocity *= 0.2f;
                Main.dust[num10].noGravity = true;
                Main.dust[num10].position = projectile.Center + value * (float)projectile.width / 2f;
                Main.dust[num10].fadeIn = 1f;
                num = m;
            }

            for (int n = 0; n < 1; n = num + 1)
            {
                Vector2 value2 = -Vector2.UnitX.RotatedByRandom(0.39269909262657166).RotatedBy((double)projectile.velocity.ToRotation(), default(Vector2));
                int num11 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("HollowBurn"), 0f, 0f, 155, default(Color), 0.48f);
                Dust dust3 = Main.dust[num11];
                dust3.velocity *= 0f;
                dust3.fadeIn = 0.7f;
                Main.dust[num11].noGravity = true;
                Main.dust[num11].position = projectile.Center + value2 * (float)projectile.width / 2f;
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[num11].fadeIn = 0.9f;
                }
                num = n;
            }


        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hollow magic");
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }
    }
}
