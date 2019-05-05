using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class ElementMagnum : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 2;
            projectile.height = 56;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.penetrate = 1;
            projectile.alpha = 175;
            projectile.extraUpdates = 3;
            projectile.timeLeft = 300;
			aiType = ProjectileID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Element Magnum");
        }
        public override void AI()
        {
            int DanYamiIsGay = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 178, projectile.velocity.X * 0.9f, projectile.velocity.Y * 0.9f);
            int b = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 167, projectile.velocity.X * 0.7f, projectile.velocity.Y * 0.7f);
            Main.dust[DanYamiIsGay].velocity *= 0f;
            Main.dust[DanYamiIsGay].noGravity = true;
            Main.dust[b].velocity *= 0f;
            Main.dust[b].noGravity = true;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 178, projectile.oldVelocity.X * 0f, projectile.oldVelocity.Y * 0f);
            }
        }
    }
}
