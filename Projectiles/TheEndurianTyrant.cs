using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class TheEndurianTyrant : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Judge");
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
            if (crit)
            {
                Player player = Main.player[projectile.owner];
                player.AddBuff(mod.BuffType("TyrantsGate"), 45);
            }
            for (int i = 0; i < 1; i++)
            {
                int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 0f, Main.rand.Next(-10, 11) * .0f, Main.rand.Next(-10, -5) * 0f, mod.ProjectileType("TyrantExplosion"), (int)(projectile.damage * 0.45f), 0, projectile.owner);
            }
            return;
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