using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.TheSwarm
{
    public class BloomSurge : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 110;
            projectile.extraUpdates = 2;
            projectile.height = 110;
            projectile.hostile = true;
            projectile.tileCollide = false;
            projectile.penetrate = 5;      //this is how many enemy this projectile penetrate before desapear 
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Leaf Bloom");
        }
        public override void AI()
        {
            int num16 = 0;
            Vector2 vector13 = Vector2.UnitX * 18f;
            vector13 = vector13.RotatedBy((double)(projectile.rotation - 1.57079637f), default(Vector2));
            Vector2 value6 = projectile.Center + vector13;
            for (int k = 0; k < num16 + 1; k++)
            {
                int num18 = 89;
                float num19 = 1.1f;
                if (k % 2 == 1)
                {
                    num18 = 226;
                    num19 = 1.65f;
                }
                Vector2 vector14 = value6 + ((float)Main.rand.NextDouble() * 6.28318548f).ToRotationVector2() * (120f - (float)(num16 * 2));
                int num20 = Dust.NewDust(vector14 - Vector2.One * 8f, 16, 16, num18, projectile.velocity.X / 2f, projectile.velocity.Y / 2f, 0, default(Color), 0.6f);
                Main.dust[num20].velocity = Vector2.Normalize(value6 - vector14) * 4.5f * (10f - (float)num16 * 0.5f) / 4f;
                Main.dust[num20].noGravity = true;
                Main.dust[num20].scale = num19;
            }
            projectile.alpha += 1;
            if (projectile.alpha > 255)
            {
                projectile.Kill();
            }

        }
    }
}
