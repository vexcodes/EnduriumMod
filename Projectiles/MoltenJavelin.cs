using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class MoltenJavelin : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 9;
            projectile.height = 19;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = -1;
            projectile.aiStyle = 1;
            projectile.timeLeft = 1200;
            aiType = ProjectileID.BoneJavelin;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Molten Javelin");
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 4; i < 31; i++)
            {
                float x = projectile.oldVelocity.X * (20f / i);
                float y = projectile.oldVelocity.Y * (20f / i);
                int newDust = Dust.NewDust(new Vector2(projectile.oldPosition.X - x, projectile.oldPosition.Y - y), 8, 8, 127, projectile.oldVelocity.X, projectile.oldVelocity.Y, 58, default(Color), 1.8f);
                Main.dust[newDust].noGravity = true;
                Main.dust[newDust].velocity *= 0.5f;
            }
        }
        public override void AI()
        {
            int a = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 127, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            projectile.ai[0] += 1f;
            Main.dust[a].noGravity = true;
            Main.dust[a].velocity *= 0.5f;
            if (projectile.ai[0] >= 50f)       //how much time the projectile can travel before landing
            {  // projectile fall velocity
                projectile.velocity.Y = projectile.velocity.X / 6f;    // projectile velocity
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {                                                           // sound that the projectile make when hiting the terrain
            {
                projectile.Kill();
                int a = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 127, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 10);
            }
            return false;
        }
    }
}