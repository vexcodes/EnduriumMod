using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class RazorShot : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;

            projectile.width = 14;
            projectile.height = 26;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.melee = true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Razor Shot");
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int num621 = 0; num621 < 10; num621++)
            {
                int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 89, 0f, 0f, 95, default(Color), 1f);
                Main.dust[num622].velocity *= 2f;
            }
        }
    }
}
