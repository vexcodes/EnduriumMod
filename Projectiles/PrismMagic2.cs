using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class PrismMagic2 : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 30;
            projectile.aiStyle = 1;
            aiType = 100;
            projectile.friendly = true;
            projectile.tileCollide = false;
			projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            projectile.alpha = 175;
            projectile.timeLeft = 800;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prism Magic");
        }
		        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
        	target.AddBuff(mod.BuffType("Shiver"), 360);
        }

        public override void AI()
        {
            projectile.velocity.X *= 1.05f;
            projectile.velocity.Y *= 1.05f;
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.velocity.Y += projectile.ai[0];
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 156, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 1.5f);
            }
        }
    }
}
