using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class ShadowRiftRang : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 38;
            projectile.height = 52;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = 6;
            projectile.aiStyle = 3;
            projectile.timeLeft = 600;
            projectile.alpha = 40;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 60);
            for (int num2 = 0; num2 < 12; num2++)
            {
                int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 21, 0f, 0f, 100, default(Color), 1.2f);
                Main.dust[num].velocity *= 3f;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.velocity.X *= 1.15f;
            projectile.velocity.Y *= 1.15f;
            projectile.ai[0] += 3f;
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = -oldVelocity.X;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.velocity.Y = -oldVelocity.Y;
            }
            return false;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Void Caller");
        }
    }
}