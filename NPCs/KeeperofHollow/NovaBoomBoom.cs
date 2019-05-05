using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.KeeperofHollow
{
    public class NovaBoomBoom : ModProjectile
    {
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("Shiver"), 80);
        }
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 30;
            projectile.aiStyle = 1;
            aiType = 100;
            projectile.light = 0.25f;
            projectile.friendly = false;
            projectile.tileCollide = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            projectile.alpha = 175;
            projectile.timeLeft = 800;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hollow Beam");
        }


        public override void AI()
        {
            int num414 = (int)(projectile.Center.X);
            int num415 = (int)(projectile.Center.Y);
            float Speed = 8f;
            projectile.ai[0] += 1;
            if (projectile.ai[0] == 5 && Main.netMode != 1)
            {
                Projectile.NewProjectile((float)num414, (float)num415, Speed, -Speed, mod.ProjectileType("HollowBoomBoomSpawn2"), 35, 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile((float)num414, (float)num415, -Speed, -Speed, mod.ProjectileType("HollowBoomBoomSpawn2"), 35, 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile((float)num414, (float)num415, Speed, Speed, mod.ProjectileType("HollowBoomBoomSpawn2"), 35, 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile((float)num414, (float)num415, -Speed, Speed, mod.ProjectileType("HollowBoomBoomSpawn2"), 35, 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile((float)num414, (float)num415, 0f, -Speed, mod.ProjectileType("HollowBoomBoomSpawn2"), 35, 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile((float)num414, (float)num415, 0f, Speed, mod.ProjectileType("HollowBoomBoomSpawn2"), 35, 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile((float)num414, (float)num415, Speed, 0f, mod.ProjectileType("HollowBoomBoomSpawn2"), 35, 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile((float)num414, (float)num415, -Speed, 0f, mod.ProjectileType("HollowBoomBoomSpawn2"), 35, 0f, Main.myPlayer, 0f, 0f);
            }
         /*   if (projectile.ai[0] == 20)
            {
                projectile.ai[0] = 6;
                int num11 = Main.rand.Next(1, 2);
                for (int g = 0; g < num11; g++)
                {
                    Projectile.NewProjectile(Main.player.position.X - Main.rand.Next(1, 350), Main.player.position.Y + 600, 0f, -6f, mod.ProjectileType("HollowSpike"), damage, 0f, Main.myPlayer);
                    Projectile.NewProjectile(Main.player.position.X + Main.rand.Next(1, 350), Main.player.position.Y + 600, 0f, -6f, mod.ProjectileType("HollowSpike"), damage, 0f, Main.myPlayer);
                }
            }*/
                Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.5f) / 255f, ((255 - projectile.alpha) * 0.05f) / 255f, ((255 - projectile.alpha) * 0.05f) / 255f);
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.velocity.Y += projectile.ai[0];
            for (int k = 0; k < 3; k++)
            {
               int Gay = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("HollowBurn"), projectile.oldVelocity.X * 0f, projectile.oldVelocity.Y * 0f);
                Main.dust[Gay].noGravity = true;
            }
        }
    }
}
