using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class GodsStorm : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("God's Storm");
        }
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.alpha = 255;
            projectile.penetrate = 3;
            projectile.timeLeft = 320;
            projectile.extraUpdates = 100;
            projectile.magic = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (target.life <= 0)
            {
                Main.PlaySound(3, (int)projectile.position.X, (int)projectile.position.Y, 1, 1f, 0f);
                int num3;
                for (int num622 = 0; num622 < 10; num622 = num3 + 1)
                {
                    int num623 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 173, 0f, 0f, 0, default(Color), 1.1f);
                    Dust dust = Main.dust[num623];
                    dust.scale *= 1.2f;
                    Main.dust[num623].noGravity = true;
                    num3 = num622;
                }
                for (int num624 = 0; num624 < 15; num624 = num3 + 1)
                {
                    int num625 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 184, 0f, 0f, 0, default(Color), 1f);
                    Dust dust = Main.dust[num625];
                    dust.velocity *= 2.5f;
                    dust = Main.dust[num625];
                    dust.scale *= 0.9f;
                    Main.dust[num625].noGravity = true;
                    num3 = num624;
                }
                if (projectile.owner == Main.myPlayer)
                {
                    int num626 = 12;
                    if (Main.rand.Next(2) == 0)
                    {
                        num3 = num626;
                        num626 = num3 + 2;
                    }
                    if (Main.rand.Next(2) == 0)
                    {
                        num3 = num626;
                        num626 = num3 + 2;
                    }
                    if (Main.rand.Next(2) == 0)
                    {
                        num3 = num626;
                        num626 = num3 + 2;
                    }
                    for (int num627 = 0; num627 < num626; num627 = num3 + 10)
                    {
                        float num628 = (float)Main.rand.Next(-35, 36) * 0.02f;
                        float num629 = (float)Main.rand.Next(-35, 36) * 0.02f;
                        num628 *= 20f;
                        num629 *= 20f;
                        Projectile.NewProjectile(projectile.position.X, projectile.position.Y, num628, num629, mod.ProjectileType("ZAP"), (int)((double)projectile.damage * 0.75), (float)((int)((double)projectile.knockBack * 0.35)), Main.myPlayer, 0f, 0f);
                        num3 = num627;
                    }
                }
            }
            target.immune[projectile.owner] = 3;
        }
        int radians = 16;
        public override void AI()
        {
            int num3;
            for (int num20 = 0; num20 < 1; num20 = num3 + 1)
            {
                float num21 = projectile.velocity.X / 4f * (float)num20;
                float num22 = projectile.velocity.Y / 4f * (float)num20;
                int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 156, 0f, 0f, 0, default(Color), 1.6f);
                Main.dust[num23].position.X = projectile.Center.X - num21;
                Main.dust[num23].position.Y = projectile.Center.Y - num22;
                Dust dust3 = Main.dust[num23];
                dust3.velocity *= 0f;
                dust3.noGravity = true;
                Main.dust[num23].scale = 0.7f;
                num3 = num20;
            }

            projectile.ai[0] += 1;

            if (projectile.ai[0] >= 8)
            {
                Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedByRandom(MathHelper.ToRadians(radians));
                if (radians >= 16)
                {
                    radians = -24;
                }
                if (radians <= -16)
                {
                    radians = 16;
                }
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                projectile.velocity.Y = perturbedSpeed.Y;
                projectile.velocity.X = perturbedSpeed.X;
                projectile.ai[0] = 0;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //If collide with tile, reduce the penetrate.
            //So the projectile can reflect at most 5 times
            projectile.penetrate--;
            projectile.velocity.Y += 2f;
            if (projectile.penetrate <= 0)
            {
                projectile.Kill();
            }
            else
            {
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
                Main.PlaySound(SoundID.Item10, projectile.position);
            }
            return false;
        }
    }
}