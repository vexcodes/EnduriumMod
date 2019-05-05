using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class PurityPrism : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prism of Nature");
        }
        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 26;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 1200;
            projectile.alpha = 100;
            projectile.magic = true;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
            for (int num621 = 0; num621 < 15; num621++)
            {
                int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 89, 0f, 0f, 100, default(Color), 1.2f);
                Main.dust[num622].velocity *= 0.5f;
            }
        }

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
            Player player = Main.player[Main.myPlayer];
            bool flag1 = true;
            int num3;
            for (int num432 = 0; num432 < 1000; num432 = num3 + 1)
            {
                if (num432 != projectile.whoAmI && Main.projectile[num432].active && Main.projectile[num432].owner == projectile.owner && Main.projectile[num432].type == projectile.type && projectile.timeLeft > Main.projectile[num432].timeLeft && Main.projectile[num432].timeLeft > 30)
                {
                    flag1 = false;
                    projectile.netUpdate = true;
                    Main.projectile[num432].timeLeft = 30;
                }
                num3 = num432;
            }
            projectile.velocity.X *= 0f;
            projectile.velocity.Y *= 0f;
            MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(mod, "MyPlayer");

            if (modPlayer.UsedPrismStaff && flag1)
            {
                modPlayer.UsedPrismStaff = false;
                projectile.netUpdate = true;
                Main.PlaySound(3, (int)projectile.position.X, (int)projectile.position.Y, 1, 1f, 0f);
                int num626 = 1;
                for (int num627 = 0; num627 < num626; num627 = num3 + 1)
                {
                    float num628 = (float)Main.rand.Next(-35, 36) * 0.02f;
                    float num629 = (float)Main.rand.Next(-35, 36) * 0.02f;
                    num628 *= 10f;
                    num629 *= 10f;
                    int data = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, num628, num629, mod.ProjectileType("BloomCard"), projectile.damage, 0f, Main.myPlayer, 0f, 0f);
                    Main.projectile[data].penetrate = 1;
                    Main.projectile[data].netUpdate = true;
                    num3 = num627;

                }

            }
        }
    }
}