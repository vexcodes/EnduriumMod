using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class PlanetarShard : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 28;
            projectile.friendly = true;
            projectile.aiStyle = 1;
            projectile.timeLeft = 20;
            projectile.magic = true;
            projectile.penetrate = -1;      //this is how many enemy this projectile penetrate before desapear 
            projectile.extraUpdates = 1;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Planet Shard");
        }
        public override void Kill(int timeLeft)
        {
            int num267 = Main.rand.Next(5, 9);
            int num3;
            for (int num268 = 0; num268 < num267; num268 = num3 + 1)
            {
                int num269 = Dust.NewDust(projectile.Center, 0, 0, 267, 0f, 0f, 100, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 1.4f);
                Dust dust = Main.dust[num269];
                dust.velocity *= 0.8f;
                Main.dust[num269].position = Vector2.Lerp(Main.dust[num269].position, projectile.Center, 0.5f);
                Main.dust[num269].noGravity = true;
                num3 = num268;
            }
            if (projectile.owner == Main.myPlayer)
            {
                Vector2 value11 = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
                if (Main.player[projectile.owner].gravDir == -1f)
                {
                    value11.Y = (float)(Main.screenHeight - Main.mouseY) + Main.screenPosition.Y;
                }
                Vector2 vector13 = Vector2.Normalize(value11 - projectile.Center);
                vector13 *= projectile.localAI[1];
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, mod.ProjectileType("PlanetStorm"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);

            }
        }
    }
}