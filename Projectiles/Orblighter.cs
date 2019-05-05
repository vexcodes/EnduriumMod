using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class Orblighter : ModProjectile
    {
        public static int ProjectileTimer = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orblighter");
        }
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 50;
            projectile.extraUpdates = 1;
            aiType = ProjectileID.Bullet;
        }
		        public override void AI()
        {
            projectile.velocity.X *= 0.985f;
            projectile.velocity.Y *= 0.985f;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 74, projectile.velocity.X * 0f, projectile.velocity.Y * 0f);
        }
    }
}