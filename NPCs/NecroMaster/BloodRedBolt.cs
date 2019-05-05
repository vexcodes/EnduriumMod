using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.NecroMaster
{
    public class BloodRedBolt : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.hostile = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 800;
            projectile.light = 0.25f;
            projectile.extraUpdates = 1;
            projectile.aiStyle = 1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Red Bolt");
        }

        public override bool PreAI()
        {
            int num3;
            for (int num20 = 0; num20 < 1; num20 = num3 + 3)
            {
                float num21 = projectile.velocity.X / 4f * (float)num20;
                float num22 = projectile.velocity.Y / 4f * (float)num20;
                int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 182, 0f, 0f, 0, default(Color), 0.2f);
                Main.dust[num23].position.X = projectile.Center.X - num21;
                Main.dust[num23].position.Y = projectile.Center.Y - num22;
                Dust dust3 = Main.dust[num23];
                dust3.velocity *= 0f;
                Main.dust[num23].scale = 0.8f;
                Main.dust[num23].noGravity = true;
                num3 = num20;
            }
            return false;
        }
    }
}