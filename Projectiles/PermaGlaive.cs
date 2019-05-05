using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles     //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class PermaGlaive : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Perma-Glaive");
        }

        public override void SetDefaults()
        {
            projectile.width = 98;
            projectile.height = 98;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.melee = true;
        }
        int nut = 48;
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
            Player player = Main.player[projectile.owner];
            //-------------------------------------------------------------Sound-------------------------------------------------------
            projectile.soundDelay--;
            if (projectile.soundDelay <= 0)//this is the proper sound delay for this type of weapon
            {
                Main.PlaySound(2, (int)projectile.Center.X, (int)projectile.Center.Y, 15);    //this is the sound when the weapon is used
                projectile.soundDelay = 48;    //this is the proper sound delay for this type of weapon
            }
            nut -= 1;
            if (nut == 0)
            {
                nut = 28;
                Main.PlaySound(3, (int)projectile.position.X, (int)projectile.position.Y, 1, 1f, 0f);
                int num3;
                int num626 = 4;
                if (Main.rand.Next(2) == 0)
                {
                    num3 = num626;
                    num626 = num3 + 2;
                }
                if (Main.rand.Next(2) == 0)
                {
                    num3 = num626;
                    num626 = num3 + 2;
                }
                if (Main.rand.Next(2) == 0)
                {
                    num3 = num626;
                    num626 = num3 + 2;
                }
                for (int num627 = 0; num627 < num626; num627 = num3 + 1)
                {
                    float num628 = (float)Main.rand.Next(-35, 36) * 0.02f;
                    float num629 = (float)Main.rand.Next(-35, 36) * 0.02f;
                    num628 *= 10f;
                    num629 *= 10f;
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, num628, num629, mod.ProjectileType("VoidParasite"), (int)(154 * player.meleeDamage), 5f, Main.myPlayer, 0f, 0f);
                    num3 = num627;
                }
            }
            //-----------------------------------------------How the projectile works---------------------------------------------------------------------
            if (Main.myPlayer == projectile.owner)
            {
                if (!player.channel || player.noItems || player.CCed)
                {
                    projectile.Kill();
                }
            }
            Lighting.AddLight(projectile.Center, 1f, 0.6f, 1.2f);     //this is the projectile light color R, G, B (Red, Green, Blue)
            projectile.Center = player.MountedCenter;
            projectile.position.X += player.width / 2 * player.direction;  //this is the projectile width sptrite direction from the playr
            projectile.spriteDirection = player.direction;
            projectile.rotation += 0.2f * player.direction; //this is the projectile rotation/spinning speed
            if (projectile.rotation > MathHelper.TwoPi)
            {
                projectile.rotation -= MathHelper.TwoPi;
            }
            else if (projectile.rotation < 0)
            {
                projectile.rotation += MathHelper.TwoPi;
            }
            player.heldProj = projectile.whoAmI;
            player.itemTime = 2;
            player.itemAnimation = 2;
            player.itemRotation = projectile.rotation;
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 173);  //this is the dust that this projectile will spawn
            Main.dust[dust].velocity /= 1f;

        }
    }
}