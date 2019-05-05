using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.MiniBiomes
{
    public class RosyFire : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rosy Fire");
        }
        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 24;
            projectile.timeLeft = 210;
            projectile.penetrate = 1;
            projectile.hostile = true;
            projectile.tileCollide = true;
            projectile.ignoreWater = false;
            projectile.alpha = 255;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D glowmask = Main.projectileTexture[projectile.type];
            int glownum = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
            int y7 = glownum * projectile.frame;
            Main.spriteBatch.Draw(glowmask, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y7, glowmask.Width, glownum)), projectile.GetAlpha(Color.White), projectile.rotation, new Vector2((float)glowmask.Width / 2f, (float)glownum / 2f), projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            return false;
        }
        int dustpos1 = 180;
        int dustpos2 = 0;
        double dist = 12;
        public override void AI()
        {
            int num;
            projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;


            double deg1 = (double)dustpos1;
            double deg2 = (double)dustpos2;
            double rad1 = deg1 * (Math.PI / 180);
            double rad2 = deg2 * (Math.PI / 180);
            int a = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.dust[a].noGravity = true;
            Main.dust[a].velocity *= 1;
            Main.dust[a].scale *= 1f;
            Main.dust[a].position.X = projectile.Center.X - (int)(Math.Cos(rad1) * dist) - projectile.width / 2;
            Main.dust[a].position.Y = projectile.Center.Y - (int)(Math.Sin(rad1) * dist) - projectile.height / 2;

            int b = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.dust[b].noGravity = true;
            Main.dust[b].velocity *= 1;
            Main.dust[b].scale *= 1f;
            Main.dust[b].position.X = projectile.Center.X - (int)(Math.Cos(rad2) * dist) - projectile.width / 2;
            Main.dust[b].position.Y = projectile.Center.Y - (int)(Math.Sin(rad2) * dist) - projectile.height / 2;

            dustpos1 += 6;
            dustpos2 += 6;

            if (projectile.timeLeft <= 150)
            {
                if (dist >= 3)
                {
                    dist -= 1;
                }
            }
            if (projectile.timeLeft == 150)
            {
                Player player = Main.player[Main.myPlayer];
                float closestDist = 10000;
                int chosenPlayer = Main.myPlayer;
                for (int i = 0; i < 255; i++)
                {
                    if (i == 0) closestDist = Vector2.Distance(Main.player[i].Center, projectile.Center);
                    else if (Vector2.Distance(Main.player[i].Center, projectile.Center) < closestDist)
                    {
                        closestDist = Vector2.Distance(Main.player[i].Center, projectile.Center);
                        chosenPlayer = i;
                    }
                }
                float maxSpeed = 13f; //MOVEMENT SPEED
                Vector2 toTarget = new Vector2(player.Center.X - projectile.Center.X, player.Center.Y - projectile.Center.Y);
                toTarget = new Vector2(player.Center.X - projectile.Center.X, player.Center.Y - projectile.Center.Y);
                toTarget.Normalize();
                projectile.velocity = toTarget * maxSpeed;
                player = Main.player[chosenPlayer];
            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1, 1f, 0f);
        }
    }
}