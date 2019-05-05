using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class StarClaymore : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = 27;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = 8;
            projectile.alpha = 80;
            projectile.timeLeft = 60;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 4;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Claymore");
        }
        public override void AI()
        {
            float num21 = projectile.velocity.X / 4f;
            float num22 = projectile.velocity.Y / 4f;
            int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 156, 0f, 0f, 0, default(Color), 0.2f);
            Main.dust[num23].position.X = projectile.Center.X - num21;
            Main.dust[num23].position.Y = projectile.Center.Y - num22;
            Dust dust3 = Main.dust[num23];
            dust3.velocity *= 0f;
            Main.dust[num23].scale = 0.2f;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 4; i < 31; i++)
            {
                float x = projectile.oldVelocity.X * (20f / i);
                float y = projectile.oldVelocity.Y * (20f / i);
                int newDust = Dust.NewDust(new Vector2(projectile.oldPosition.X - x, projectile.oldPosition.Y - y), 8, 8, 156, projectile.oldVelocity.X, projectile.oldVelocity.Y, 58, default(Color), 2.5f);
                Main.dust[newDust].noGravity = true;
                Main.dust[newDust].velocity *= 0.5f;
            }
        }
    }
}