using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class RottenFlame : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 42;
            projectile.height = 164;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 3;
            projectile.tileCollide = true;
            projectile.timeLeft = 80;
            projectile.light = 0.25f;
            projectile.extraUpdates = 4;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 2;
            ProjectileID.Sets.TrailingMode[projectile.type] = 5;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rotten Flame");
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 4;
        }
        public override void AI()
        {
            int num3 = 1;
            for (int num731 = 0; num731 < 2; num731 = num3 + 1)
            {
                int num200 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 61, 0f, 0f, 35, default(Color), 0.6f);
                Dust dust37 = Main.dust[num200];
                dust37.position.X = dust37.position.X - 2f;
                Dust dust38 = Main.dust[num200];
                dust38.position.Y = dust38.position.Y + 7f;
                Dust dust3 = Main.dust[num200];
                dust3.scale += (float)Main.rand.Next(50) * 0.02f;
                Main.dust[num200].velocity *= 0.8f;
                Dust dust39 = Main.dust[num200];
                dust39.velocity.Y = dust39.velocity.Y - 7f;
                if (Main.rand.Next(2) == 0)
                {
                    int num201 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 89, 0f, 0f, 70, default(Color), 0.6f);
                    Dust dust40 = Main.dust[num201];
                    dust40.position.X = dust40.position.X - 2f;
                    Dust dust41 = Main.dust[num201];
                    dust41.position.Y = dust41.position.Y + 7f;
                    dust3 = Main.dust[num201];
                    dust3.scale += 0.3f + (float)Main.rand.Next(50) * 0.02f;
                    Main.dust[num201].noGravity = true;
                    dust3 = Main.dust[num201];
                    dust3.velocity *= 0.6f;
                    dust41.position.Y = dust41.position.Y - 7f;
                }
            }
            int num2001 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 194, 0f, 0f, 35, default(Color), 0.6f);
            Dust dust371 = Main.dust[num2001];
            dust371.position.X = dust371.position.X - 1f;
            Dust dust381 = Main.dust[num2001];
            dust381.position.Y = dust381.position.Y + 4f;
            Dust dust31 = Main.dust[num2001];
            dust31.scale += (float)Main.rand.Next(50) * 0.01f;
            Main.dust[num2001].velocity *= 0.4f;
            Dust dust391 = Main.dust[num2001];
            dust391.velocity.Y = dust391.velocity.Y - 7f;
            if (Main.rand.Next(2) == 0)
            {
                int num2011 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 194, 0f, 0f, 70, default(Color), 0.6f);
                Dust dust401 = Main.dust[num2011];
                dust401.position.X = dust401.position.X - 1f;
                Dust dust411 = Main.dust[num2011];
                dust411.position.Y = dust411.position.Y + 4f;
                dust31 = Main.dust[num2011];
                dust31.scale += 0.3f + (float)Main.rand.Next(50) * 0.01f;
                Main.dust[num2011   ].noGravity = true;
                dust31 = Main.dust[num2011];
                dust31.velocity *= 0.6f;
            }
        }
    }
}