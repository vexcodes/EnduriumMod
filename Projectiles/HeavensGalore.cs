using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;

namespace EnduriumMod.Projectiles
{
    public class HeavensGalore : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 38;
            projectile.height = 38;
            projectile.aiStyle = 27;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = 1;
            projectile.extraUpdates = 2;
            projectile.alpha = 0;
            projectile.timeLeft = 800;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heavens Galore");
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D glowmask = Main.projectileTexture[projectile.type];
            int glownum = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
            int y7 = glownum * projectile.frame;
            Main.spriteBatch.Draw(glowmask, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y7, glowmask.Width, glownum)), projectile.GetAlpha(Color.White), projectile.rotation, new Vector2((float)glowmask.Width / 2f, (float)glownum / 2f), projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            return false;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
        public override void AI()
        {
            int num;
            int num144 = Utils.SelectRandom<int>(Main.rand, new int[]
{
                    229,
                    261
});
            int a = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, num144, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.dust[a].scale = 0.5f;
            Main.dust[a].position = projectile.Center;
            Main.dust[a].velocity *= 0f;

            Player owner = Main.player[projectile.owner]; //Makes a player variable of owner set as the player using the projectile
        }
        public override void Kill(int timeLeft)
        {
            Vector2 vector19 = projectile.position;
            Vector2 oldVelocity = projectile.oldVelocity;
            oldVelocity.Normalize();
            vector19 += oldVelocity * 16f;
            int num3;
            for (int num355 = 0; num355 < 12; num355 = num3 + 1)
            {
                int num144 = Utils.SelectRandom<int>(Main.rand, new int[]
{
                        229,
                        261
});
                int num356 = Dust.NewDust(vector19, projectile.width, projectile.height, num144, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num356].position = (Main.dust[num356].position + projectile.Center) / 2f;
                Dust dust = Main.dust[num356];
                dust.velocity += projectile.oldVelocity * 1.4f;
                dust = Main.dust[num356];
                dust.velocity *= 0.8f;
                dust.fadeIn *= 2.8f;
                Main.dust[num356].noGravity = true;
                vector19 -= oldVelocity * 2f;
                num3 = num355;
            }
        }
    }
}