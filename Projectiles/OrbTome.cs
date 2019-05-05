using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class OrbTome : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloomlight Pierce");
        }
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 42;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.alpha = 180;
            projectile.scale = 0.75f;
            projectile.timeLeft /= 2;
            projectile.magic = true;
        }
        public override void AI()
        {

            projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;
            if (projectile.alpha <= 0)
            {
                int num;
                for (int num108 = 0; num108 < 2; num108 = num + 1)
                {
                    int num109 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 61, 0f, 0f, 0, default(Color), 0.8f);
                    Main.dust[num109].noGravity = true;
                    Dust dust3 = Main.dust[num109];
                    dust3.velocity *= 0f;
                    Main.dust[num109].noLight = true;
                    num = num108;
                }
            }
            if (projectile.alpha < 0)
            {
                projectile.alpha = 0;
                float num110 = 16f;
                int num111 = 0;
                while ((float)num111 < num110)
                {
                    Vector2 vector14 = Vector2.UnitX * 0f;
                    vector14 += -Vector2.UnitY.RotatedBy((double)((float)num111 * (6.28318548f / num110)), default(Vector2)) * new Vector2(1f, 4f);
                    vector14 = vector14.RotatedBy((double)projectile.velocity.ToRotation(), default(Vector2));
                    int num112 = Dust.NewDust(projectile.Center, 0, 0, 89, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[num112].scale = 1.5f;
                    Main.dust[num112].noLight = true;
                    Main.dust[num112].noGravity = true;
                    Main.dust[num112].position = projectile.Center + vector14;
                    Main.dust[num112].velocity = Main.dust[num112].velocity * 4f + projectile.velocity * 0.3f;
                    int num = num111;
                    num111 = num + 1;
                }
            }
            
            if (projectile.alpha > 0)
            {
                projectile.alpha -= 5;
            }
            else
            {
                projectile.extraUpdates = 0;
            }
            if (projectile.alpha < 0)
            {
                projectile.alpha = 0;
            }
            projectile.ai[1]++;
            if (projectile.ai[1] >= 70)
            {
                projectile.Kill();
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 7; k++)
            {
                int num137 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 61, projectile.oldVelocity.X * 0.05f, projectile.oldVelocity.Y * 0.05f);
                Main.dust[num137].noGravity = true;
            }
            for (int k = 0; k < 7; k++)
            {
                int num137 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 89, projectile.oldVelocity.X * 0.05f, projectile.oldVelocity.Y * 0.05f);
                Main.dust[num137].noGravity = true;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            projectile.Kill();
            return false;
        }
    }
}