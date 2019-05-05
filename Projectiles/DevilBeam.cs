using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class DevilBeam : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.timeLeft = 200;
            projectile.alpha = 225;
            projectile.light = 0.0f;
            projectile.extraUpdates = 100;
            projectile.ignoreWater = true;
        }
        public override void AI()
        {
            int num3;
            for (int num452 = 0; num452 < 4; num452 = num3 + 1)
            {
                Vector2 vector36 = projectile.position;
                vector36 -= projectile.velocity * ((float)num452 * 0.25f);
                projectile.alpha = 255;
                int num453 = Dust.NewDust(vector36, 1, 1, 90, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num453].position = vector36;
                Main.dust[num453].scale = (float)Main.rand.Next(70, 110) * 0.013f;
                Dust dust3 = Main.dust[num453];
                dust3.velocity *= 0f;
                dust3.noGravity = true;
                num3 = num452;
            }
            return;

        }
        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 90, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.3f);
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }
    }
}