using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.StarShip
{
    public class StarOvercharge : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Overcharge");
        }
        public override void SetDefaults()
        {
            projectile.width = 36;
            projectile.height = 34;
            projectile.tileCollide = false;
            projectile.penetrate = 5;
            projectile.timeLeft = 9000;
            projectile.scale = 1.2f;
        }
        float AI1 = 0f;
        float dustscale = 1.2f;
        public override void AI()
        {
            AI1 += 0.2f;
            Vector2 value11 = new Vector2((float)projectile.ai[0], (float)projectile.ai[1]);
            Vector2 value12 = new Vector2((float)projectile.Center.X, (float)projectile.Center.Y);
            projectile.velocity = Vector2.Normalize(value11 - value12) * AI1;
            if (AI1 >= 6f)
            {
                dustscale -= 0.02f;
            }
            if (dustscale <= 0.4f)
            {
                projectile.Kill();
            }
            int num3;
            for (int num20 = 0; num20 < 1; num20 = num3 + 3)
            {
                float num21 = projectile.velocity.X / 4f * (float)num20;
                float num22 = projectile.velocity.Y / 4f * (float)num20;
                int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 156, 0f, 0f, 0, default(Color), 0.2f);
                Main.dust[num23].position.X = projectile.Center.X - num21;
                Main.dust[num23].position.Y = projectile.Center.Y - num22;
                Dust dust3 = Main.dust[num23];
                dust3.velocity *= 0f;
                Main.dust[num23].scale = dustscale;
                Main.dust[num23].noGravity = true;
                num3 = num20;
            }
        }
    }
}