using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class SkyBubble : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sky Bubble");
        }
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.friendly = true;
            projectile.alpha = 255;
            projectile.penetrate = 5;
            projectile.timeLeft = 280;
            projectile.magic = true;
			projectile.scale = 0.75f;
            projectile.extraUpdates = 1;
        }

        public override void AI()
        {
            projectile.scale = projectile.ai[1];
            projectile.rotation += projectile.velocity.X * 2f;
            Vector2 position = projectile.Center + Vector2.Normalize(projectile.velocity) * 2f;
            Dust dust37 = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, 156, 0f, 0f, 0, default(Color), 0f)];
            dust37.position = position;
            dust37.velocity = projectile.velocity.RotatedBy(1.5707963705062866, default(Vector2)) * 0.33f + projectile.velocity / 4f;
            Dust dust3 = dust37;
            dust3.position += projectile.velocity.RotatedBy(1.5707963705062866, default(Vector2));
            dust37.fadeIn = 0.5f;
            dust37.noGravity = true;
            dust37 = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, 156, 0f, 0f, 0, default(Color), 0f)];
            dust37.position = position;
            dust37.velocity = projectile.velocity.RotatedBy(-1.5707963705062866, default(Vector2)) * 0.33f + projectile.velocity / 4f;
            dust3 = dust37;
            dust3.position += projectile.velocity.RotatedBy(-1.5707963705062866, default(Vector2));
            dust37.fadeIn = 0.5f;
            dust37.noGravity = true;
            int num;
            for (int num190 = 0; num190 < 1; num190 = num + 1)
            {
                int num191 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 156, 0f, 0f, 0, default(Color), 1f);
                dust3 = Main.dust[num191];
                dust3.velocity *= 0.5f;
                dust3 = Main.dust[num191];
                dust3.scale *= 1.3f;
                Main.dust[num191].fadeIn = 1f;
                Main.dust[num191].noGravity = true;
                num = num190;
            }
        }
    }
}