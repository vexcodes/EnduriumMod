using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class CrystalDagger : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 36;
            projectile.friendly = true;
            projectile.aiStyle = 1;
            projectile.thrown = true;
            projectile.penetrate = 4;      //this is how many enemy this projectile penetrate before desapear 
            projectile.extraUpdates = 1;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //If collide with tile, reduce the penetrate.
            //So the projectile can reflect at most 5 times
            for (int i = 4; i < 8; i++)
            {
                float x = projectile.oldVelocity.X * (20f / i);
                float y = projectile.oldVelocity.Y * (20f / i);
                int newDust = Dust.NewDust(new Vector2(projectile.oldPosition.X - x, projectile.oldPosition.Y - y), 8, 8, 33, projectile.oldVelocity.X, projectile.oldVelocity.Y, 58, default(Color), 1.8f);
                Main.dust[newDust].noGravity = true;
                Main.dust[newDust].velocity *= 0.5f;
            }
            int numProj = 3;
            float rotation = MathHelper.ToRadians(10);
            for (int i = 0; i < numProj + 1; i++)
            {
                Vector2 perturbedSpeed = new Vector2(0f, -6f).RotatedByRandom(MathHelper.Lerp(-rotation, rotation, i / (numProj - 1)));
                int numgay1 = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("CrystalBall"), (int)((double)projectile.damage), projectile.knockBack, projectile.owner, 0f, 0f);
                Main.projectile[numgay1].penetrate = 4;
            }
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);
            projectile.Kill();
            return false;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Dagger");
        }
    }
}
