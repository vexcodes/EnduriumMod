using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace EnduriumMod.Projectiles
{
    public class FacemelterNote : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Face Melter");
        }
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.friendly = true;
            projectile.scale *= 1.25f;
            projectile.aiStyle = -1;
            projectile.ranged = true;
            projectile.penetrate = 1;      //this is how many enemy this projectile penetrate before desapear 
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D glowmask = Main.projectileTexture[projectile.type];
            int glownum = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];

            Texture2D glowmask2 = mod.GetTexture("Projectiles/FacemelterNote_Overlay");
            int glownum2 = mod.GetTexture("Projectiles/FacemelterNote_Overlay").Height / Main.projFrames[projectile.type];

            int y7 = glownum2 * projectile.frame;

            Main.spriteBatch.Draw(glowmask, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y7, glowmask.Width, glownum)), projectile.GetAlpha(Color.White), projectile.rotation, new Vector2((float)glowmask.Width / 2f, (float)glownum / 2f), projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            Main.spriteBatch.Draw(glowmask2, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y7, glowmask2.Width, glownum2)), projectile.GetAlpha(Color.White) * 0.33f, projectile.rotation, new Vector2((float)glowmask2.Width / 2f, (float)glownum2 / 2f), (projectile.scale * 1.5f), projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            return false;
        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            if (Main.mouseLeft)
            {
                projectile.position.X += player.velocity.X * 0.8f;
                projectile.position.Y += player.velocity.Y * 0.8f;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
        }
        public override void Kill(int timeLeft)
        {
            for (int num2 = 0; num2 < 3; num2++)
            {
                int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 133, 0f, 0f, 175, default(Color), 1.2f);
                Main.dust[num].velocity *= 1.1f;
                Main.dust[num].noGravity = true;
            }
        }
    }
}