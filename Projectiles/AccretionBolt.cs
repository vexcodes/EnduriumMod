using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class AccretionBolt : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Accretion Bolt");
        }
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.timeLeft = 50;
            projectile.penetrate = 6;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = false;
            projectile.ignoreWater = false;
            projectile.magic = true;
            projectile.extraUpdates = 6;
            projectile.alpha = 50;
            projectile.aiStyle = 1;
            aiType = ProjectileID.Bullet;

        }
        public override void Kill(int timeLeft)
        {
            int num;
            for (int l = 0; l < 12; l = num + 1)
            {
                Vector2 vector3 = Vector2.UnitX * -(float)projectile.width / 2f;
                vector3 += -Vector2.UnitY.RotatedBy((double)((float)l * 3.14159274f / 6f), default(Vector2)) * new Vector2(8f, 16f);
                vector3 = vector3.RotatedBy((double)(projectile.rotation - 1.57079637f), default(Vector2));
                int num9 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 90, 0f, 0f, 160, default(Color), 1.5f);

                Main.dust[num9].scale = 1.4f;
                Main.dust[num9].noGravity = true;
                Main.dust[num9].position = projectile.Center + vector3;
                Main.dust[num9].velocity = projectile.velocity * 0.25f;
                Main.dust[num9].velocity = Vector2.Normalize(projectile.Center - projectile.velocity * 3f - Main.dust[num9].position) * 1.25f;
                num = l;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 2;
            target.AddBuff(mod.BuffType("AccretionBurn"), 300);
        }

        public override void AI()
        {
            int num;
            Player owner = Main.player[projectile.owner]; //Makes a player variable of owner set as the player using the projectile
            if (projectile.alpha < 170)
            {
                projectile.localAI[0] += 1f;
                if (projectile.localAI[0] == 14f)
                {
                    for (int l = 0; l < 12; l = num + 1)
                    {
                        Vector2 vector3 = Vector2.UnitX * -(float)projectile.width / 2f;
                        vector3 += -Vector2.UnitY.RotatedBy((double)((float)l * 3.14159274f / 6f), default(Vector2)) * new Vector2(8f, 16f);
                        vector3 = vector3.RotatedBy((double)(projectile.rotation - 1.57079637f), default(Vector2));
                        int num9 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 90, 0f, 0f, 160, default(Color), 1.5f);

                        Main.dust[num9].scale = 1.4f;
                        Main.dust[num9].noGravity = true;
                        Main.dust[num9].position = projectile.Center + vector3;
                        Main.dust[num9].velocity = projectile.velocity * 0.25f;
                        Main.dust[num9].velocity = Vector2.Normalize(projectile.Center - projectile.velocity * 3f - Main.dust[num9].position) * 1.25f;
                        num = l;
                    }
                }
                int num3;
                for (int num93 = 0; num93 < 2; num93 = num3 + 1)
                {
                    float num94 = projectile.velocity.X / 3f * (float)num93;
                    float num95 = projectile.velocity.Y / 3f * (float)num93;
                    int num96 = 4;
                    int num97 = Dust.NewDust(new Vector2(projectile.position.X + (float)num96, projectile.position.Y + (float)num96), projectile.width - num96 * 2, projectile.height - num96 * 2, 90, 0f, 0f, 100, default(Color), 1.2f);
                    Main.dust[num97].noGravity = true;
                    Dust dust3 = Main.dust[num97];
                    dust3.velocity *= 0.1f;
                    dust3 = Main.dust[num97];
                    dust3.velocity += projectile.velocity * 0.1f;
                    Dust dust6 = Main.dust[num97];
                    dust6.position.X = dust6.position.X - num94;
                    Dust dust7 = Main.dust[num97];
                    dust7.position.Y = dust7.position.Y - num95;
                    num3 = num93;
                }

            }

        }
    }
}
