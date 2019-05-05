using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class NecroSkull : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 24;
            projectile.hostile = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 500;
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
                int num453 = Dust.NewDust(vector36, 1, 1, 115, 0f, 0f, 0, default(Color), 0.7f);
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
                int num453 = Dust.NewDust(vector36, 1, 1, 259, 0f, 0f, 0, default(Color), 1.4f);
                Main.dust[num453].position = vector36;
                Main.dust[num453].scale = (float)Main.rand.Next(70, 110) * 0.013f;
                Dust dust3 = Main.dust[num453];
                dust3.velocity *= 0.2f;
                dust3.noGravity = true;
                num3 = num452;
            }
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
            float maxSpeed = 2f; //MOVEMENT SPEED
            Vector2 toTarget = new Vector2(player.Center.X - projectile.Center.X, player.Center.Y - projectile.Center.Y);
            toTarget = new Vector2(player.Center.X - projectile.Center.X, player.Center.Y - projectile.Center.Y);
            toTarget.Normalize();
            projectile.velocity = toTarget * maxSpeed;
            player = Main.player[chosenPlayer];

        }
    }
}