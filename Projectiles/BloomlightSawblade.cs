using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class BloomlightSawblade : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 9;
            projectile.height = 19;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = 8;
            projectile.aiStyle = 2;
            projectile.timeLeft = 1200;
            aiType = 48;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloomlight Sawblade");
        }

        public override void AI()
        {
            projectile.rotation *= 1.005f;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {                                         
            projectile.Kill();
            int a = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 44, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 10);
            return false;
        }
    }
}