using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class PrismaticKnive : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 34;
            projectile.friendly = true;
            projectile.aiStyle = 1;
            projectile.thrown = true;
            projectile.penetrate = 3;      //this is how many enemy this projectile penetrate before desapear 
            projectile.extraUpdates = 1;
			            projectile.light = 0.25f;
            aiType = ProjectileID.ThrowingKnife;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prismatic Knife");
        }


        public override void AI()
        {
           projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 50f)       //how much time the projectile can travel before landing
            {
                projectile.velocity.Y = projectile.velocity.Y + 3.15f;    // projectile fall velocity
                projectile.velocity.X = projectile.velocity.X * 2f;    // projectile velocity
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {                                                           // sound that the projectile make when hiting the terrain
            {
                projectile.Kill();
                int a = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 112, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 10);
            }
            return false;
        }
		
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int num621 = 0; num621 < 15; num621++)
            {
                int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 117, 0f, 0f, 95, default(Color), 0.9f);
                Main.dust[num622].velocity *= 2f;
            }
			float numberProjectiles = 2; // 3, 4, or 5 shots
			float rotation = MathHelper.ToRadians(25);
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .9f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("PrismEnergy"), (int)((double)projectile.damage * 0.75f), projectile.knockBack, projectile.owner, 0f, 0f);
			}
        }
    }
}
