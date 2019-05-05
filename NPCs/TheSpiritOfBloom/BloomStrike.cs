using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.TheSpiritOfBloom
{
    public class BloomStrike : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 24;
            projectile.hostile = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 60;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloom Strike");
        }
        public override bool CanHitPlayer(Player target)
        {
            return false;
        }
        public override void AI()
        {

            int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 89, 0, 0);
            Main.dust[dust].noGravity = false;
            Main.dust[dust].velocity *= 2f;
            Main.dust[dust].scale = 1.2f;
            projectile.localAI[0] += 1f;
            if (projectile.localAI[0] > 59)
            {
                projectile.localAI[0] = 0f;
                int num414 = (int)(projectile.position.X);
                int num415 = (int)(projectile.position.Y);
                Projectile.NewProjectile((float)num414, (float)num415 - 82, 0f, 0f, mod.ProjectileType("BloomingFlame"), 30, 0f, projectile.owner, 0f, 0f);
                projectile.Kill();
            }


            if (projectile.ai[0] == 0f)
            {
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 18);
            }
            projectile.ai[0] += 1f;
            if (projectile.timeLeft > 15)
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
                projectile.position = player.Center;
            }
            else
            {
                projectile.velocity.X = 0f;
                projectile.velocity.Y = 0f;
            }
        }
    }
}