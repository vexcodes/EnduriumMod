using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class BloomRang : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloom-a-Rang");
        }
        public override void SetDefaults()
        {
            projectile.width = 38;
            projectile.height = 38;
            projectile.aiStyle = 3;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 600;
            projectile.extraUpdates = 1;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 0f, Main.rand.Next(-10, 11) * .0f, Main.rand.Next(-10, -5) * 0f, mod.ProjectileType("BloomBomb"), (int)(projectile.damage * .5f), 0, projectile.owner);
            return;
        }
    }
}