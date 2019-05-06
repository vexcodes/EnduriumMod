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
    public class PlagueFeatherFriendly : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 28;
            projectile.aiStyle = 1;
            aiType = ProjectileID.Bullet;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.penetrate = 2;
            projectile.alpha = 75;
            projectile.timeLeft = 220;
        }
        public override void Kill(int timeLeft)
        {
            for (int num623 = 0; num623 < 15; num623++)
            {
                int num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 89, 0f, 0f, 100, default(Color), 1.6f);
                Main.dust[num624].noGravity = true;
                Main.dust[num624].velocity *= 4f;
            }
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plague Feather");
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
            return true;
        }
        public override void AI()
        {
            int num3;
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            for (int num20 = 0; num20 < 2; num20 = num3 + 3)
            {
                float num21 = projectile.velocity.X / 4f * (float)num20;
                float num22 = projectile.velocity.Y / 4f * (float)num20;
                int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 89, 0f, 0f, 0, default(Color), 0.6f);
                Main.dust[num23].position.X = projectile.Center.X - num21;
                Main.dust[num23].position.Y = projectile.Center.Y - num22;
                Dust dust3 = Main.dust[num23];
                dust3.velocity *= 0f;
                Main.dust[num23].scale = 0.2f;
                num3 = num20;
            }
        }
    }
}