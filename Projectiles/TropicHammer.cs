using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class TropicHammer : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tropic Hammer");
        }

        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 26;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = 1;
            projectile.aiStyle = 3;
            projectile.extraUpdates = 2;
            aiType = 52;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int num3;
            if (projectile.owner == Main.myPlayer)
            {
                int num626 = 6;
                if (Main.rand.Next(3) == 0)
                {
                    num3 = num626;
                    num626 = num3 + 3;
                }
                if (Main.rand.Next(4) == 0)
                {
                    num3 = num626;
                    num626 = num3 + 3;
                }
                if (Main.rand.Next(5) == 0)
                {
                    num3 = num626;
                    num626 = num3 + 3;
                }
                for (int num627 = 0; num627 < num626; num627 = num3 + 5)
                {
                    float num628 = (float)Main.rand.Next(-35, 36) * 0.02f;
                    float num629 = (float)Main.rand.Next(-35, 36) * 0.02f;
                    num628 *= 20f;
                    num629 *= 20f;
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, num628, num629, mod.ProjectileType("TropicSpike"), (int)((double)projectile.damage * 0.75), (float)((int)((double)projectile.knockBack * 0.35)), Main.myPlayer, 0f, 0f);
                    num3 = num627;
                }
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.ai[0] += 0.1f;
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
    }
}