using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class ShadowRiftDagger : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            projectile.alpha = 25;
            projectile.timeLeft = 24;
        }
        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;
            if (projectile.ai[1] != 0)
            {
                projectile.timeLeft -= 1;
                projectile.alpha = 125;
            }
            if (projectile.ai[1] == 1)
            {
                projectile.ai[1] = 2;
                projectile.velocity = Vector2.Normalize(Main.npc[(int)projectile.ai[0]].Center - projectile.Center) * 8;
            }
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Rift Dagger");
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(153, 300);
            target.immune[projectile.owner] = 7;
            for (int num623 = 0; num623 < 4; num623++)
            {
                int num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 21, 0f, 0f, 100, default(Color), 0.4f);
                Main.dust[num624].noGravity = true;
                Main.dust[num624].velocity *= 4f;
            }
            if (projectile.ai[1] == 0)
            {
                projectile.Kill();
                Projectile.NewProjectile(target.position.X + Main.rand.Next(-50, 51), target.position.Y + Main.rand.Next(-50, 51), 0f, 0f, mod.ProjectileType("ShadowRiftDagger"), 80, 0f, projectile.owner, target.whoAmI, 1f);
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }
    }
}
