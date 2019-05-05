using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.StarShip
{
    public class StarRock1 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star meteor");
        }
        public override void SetDefaults()
        {
            projectile.width = 36;
            projectile.height = 34;
            projectile.tileCollide = false;
            projectile.hostile = true;
            Main.projFrames[projectile.type] = 5;
            projectile.penetrate = 5;
            projectile.timeLeft = 1000;
            projectile.scale = 1.2f;
            projectile.extraUpdates = 1;
        }
        float charge = 0f;
        float AI1 = 0f;
        float AI2 = 0f;
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D glowmask = Main.projectileTexture[projectile.type];
            int glownum = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
            int y7 = glownum * projectile.frame;
            Main.spriteBatch.Draw(glowmask, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y7, glowmask.Width, glownum)), projectile.GetAlpha(Color.White), projectile.rotation, new Vector2((float)glowmask.Width / 2f, (float)glownum / 2f), projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            return false;
        }
        public override void AI()
        {
            projectile.rotation = 0f;
            if (AI2 <= 600)
            {
                if (projectile.localAI[1] == 1)
                {
                    AI2 -= 1f;
                }
                else
                {
                    AI2 += 1f;
                }
            }
            if (AI2 == 600)
            {
                projectile.localAI[1] = 1;
            }
            projectile.rotation += Main.rand.NextFloat(0.04f, 0.08f);
            double deg = (double)projectile.localAI[0];
            double rad = deg * (Math.PI / 180);
            double dist = AI2;
            projectile.position.X = projectile.ai[0] - (int)(Math.Cos(rad) * dist);
            projectile.position.Y = projectile.ai[1] - (int)(Math.Sin(rad) * dist);
            if (charge <= 4f)
            {
                charge += 0.08f;
            }
            projectile.localAI[0] += charge;
            projectile.frameCounter++;
            if (projectile.frameCounter > 5)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 4)
            {
                projectile.frame = 0;
            }
            Vector2 position = projectile.Center + Vector2.Normalize(projectile.velocity) * 2f;
            int num;
            for (int num190 = 0; num190 < 1; num190 = num + 1)
            {
                int num191 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 156, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num191].velocity *= 0.5f;
                Main.dust[num191].scale *= 1.3f;
                Main.dust[num191].fadeIn = 1f;
                Main.dust[num191].noGravity = true;
                num = num190;
            }
        }
    }
}