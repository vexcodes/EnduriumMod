using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class HolyBurst : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 22;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = 2;
            projectile.aiStyle = 1;
            projectile.timeLeft = 140;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Burst");
        }

        public override void AI()
        {
            int a = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 269, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            if (projectile.ai[0] == 1)
            {
                projectile.ai[1] += 1;
            }
            if (projectile.ai[1] >= 7)
            {
                projectile.Kill();
            }
            projectile.rotation *= 1.005f;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.ai[0] = 1;
            int num11 = Main.rand.Next(1, 3);
            for (int j = 0; j < num11; j++)
            {
                Vector2 vector = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                vector += projectile.velocity * 3f;
                vector.Normalize();
                vector *= (float)Main.rand.Next(35, 39) * 0.1f;
                int num12 = (int)((double)projectile.damage * 0.5);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector.X, vector.Y, mod.ProjectileType("HolyLight"), num12, projectile.knockBack * 0.2f, projectile.owner, 0f, 0f);
            }
        }
        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 0f, 612, (int)((double)projectile.damage * 0.75), (float)((int)((double)projectile.knockBack * 0.35)), Main.myPlayer, 0f, 0f);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
    }
}