using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class Carcinogen : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;

            projectile.width = 16;
            projectile.height = 16;      
            projectile.aiStyle = 99; 
            projectile.friendly = true;  
            projectile.penetrate = -1; 
            projectile.melee = true;
            projectile.scale = 0.75f;
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 9.5f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 170f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 13f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Carcinogen");
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 100);
            for (int num2 = 0; num2 < 15; num2++)
            {
                int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 105, 0f, 0f, 100, default(Color), 1.2f);
                Main.dust[num].velocity *= 2f;
                Main.dust[num].noGravity = true;
            }
        }
    }
}
