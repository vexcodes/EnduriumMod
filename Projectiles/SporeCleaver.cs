using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace EnduriumMod.Projectiles
{
    public class SporeCleaver : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 34;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = -1;
            projectile.aiStyle = 3;
            projectile.timeLeft = 600;
            aiType = 52;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int num11 = Main.rand.Next(1, 3);
            for (int j = 0; j < num11; j++)
            {
                Vector2 vector = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                vector += projectile.velocity * 3f;
                vector.Normalize();
                vector *= (float)Main.rand.Next(35, 39) * 0.1f;
                int num12 = (int)((double)projectile.damage * 0.5);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector.X, vector.Y, mod.ProjectileType("SporeSparkle"), num12, projectile.knockBack * 0.2f, projectile.owner, 0f, 0f);
            }

        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spore Cleaver");
        }
        public override void AI()
        {
            projectile.velocity.X *= 1.02f;
            projectile.velocity.Y *= 1.02f;
        }

    }
}