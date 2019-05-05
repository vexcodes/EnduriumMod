using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace EnduriumMod.Projectiles
{
    public class CrightBlow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cright Blow");
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.thrown = true;
            Main.projFrames[projectile.type] = 7;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(696);
            aiType = 696;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.thrown = true;
            projectile.timeLeft = 100;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 16, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
        }

        public override bool PreKill(int timeLeft)
        {
            projectile.type = 696;
            projectile.thrown = true;
            projectile.friendly = true;
            projectile.penetrate = -1;
            return true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 0f, Main.rand.Next(-10, 11) * .0f, Main.rand.Next(-10, -5) * 0f, 0, (int)(projectile.damage * .5f), 0, projectile.owner);

            return true;
        }
    }
}