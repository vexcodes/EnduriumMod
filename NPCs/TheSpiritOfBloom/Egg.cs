using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.TheSpiritOfBloom
{
    public class Egg : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 20;
            projectile.hostile = false;
            projectile.friendly = false;
            projectile.magic = true;
            projectile.penetrate = 4;
            projectile.timeLeft = 100;
            projectile.aiStyle = 14;
            projectile.light = 0.25f;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 2;
            ProjectileID.Sets.TrailingMode[projectile.type] = 5;
            aiType = 48;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("You can't die from this without cheating");
        }
        public override bool CanHitPlayer(Player target)
        {
            return false;
        }
        public override void Kill(int timeLeft)
        {
            int num414 = (int)(projectile.position.X);
            int num415 = (int)(projectile.position.Y - 1200);
            Projectile.NewProjectile((float)num414, (float)num415, 0f, 12f, mod.ProjectileType("BloomStrike2"), 30, 0f, projectile.owner, 0f, 0f);
            for (int num621 = 0; num621 < 7; num621++)
            {
                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 89, 0, 0);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 2f;
            }
        }
        public override void AI()
        {
            if (projectile.velocity.X != projectile.velocity.X)
            {
                projectile.velocity.X = projectile.velocity.X * -0.1f;
            }

            {
                if (projectile.ai[1] == 0f)
                {
                    projectile.ai[1] = 1f;
                    Main.PlaySound(SoundID.Item13, projectile.position);
                }
                int num200 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 89, 0f, 0f, 100, default(Color), 0.8f);
                Dust dust37 = Main.dust[num200];
                dust37.position.X = dust37.position.X - 2f;
                Dust dust38 = Main.dust[num200];
                dust38.position.Y = dust38.position.Y + 2f;
                Dust dust3 = Main.dust[num200];
                dust3.scale += (float)Main.rand.Next(50) * 0.01f;
                Main.dust[num200].noGravity = true;
                Dust dust39 = Main.dust[num200];
                dust39.velocity.Y = dust39.velocity.Y - 2f;
                if (Main.rand.Next(2) == 0)
                {
                    int num201 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 89, 0f, 0f, 100, default(Color), 0.8f);
                    Dust dust40 = Main.dust[num201];
                    dust40.position.X = dust40.position.X - 2f;
                    Dust dust41 = Main.dust[num201];
                    dust41.position.Y = dust41.position.Y + 2f;
                    dust3 = Main.dust[num201];
                    dust3.scale += 0.3f + (float)Main.rand.Next(50) * 0.01f;
                    Main.dust[num201].noGravity = true;
                    dust3 = Main.dust[num201];
                    dust3.velocity *= 0.1f;
                }
                if ((double)projectile.velocity.Y < 0.25 && (double)projectile.velocity.Y > 0.15)
                {
                    projectile.velocity.X = projectile.velocity.X * 0.8f;
                }
                projectile.rotation = -projectile.velocity.X * 0.05f;
            }
        }
    }
}
