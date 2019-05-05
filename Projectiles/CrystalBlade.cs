using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class CrystalBlade : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 24;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 100;
            projectile.light = 0.25f;
            projectile.extraUpdates = 1;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 2;
            ProjectileID.Sets.TrailingMode[projectile.type] = 5;
            projectile.aiStyle = 2;
            aiType = 48;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Bolt");
        }

        public override bool PreAI()
        {
            int num3;
            for (int num20 = 0; num20 < 8; num20 = num3 + 3)
            {
                float num21 = projectile.velocity.X / 4f * (float)num20;
                float num22 = projectile.velocity.Y / 4f * (float)num20;
                int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 61, 0f, 0f, 0, default(Color), 1.2f);
                Main.dust[num23].position.X = projectile.Center.X - num21;
                Main.dust[num23].position.Y = projectile.Center.Y - num22;
                Dust dust3 = Main.dust[num23];
                dust3.velocity *= 0f;
                Main.dust[num23].scale = 0.6f;
                Main.dust[num23].noGravity = true;
                num3 = num20;
            }
            for (int num20 = 0; num20 < 8; num20 = num3 + 3)
            {
                float num21 = projectile.velocity.X / 4f * (float)num20;
                float num22 = projectile.velocity.Y / 4f * (float)num20;
                int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 81, 0f, 0f, 0, default(Color), 0.5f);
                Main.dust[num23].position.X = projectile.Center.X - num21;
                Main.dust[num23].position.Y = projectile.Center.Y - num22;
                Dust dust3 = Main.dust[num23];
                dust3.velocity *= 0f;
                Main.dust[num23].scale = 0.6f;
                Main.dust[num23].noGravity = true;
                num3 = num20;
            }
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int num3;
            if (projectile.owner == Main.myPlayer)
            {
                int num626 = 4;
                if (Main.rand.Next(10) == 0)
                {
                    num3 = num626;
                    num626 = num3 + 1;
                }
                if (Main.rand.Next(10) == 0)
                {
                    num3 = num626;
                    num626 = num3 + 1;
                }
                if (Main.rand.Next(10) == 0)
                {
                    num3 = num626;
                    num626 = num3 + 1;
                }
                for (int num627 = 0; num627 < num626; num627 = num3 + 5)
                {
                    float num628 = (float)Main.rand.Next(-35, 36) * 0.02f;
                    float num629 = (float)Main.rand.Next(-35, 36) * 0.02f;
                    num628 *= 20f;
                    num629 *= 20f;
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, num628, num629, mod.ProjectileType("CrystalBlade"), (int)((double)projectile.damage * 0.75), (float)((int)((double)projectile.knockBack * 0.35)), Main.myPlayer, 0f, 0f);
                    num3 = num627;
                }
            }

        }
        public override void Kill(int timeLeft)
        {
            for (int i = 4; i < 31; i++)
            {
                float x = projectile.oldVelocity.X * (20f / i);
                float y = projectile.oldVelocity.Y * (20f / i);
                int newDust = Dust.NewDust(new Vector2(projectile.oldPosition.X - x, projectile.oldPosition.Y - y), 8, 8, 61, projectile.oldVelocity.X, projectile.oldVelocity.Y, 58, default(Color), 1.8f);
                Main.dust[newDust].noGravity = true;
                Main.dust[newDust].velocity *= 0.5f;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //If collide with tile, reduce the penetrate.
            //So the projectile can reflect at most 5 times
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = -oldVelocity.X;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.velocity.Y = -oldVelocity.Y;
            }
            Main.PlaySound(SoundID.Item10, projectile.position);

            return false;
        }
    }
}