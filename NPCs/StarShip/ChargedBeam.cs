using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.StarShip
{
    public class ChargedBeam : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 44;
            projectile.height = 44;
            projectile.hostile = true;
            projectile.penetrate = -1;

            projectile.timeLeft = 800;
            projectile.light = 1.25f;
            projectile.extraUpdates = 2;
            projectile.aiStyle = 1;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D glowmask = Main.projectileTexture[projectile.type];
            int glownum = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
            int y7 = glownum * projectile.frame;
            Main.spriteBatch.Draw(glowmask, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y7, glowmask.Width, glownum)), projectile.GetAlpha(Color.White), projectile.rotation, new Vector2((float)glowmask.Width / 2f, (float)glownum / 2f), projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            return false;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Charged Spike Shot");
        }

        public override bool PreAI()
        {
            projectile.rotation += 0.06f;
            int num3;
            for (int num20 = 0; num20 < 3; num20 = num3 + 3)
            {
                float num21 = projectile.velocity.X / 4f * (float)num20;
                float num22 = projectile.velocity.Y / 4f * (float)num20;
                int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 156, 0f, 0f, 0, default(Color), 0.2f);
                Main.dust[num23].position.X = projectile.Center.X - num21;
                Main.dust[num23].position.Y = projectile.Center.Y - num22;
                Dust dust3 = Main.dust[num23];
                dust3.velocity *= 0f;
                Main.dust[num23].scale = 1.5f;
                Main.dust[num23].noGravity = true;
                num3 = num20;
            }
            projectile.ai[1] += 1;
            Player player = Main.player[Main.myPlayer];
            float closestDist = 10000; //this is just some player-finding code i got from randomzachofkindness, thats his name now afaik. You should be fine using it, since i have permission to use it and i made this ModProjectile class
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
            return false;
        }
    }
}