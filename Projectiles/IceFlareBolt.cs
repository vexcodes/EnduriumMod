using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class IceFlareBolt : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 34;
            projectile.friendly = true;
            projectile.aiStyle = 1;
            projectile.magic = true;
            projectile.penetrate = 3;      //this is how many enemy this projectile penetrate before desapear 
            projectile.extraUpdates = 1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frost Magic");
        }


        public override void AI()
        {
            int a = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 156, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.dust[a].velocity *= 0.3f;
            Main.dust[a].noGravity = true;
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
                int a = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 156, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                Main.dust[a].velocity *= 2f;
                Main.dust[a].noGravity = true;
            }
            return false;
        }
    }
}