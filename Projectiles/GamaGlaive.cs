using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class GamaGlaive : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Gama Glaive");
        }

        public override void SetDefaults()
        {
            projectile.width = 36;
            projectile.height = 36;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = 1;
            projectile.aiStyle = 3;
            projectile.extraUpdates = 2;
            aiType = 52;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int num414 = (int)(projectile.position.X + (float)projectile.width);
            int num415 = (int)(projectile.position.Y + (float)projectile.height);
            Projectile.NewProjectile((float)num414, (float)num415, -5f, -5f, mod.ProjectileType("StarShard2"), 100, 0f, projectile.owner);
            Projectile.NewProjectile((float)num414, (float)num415, -5f, 5f, mod.ProjectileType("StarShard2"), 100, 0f, projectile.owner);
            Projectile.NewProjectile((float)num414, (float)num415, 5f, -5f, mod.ProjectileType("StarShard2"), 100, 0f, projectile.owner);
            Projectile.NewProjectile((float)num414, (float)num415, 5f, 5f, mod.ProjectileType("StarShard2"), 100, 0f, projectile.owner);
            Projectile.NewProjectile((float)num414, (float)num415, 0f, -5f, mod.ProjectileType("StarShard2"), 100, 0f, projectile.owner);
            Projectile.NewProjectile((float)num414, (float)num415, 0f, 5f, mod.ProjectileType("StarShard2"), 100, 0f, projectile.owner);
            Projectile.NewProjectile((float)num414, (float)num415, 5f, 0f, mod.ProjectileType("StarShard2"), 100, 0f, projectile.owner);
            Projectile.NewProjectile((float)num414, (float)num415, -5f, 0f, mod.ProjectileType("StarShard2"), 100, 0f, projectile.owner);
            return;
        }
    }
}