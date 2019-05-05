using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.KeeperofHollow
{
    public class HollowSpike : ModProjectile
    {
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("Shiver"), 80);
        }
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = 1;
            projectile.light = 0.25f;
            projectile.friendly = false;
            projectile.tileCollide = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            projectile.alpha = 100;
            projectile.timeLeft = 240;
            aiType = ProjectileID.Bullet;
        }
        public override void Kill(int timeLeft)
        {
            for (int num621 = 0; num621 < 12; num621++)
            {
                int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 156, 0f, 0f, 100, default(Color), 2.2f);
                Main.dust[num622].velocity *= 3f;
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[num622].scale = 0.5f;
                    Main.dust[num622].noGravity = true;
                    Main.dust[num622].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                }
            }
            for (int num623 = 0; num623 < 15; num623++)
            {
                int num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("HollowBurn"), 0f, 0f, 100, default(Color), 2.7f);
                Main.dust[num624].noGravity = true;
                Main.dust[num624].velocity *= 4f;
                num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 156, 0f, 0f, 100, default(Color), 2f);
                Main.dust[num624].velocity *= 2f;
                Main.dust[num624].noGravity = true;

            }

        }
        public override void AI()
        {
            projectile.ai[0] += 1;
            int num4324;
            int num;
            for (int num20 = 0; num20 < 4; num20 = num4324 + 1)
            {
                float num21 = projectile.velocity.X / 4f * (float)num20;
                float num22 = projectile.velocity.Y / 4f * (float)num20;
                int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("HollowBurn"), 0f, 0f, 0, default(Color), 1.3f);
                Main.dust[num23].position.X = projectile.Center.X - num21;
                Main.dust[num23].position.Y = projectile.Center.Y - num22;
                Dust dust3 = Main.dust[num23];
                dust3.velocity *= 0f;
                Main.dust[num23].scale = 0.98f;
                Main.dust[num23].noGravity = true;
                num4324 = num20;
            }
            if (projectile.ai[1] == 0f)
            {
                projectile.ai[1] = 1f;
                Main.PlaySound(SoundID.Item91, projectile.position);
            }
            projectile.spriteDirection = projectile.direction;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nova Blast");
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }
    }
}