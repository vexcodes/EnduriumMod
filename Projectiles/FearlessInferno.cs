using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class FearlessInferno : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 42;
            projectile.height = 164;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 2;
            projectile.tileCollide = true;
            projectile.timeLeft = 80;
            projectile.light = 0.25f;
            projectile.extraUpdates = 4;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 2;
            ProjectileID.Sets.TrailingMode[projectile.type] = 5;
        }
        public override bool? CanHitNPC(NPC target)
        {
            if (projectile.penetrate == 1)
            {
                return false;
            }
            return true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fearless Inferno");
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 6;
        }
        public override void AI()
        {
            int num3 = 1;
            for (int num731 = 0; num731 < 2; num731 = num3 + 1)
            {
                int num200 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 173, 0f, 0f, 35, default(Color), 0.6f);
                Main.dust[num200].noLight = true;
                Dust dust37 = Main.dust[num200];
                dust37.position.X = dust37.position.X - 2f;
                Dust dust38 = Main.dust[num200];
                dust38.position.Y = dust38.position.Y + 7f;
                Dust dust3 = Main.dust[num200];
                dust3.scale += (float)Main.rand.Next(50) * 0.02f;
                Main.dust[num200].velocity *= 0.8f;
                Dust dust39 = Main.dust[num200];
                dust39.velocity.Y = dust39.velocity.Y - 7f;
            }
            int num2001 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 173, 0f, 0f, 35, default(Color), 0.6f);
            Main.dust[num2001].noLight = true;
            Dust dust371 = Main.dust[num2001];
            dust371.position.X = dust371.position.X - 1f;
            Dust dust381 = Main.dust[num2001];
            dust381.position.Y = dust381.position.Y + 4f;
            Dust dust31 = Main.dust[num2001];
            dust31.scale += (float)Main.rand.Next(50) * 0.01f;
            Main.dust[num2001].velocity *= 0.4f;
            Dust dust391 = Main.dust[num2001];
            dust391.velocity.Y = dust391.velocity.Y - 7f;
        }
    }
}