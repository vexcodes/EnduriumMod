using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class SnowballFurious : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 60;
            projectile.height = 60;
            projectile.friendly = true;
            projectile.alpha = 255;
            projectile.tileCollide = false;
            projectile.ranged = true;
            projectile.penetrate = -1;
            projectile.extraUpdates = 5;
            projectile.timeLeft = 600;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frostfury Cannon");
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 5;
            target.AddBuff(mod.BuffType("Shiver"), 360);
        }
        public float AI1 = 0f;
        public float AI2 = 0f;
        public override void AI()
        {
            int num3;
            float num94 = projectile.velocity.X;
            float num95 = projectile.velocity.Y;
            int num96 = 4;
            if (AI1 >= -40)
            {
                AI1 -= 2;
            }
            if (AI2 <= 40)
            {
                AI2 += 2;
            }
            Vector2 perturbedSpeed1 = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.ToRadians(AI1));
            Vector2 perturbedSpeed2 = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.ToRadians(AI2));

            int num97 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, mod.DustType("StarFlame"), 0f, 0f, 100, default(Color), 1.2f);
            Main.dust[num97].noGravity = true;
            Main.dust[num97].position.X = projectile.Center.X;
            Main.dust[num97].position.Y = projectile.Center.Y;
            Main.dust[num97].velocity.Y = perturbedSpeed1.Y;
            Main.dust[num97].velocity.X = perturbedSpeed1.X;

            int num98 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, mod.DustType("StarFlame"), 0f, 0f, 100, default(Color), 1.2f);
            Main.dust[num98].noGravity = true;
            Main.dust[num98].position.X = projectile.Center.X;
            Main.dust[num98].position.Y = projectile.Center.Y;
            Main.dust[num98].velocity.Y = perturbedSpeed2.Y;
            Main.dust[num98].velocity.X = perturbedSpeed2.X;
        }


        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
    }
}