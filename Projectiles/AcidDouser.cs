using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class AcidDouser : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 28;
            projectile.height = 28;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.magic = true;
            projectile.ignoreWater = true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Acid Douser");
        }
        float num006 = 0.8f;
        float num009 = 0.5f;
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            float num = 1.57079637f;
            Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
            projectile.ai[0] += 1f;
            int num2 = 0;
            int num3 = 21;
            int num4 = 7;
            float num007 = num006 / 10;
            float num008 = num006 / 20;
            projectile.ai[1] += 1f;
            if (num006 >= 0.08f)
            {
                num006 -= 0.0005f;
            }

            bool flag = false;
            if (projectile.ai[1] >= 18)
            {
                flag = true;
                projectile.ai[1] = 0f;
            }
            int num16 = 0;
            Vector2 vector13 = Vector2.UnitX * 18f;
            vector13 = vector13.RotatedBy((double)(projectile.rotation - 1.57079637f), default(Vector2));
            Vector2 value6 = projectile.Center + vector13;
            for (int k = 0; k < num16 + 1; k++)
            {
                int num18 = 89;
                float num19 = 1.1f;
                if (k % 2 == 1)
                {
                    num18 = 226;
                    num19 = 1.65f;
                }
                Vector2 vector14 = value6 + ((float)Main.rand.NextDouble() * 6.28318548f).ToRotationVector2() * (12f - (float)(num16 * 2));
                int num20 = Dust.NewDust(vector14 - Vector2.One * 8f, 16, 16, num18, projectile.velocity.X / 2f, projectile.velocity.Y / 2f, 0, default(Color), 0.6f);
                Main.dust[num20].velocity = Vector2.Normalize(value6 - vector14) * 1.5f * (10f - (float)num16 * 2f) / 10f;
                Main.dust[num20].noGravity = true;
                Main.dust[num20].scale = num19;
                Main.dust[num20].customData = player;
            }
            projectile.frameCounter += 1 + num2;
            if (projectile.frameCounter >= 4)
            {
                projectile.frameCounter = 0;
                projectile.frame++;
                if (projectile.frame >= 6)
                {
                    projectile.frame = 0;
                }
            }
            if (flag && Main.myPlayer == projectile.owner)
            {
                bool flag2 = player.channel && player.CheckMana(player.inventory[player.selectedItem].mana, true, false) && !player.noItems && !player.CCed;
                if (flag2)
                {
                    float scaleFactor = player.inventory[player.selectedItem].shootSpeed * projectile.scale;
                    Vector2 vector3 = vector;
                    Vector2 value2 = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY) - vector3;
                    if (player.gravDir == -1f)
                    {
                        value2.Y = (float)(Main.screenHeight - Main.mouseY) + Main.screenPosition.Y - vector3.Y;
                    }
                    Vector2 vector4 = Vector2.Normalize(value2);
                    if (float.IsNaN(vector4.X) || float.IsNaN(vector4.Y))
                    {
                        vector4 = -Vector2.UnitY;
                    }
                    vector4 *= scaleFactor;
                    if (vector4.X != projectile.velocity.X || vector4.Y != projectile.velocity.Y)
                    {
                        projectile.netUpdate = true;
                    }
                    projectile.velocity = vector4;
                    float spread1 = 0.002f;
                    float spread2 = 0.004f;
                    
                    int num6 = mod.ProjectileType("AcidDouser1");
                    float scaleFactor2 = 10f;
                    int num7 = 6;
                    for (int j = 0; j < 1; j++)
                    {
                        vector3 = projectile.Center + new Vector2((float)Main.rand.Next(-num7, num7 + 1), (float)Main.rand.Next(-num7, num7 + 1));
                        Vector2 vector5 = Vector2.Normalize(projectile.velocity) * scaleFactor2;
                        vector5 = vector5.RotatedBy(Main.rand.NextDouble() * num006 - num006 / 2, default(Vector2));
                        if (float.IsNaN(vector5.X) || float.IsNaN(vector5.Y))
                        {
                            vector5 = -Vector2.UnitY;
                        }
                        Projectile.NewProjectile(vector3.X, vector3.Y, vector5.X, vector5.Y, num6, projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
                        Main.PlaySound(SoundID.Item11, projectile.position);
                    }
                    if (Main.rand.Next(5) == 0)
                    {
                        for (int j = 0; j < 1; j++)
                        {
                            vector3 = projectile.Center + new Vector2((float)Main.rand.Next(-num7, num7 + 1), (float)Main.rand.Next(-num7, num7 + 1));
                            Vector2 vector5 = Vector2.Normalize(projectile.velocity) * scaleFactor2;
                            vector5 = vector5.RotatedBy(Main.rand.NextDouble() * num009 - num009 / 2, default(Vector2));
                            if (float.IsNaN(vector5.X) || float.IsNaN(vector5.Y))
                            {
                                vector5 = -Vector2.UnitY;
                            }
                            Projectile.NewProjectile(vector3.X, vector3.Y, vector5.X, vector5.Y, mod.ProjectileType("AcidDouser2"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
                        }
                    }
                }
                else
                {
                    projectile.Kill();
                }
            }
            projectile.position = player.RotatedRelativePoint(player.MountedCenter, true) - projectile.Size / 2f;
            projectile.rotation = projectile.velocity.ToRotation() + num;
            projectile.spriteDirection = projectile.direction;
            projectile.timeLeft = 2;
            player.ChangeDir(projectile.direction);
            player.heldProj = projectile.whoAmI;
            player.itemTime = 2;
            player.itemAnimation = 2;
            player.itemRotation = (float)Math.Atan2((double)(projectile.velocity.Y * (float)projectile.direction), (double)(projectile.velocity.X * (float)projectile.direction));
        }
    }
}