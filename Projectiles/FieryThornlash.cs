using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class FieryThornlash : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.scale = 1.25f;
            projectile.height = 30;
            projectile.aiStyle = 15;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.timeLeft = 2400;
            projectile.extraUpdates = 1;
            projectile.penetrate = 3;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 12;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (projectile.penetrate == 1)
            {
                Main.PlaySound(3, (int)projectile.position.X, (int)projectile.position.Y, 1, 1f, 0f);
                int num3;
                for (int num622 = 0; num622 < 20; num622 = num3 + 1)
                {
                    int num623 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 184, 0f, 0f, 0, default(Color), 1f);
                    Dust dust = Main.dust[num623];
                    dust.scale *= 1.2f;
                    Main.dust[num623].noGravity = true;
                    num3 = num622;
                }
                for (int num622 = 0; num622 < 20; num622 = num3 + 1)
                {
                    int num623 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 173, 0f, 0f, 0, default(Color), 1.1f);
                    Dust dust = Main.dust[num623];
                    dust.scale *= 1.2f;
                    Main.dust[num623].noGravity = true;
                    num3 = num622;
                }
                for (int num624 = 0; num624 < 30; num624 = num3 + 1)
                {
                    int num625 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 184, 0f, 0f, 0, default(Color), 1f);
                    Dust dust = Main.dust[num625];
                    dust.velocity *= 2.5f;
                    dust = Main.dust[num625];
                    dust.scale *= 0.9f;
                    Main.dust[num625].noGravity = true;
                    num3 = num624;
                }
                if (projectile.owner == Main.myPlayer)
                {
                    int num626 = 5;
                    if (Main.rand.Next(2) == 0)
                    {
                        num3 = num626;
                        num626 = num3 + 1;
                    }
                    if (Main.rand.Next(2) == 0)
                    {
                        num3 = num626;
                        num626 = num3 + 1;
                    }
                    if (Main.rand.Next(2) == 0)
                    {
                        num3 = num626;
                        num626 = num3 + 1;
                    }
                    for (int num627 = 0; num627 < num626; num627 = num3 + 5)
                    {
                        float num628 = (float)Main.rand.Next(-35, 36) * 0.02f;
                        float num629 = (float)Main.rand.Next(-35, 36) * 0.02f;
                        num628 *= 20f;
                        num629 *= 20f;
                        Projectile.NewProjectile(projectile.position.X, projectile.position.Y, num628, num629, mod.ProjectileType("Flame"), (int)((double)projectile.damage * 0.75), (float)((int)((double)projectile.knockBack * 0.35)), Main.myPlayer, 0f, 0f);
                        num3 = num627;
                    }
                }
            }
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fiery Thornlash");
        }


        // Now this is where the chain magic happens. You don't have to try to figure this whole thing out.
        // Just make sure that you edit the first line (which starts with 'Texture2D texture') correctly.
        public override bool PreDraw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Color lightColor)
        {
            // So set the correct path here to load the chain texture. 'YourModName' is of course the name of your mod.
            // Then into the Projectiles folder and take the texture that is called 'CustomFlailBall_Chain'.
            Texture2D texture = ModLoader.GetTexture("EnduriumMod/Projectiles/FieryThornlashChain");

            Vector2 position = projectile.Center;
            Vector2 mountedCenter = Main.player[projectile.owner].MountedCenter;
            Microsoft.Xna.Framework.Rectangle? sourceRectangle = new Microsoft.Xna.Framework.Rectangle?();
            Vector2 origin = new Vector2((float)texture.Width * 0.5f, (float)texture.Height * 0.5f);
            float num1 = (float)texture.Height;
            Vector2 vector2_4 = mountedCenter - position;
            float rotation = (float)Math.Atan2((double)vector2_4.Y, (double)vector2_4.X) - 1.57f;
            bool flag = true;
            if (float.IsNaN(position.X) && float.IsNaN(position.Y))
                flag = false;
            if (float.IsNaN(vector2_4.X) && float.IsNaN(vector2_4.Y))
                flag = false;
            while (flag)
            {
                if ((double)vector2_4.Length() < (double)num1 + 1.0)
                {
                    flag = false;
                }
                else
                {
                    Vector2 vector2_1 = vector2_4;
                    vector2_1.Normalize();
                    position += vector2_1 * num1;
                    vector2_4 = mountedCenter - position;
                    Microsoft.Xna.Framework.Color color2 = Lighting.GetColor((int)position.X / 16, (int)((double)position.Y / 16.0));
                    color2 = projectile.GetAlpha(color2);
                    Main.spriteBatch.Draw(texture, position - Main.screenPosition, sourceRectangle, color2, rotation, origin, 1f, SpriteEffects.None, 0.0f);
                }
            }

            return true;
        }
    }
}