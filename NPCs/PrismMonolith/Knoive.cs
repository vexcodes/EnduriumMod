using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.PrismMonolith
{
    public class Knoive : ModProjectile
    {
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("Shiver"), 60);
        }
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 30;
            projectile.friendly = false;
            projectile.light = 0.25f;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 200;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 3;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prism Magic");
        }
        float spawnin = 0f;
        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;
            if (spawnin == 0f)
            {
                spawnin = 1f;
                for (int num623 = 0; num623 < 15; num623++)
                {
                    int num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 132, 0f, 0f, 100, default(Color), 1.2f);
                    Main.dust[num624].noGravity = true;
                    Main.dust[num624].velocity *= 4f;
                }
                Main.PlaySound(SoundID.DD2_DrakinShot, projectile.position);
            }
            if (projectile.ai[0] == 30)
            {
                projectile.velocity.X *= 4.1f;
                projectile.velocity.Y *= 4.1f;
            }
            int num3;
            for (int num93 = 0; num93 < 2; num93 = num3 + 1)
            {
                float num94 = projectile.velocity.X / 3f * (float)num93;
                float num95 = projectile.velocity.Y / 3f * (float)num93;
                int num96 = 4;
                int num97 = Dust.NewDust(new Vector2(projectile.position.X + (float)num96, projectile.position.Y + (float)num96), projectile.width - num96 * 2, projectile.height - num96 * 2, 132, 0f, 0f, 100, default(Color), 0.5f);
                Main.dust[num97].noGravity = true;
                Dust dust3 = Main.dust[num97];
                dust3.velocity *= 0.1f;
                dust3 = Main.dust[num97];
                dust3.velocity += projectile.velocity * 0.1f;
                Dust dust6 = Main.dust[num97];
                dust6.position.X = dust6.position.X - num94;
                Dust dust7 = Main.dust[num97];
                dust7.position.Y = dust7.position.Y - num95;
                num3 = num93;
            }

        }
    }
}