using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class DragonRipper : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 28;
            projectile.height = 74;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = 4;
            projectile.timeLeft = 100;
            projectile.aiStyle = 1;
			projectile.extraUpdates = 1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon Ripper");
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 4; i < 35; i++)
            {
                float x = projectile.oldVelocity.X * (20f / i);
                float y = projectile.oldVelocity.Y * (20f / i);
                int newDust = Dust.NewDust(new Vector2(projectile.oldPosition.X - x, projectile.oldPosition.Y - y), 8, 8, 127, projectile.oldVelocity.X, projectile.oldVelocity.Y, 58, default(Color), 1.8f);
                Main.dust[newDust].noGravity = true;
                Main.dust[newDust].velocity *= 0.5f;
            }
        }
        public override void AI()
        {
            int a = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 158, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 30f)       //how much time the projectile can travel before landing
            {  // projectile fall velocity
                projectile.velocity.Y = projectile.velocity.X / 6f;    // projectile velocity
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {                                                           // sound that the projectile make when hiting the terrain
            {
                projectile.Kill();
            }
            return false;
        }
    }
}
