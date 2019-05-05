using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class PutridSpore1 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Putrid Spore");
        }
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 10;
            projectile.tileCollide = false;
            projectile.timeLeft = 100;
            projectile.extraUpdates = 1;
            aiType = ProjectileID.Bullet;
        }
        public override void AI()
        {
            projectile.velocity.X *= 0.935f;
            projectile.velocity.Y *= 0.935f;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 184, projectile.velocity.X * 0f, projectile.velocity.Y * 0f);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("whACk"), 120);
            for (int num621 = 0; num621 < 15; num621++)
            {
                int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 184, 0f, 0f, 95, default(Color), 0.9f);
                Main.dust[num622].velocity *= 2f;
            }
        }

    }
}