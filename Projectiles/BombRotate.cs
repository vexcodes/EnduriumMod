using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class BombRotate : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 24;
            projectile.hostile = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 200;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood");
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }
        public override void AI()
        {
            int num3;
            for (int num452 = 0; num452 < 4; num452 = num3 + 1)
            {
                Vector2 vector36 = projectile.position;
                vector36 -= projectile.velocity * ((float)num452 * 0.25f);
                projectile.alpha = 255;
                int num453 = Dust.NewDust(vector36, 1, 1, 115, 0f, 0f, 0, default(Color), 0.5f);
                Main.dust[num453].position = vector36;
                Main.dust[num453].scale = (float)Main.rand.Next(70, 110) * 0.013f;
                Dust dust3 = Main.dust[num453];
                dust3.velocity *= 0f;
                dust3.noGravity = true;
                num3 = num452;
            }
            for (int num452 = 0; num452 < 4; num452 = num3 + 1)
            {
                Vector2 vector36 = projectile.position;
                vector36 -= projectile.velocity * ((float)num452 * 0.25f);
                projectile.alpha = 255;
                int num453 = Dust.NewDust(vector36, 1, 1, 259, 0f, 0f, 0, default(Color), 0.9f);
                Main.dust[num453].position = vector36;
                Main.dust[num453].scale = (float)Main.rand.Next(70, 110) * 0.013f;
                Dust dust3 = Main.dust[num453];
                dust3.velocity *= 0.2f;
                dust3.noGravity = true;
                num3 = num452;
            }
            if (projectile.timeLeft <= 160 && projectile.ai[1] == 0)
            {
                Player player = Main.player[Main.myPlayer];
                float closestDist = 10000;
                int chosenPlayer = Main.myPlayer;
                for (int i = 0; i < 255; i++)
                {
                    if (i == 0) closestDist = Vector2.Distance(Main.player[i].Center, projectile.Center);
                    else if (Vector2.Distance(Main.player[i].Center, projectile.Center) < closestDist)
                    {
                        closestDist = Vector2.Distance(Main.player[i].Center, projectile.Center);
                        chosenPlayer = i;
                    }
                }
                player = Main.player[chosenPlayer];
                projectile.velocity = Vector2.Normalize(player.Center - projectile.Center) * 13;
                projectile.ai[1] = 1;
            }
            if (projectile.timeLeft < 160)
            {
                projectile.ai[3] += 1;

                if (projectile.ai[2] == 0)
                {
                    if (projectile.ai[3] >= 10)
                    {
                        projectile.ai[3] = 0;
                        projectile.ai[2] = 1;
                    }
                    else
                    {
                        Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.ToRadians(-1));
                        projectile.velocity.Y = perturbedSpeed.Y;
                        projectile.velocity.X = perturbedSpeed.X;
                    }
                }
                else
                {
                    if (projectile.ai[3] <= 10)
                    {
                        Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.ToRadians(2));
                        projectile.velocity.Y = perturbedSpeed.Y;
                        projectile.velocity.X = perturbedSpeed.X;

                    }
                    else if (projectile.ai[3] >= 20 && projectile.ai[3] <= 30)
                    {
                        Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.ToRadians(-2));
                        projectile.velocity.Y = perturbedSpeed.Y;
                        projectile.velocity.X = perturbedSpeed.X;
                    }
                    if (projectile.ai[3] >= 40)
                    {
                        projectile.ai[0] = 0;
                    }
                }
            }
        }
    }
}