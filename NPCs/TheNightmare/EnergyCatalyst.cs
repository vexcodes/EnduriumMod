using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.TheNightmare
{
    public class EnergyCatalyst : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 100;
            projectile.height = 100;
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.penetrate = 12;
            projectile.scale = 0.4f;
            projectile.timeLeft = 400;
            projectile.alpha = 255;
            projectile.aiStyle = -1;
            Main.projFrames[projectile.type] = 4;
            projectile.light = 2.5f;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 2;
            ProjectileID.Sets.TrailingMode[projectile.type] = 5;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Energy Catalyst");
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            //Redraw the projectile with the color not influenced by light
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }

        float Speed = 17f;
        public override void AI()
        {
            int num;
            projectile.frameCounter++;
            projectile.ai[1] += 1;
            if (projectile.frameCounter > 4)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 4)
            {
                projectile.frame = 0;
            }

            if (projectile.alpha >= 0)
            {
                projectile.alpha -= 2;
            }

            if (projectile.alpha <= 0)
            {
                projectile.alpha = 0;
            }

            if (projectile.scale <= 1.25f)
            {
                projectile.scale += 0.02f;
            }

            if (projectile.scale >= 1.25f)
            {
                projectile.scale = 1.25f;
            }
            if (projectile.ai[1] == 80)
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
                player = Main.player[chosenPlayer];
                projectile.velocity = Vector2.Normalize(player.Center - projectile.Center) * Speed;
                for (int num621 = 0; num621 < 16; num621++)
                {
                    int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 156, 0f, 0f, 100, default(Color), 1.2f);
                    Main.dust[num622].velocity *= 7f;
                    Main.dust[num622].noGravity = true;
                }
            }
        }
    }
}