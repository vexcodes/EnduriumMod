using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class Nebula : ModProjectile
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
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 18f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 300f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 18f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nebula");
        }
        public override void AI()
        {
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(3) == 0)
            {
                int num11 = Main.rand.Next(1, 4);
                for (int j = 0; j < num11; j++)
                {
                    Vector2 vector = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                    vector += projectile.velocity * 3f;
                    vector.Normalize();
                    vector *= (float)Main.rand.Next(35, 39) * 0.1f;
                    int num12 = (int)((double)projectile.damage * 0.5);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector.X, vector.Y, mod.ProjectileType("NebulaEnergy"), num12, projectile.knockBack * 0.2f, projectile.owner, 0f, 0f);
                }

            }
        }
    }
}