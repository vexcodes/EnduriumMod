using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class AnarchySpell : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 24;
            projectile.hostile = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 50;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Anarchy Spell");
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }
        public int Spaget = 0;
        public override void AI()
        {
            projectile.spriteDirection = projectile.direction;
            if (projectile.alpha >= 120)
            {
                projectile.alpha -= 10;
            }
            int num4324;
            int num;
            for (int num20 = 0; num20 < 4; num20 = num4324 + 1)
            {
                float num21 = projectile.velocity.X / 4f * (float)num20;
                float num22 = projectile.velocity.Y / 4f * (float)num20;
                int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 45, 0f, 0f, 0, default(Color), 0.9f);
                Main.dust[num23].position.X = projectile.Center.X - num21;
                Main.dust[num23].position.Y = projectile.Center.Y - num22;
                Dust dust3 = Main.dust[num23];
                dust3.velocity *= 0f;
                Main.dust[num23].scale = 0.1f;
                Main.dust[num23].noGravity = true;
                num4324 = num20;
            }
            if (Spaget == 0)
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
                Spaget += 1;
            }
        }
    }
}