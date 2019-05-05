using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.TheSpiritOfBloom
{
    public class BloomingEnergy : ModProjectile
    {
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("NatureReaper"), 80);
        }
        public override void SetDefaults()
        {
            projectile.width = 42;
            projectile.height = 42;
            projectile.aiStyle = 1;
            projectile.light = 0.25f;
            projectile.friendly = false;
            projectile.tileCollide = true;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            projectile.alpha = 100;
            projectile.timeLeft = 240;
            aiType = ProjectileID.Bullet;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
            for (int num621 = 0; num621 < 12; num621++)
            {
                int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 89, 0f, 0f, 100, default(Color), 0.6f);
                Main.dust[num622].velocity *= 3f;
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[num622].scale = 0.8f;
                    Main.dust[num622].noGravity = true;
                }
            }
        }
        public override void AI()
        {
            int num3;
            int num323 = (int)projectile.ai[0];
            for (int num324 = 0; num324 < 4; num324 = num3 + 1)
            {
                int num325 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 89, projectile.velocity.X, projectile.velocity.Y, num323, default(Color), 1.2f);
                Main.dust[num325].position = (Main.dust[num325].position + projectile.Center) / 2f;
                Main.dust[num325].noGravity = true;
                Dust dust3 = Main.dust[num325];
                dust3.velocity *= 0.7f;
                num3 = num324;
            }
            for (int num326 = 0; num326 < 3; num326 = num3 + 1)
            {
                int num327 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 89, projectile.velocity.X, projectile.velocity.Y, num323, default(Color), 0.6f);
                if (num326 == 0)
                {
                    Main.dust[num327].position = (Main.dust[num327].position + projectile.Center * 5f) / 6f;
                }
                else
                {
                    if (num326 == 1)
                    {
                        Main.dust[num327].position = (Main.dust[num327].position + (projectile.Center + projectile.velocity / 2f) * 5f) / 6f;
                    }
                }
                Dust dust3 = Main.dust[num327];
                dust3.velocity *= 0.2f;
                Main.dust[num327].noGravity = true;
                Main.dust[num327].fadeIn = 1f;
                num3 = num326;
            }
            return;

        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blooming Energy");
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }
    }
}