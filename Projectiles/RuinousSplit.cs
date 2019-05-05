using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class RuinousSplit : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ruinous Essence");
        }
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = 10;
            projectile.timeLeft = 1;
            projectile.extraUpdates = 1;
            aiType = ProjectileID.Bullet;
        }
        public override void Kill(int timeLeft)
        {
            int numProj = 3;
            float rotation = MathHelper.ToRadians(10);
            for (int i = 0; i < numProj + 1; i++)
            {
                Vector2 perturbedSpeed = new Vector2(projectile.velocity.X * 3f, projectile.velocity.Y * 3f).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numProj - 1)));
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("AncientSpirit"), (int)((double)projectile.damage * 0.8f), projectile.knockBack, projectile.owner, 0f, 0f);

            }
        }
    }
}