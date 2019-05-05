using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class StarRainPedestrian : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 78;
            projectile.height = 78;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 300;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Strike");
        }
        public override void AI()
        {
            int num;
            projectile.velocity.X *= 1.04f;
            projectile.velocity.Y *= 1.04f;
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 0.785f;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);
            return true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int num11 = Main.rand.Next(2, 3);
            for (int j = 0; j < num11; j++)
            {
                Vector2 vector = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                vector += projectile.velocity * 3f;
                vector.Normalize();
                vector *= (float)Main.rand.Next(35, 39) * 0.1f;
                int num12 = (int)((double)projectile.damage * 0.75);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector.X, vector.Y, mod.ProjectileType("StarRainPedestrianProjectile"), num12, projectile.knockBack * 0.2f, projectile.owner, 0f, 0f);
            }
        }
        public override void Kill(int timeLeft)
        {
            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 36;
            projectile.height = 36;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            int num3;
            for (int num731 = 0; num731 < 18; num731 = num3 + 1)
            {
                int num732 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("StarFlame"), 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[num732].noGravity = true;
                Dust dust = Main.dust[num732];
                dust.velocity.X *= 1.8f;
                dust.velocity.Y *= 2.2f;
                num732 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("StarFlame"), 0f, 0f, 100, default(Color), 0.8f);
                dust = Main.dust[num732];
                dust.velocity.X *= 1.2f;
                dust.velocity.Y *= 0.8f;
                num3 = num731;
            }
        }
    }
}
