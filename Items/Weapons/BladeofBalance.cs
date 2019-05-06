using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class BladeofBalance : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 200;
            item.melee = true;
            item.width = 74;
            item.height = 104;
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = 1;

            item.knockBack = 1;
            item.value = 30000000;
            item.rare = 8;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("BoltofBalance");
            item.shootSpeed = 12f;
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            int i = Main.myPlayer;
            {
                float num82 = (float)Main.mouseX + Main.screenPosition.X - position.X;
                float num83 = (float)Main.mouseY + Main.screenPosition.Y - position.Y;
                int num76 = 24;
                int num75 = mod.ProjectileType("BladeofBalance");
                int num77 = (int)((float)item.damage * player.meleeDamage);
                int num78 = 5;
                float f = Main.rand.NextFloat() * 6.28318548f;
                float value8 = 60f;
                float value9 = 20f;
                Vector2 vector26 = position + f.ToRotationVector2() * MathHelper.Lerp(value8, value9, Main.rand.NextFloat());
                int num2;
                for (int num209 = 0; num209 < 50; num209 = num2 + 3)
                {
                    vector26 = position + f.ToRotationVector2() * MathHelper.Lerp(value8, value9, Main.rand.NextFloat());
                    if (Collision.CanHit(position, 0, 0, vector26 + (vector26 - position).SafeNormalize(Vector2.UnitX) * 8f, 0, 0))
                    {
                        break;
                    }
                    f = Main.rand.NextFloat() * 6.28318548f;
                    num2 = num209;
                }
                Vector2 mouseWorld = Main.MouseWorld;
                Vector2 vector27 = mouseWorld - vector26;
                Vector2 vector28 = new Vector2(num82, num83).SafeNormalize(Vector2.UnitY) * num76;
                vector27 = vector27.SafeNormalize(vector28) * num76;
                vector27 = Vector2.Lerp(vector27, vector28, 0.25f);
                Projectile.NewProjectile(vector26, vector27, num75, num77, num78, i, 0f, 0f);
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("BladeofBalance"), damage, knockBack, player.whoAmI, 0f, 0f); //This is spawning a projectile of type FrostburnArrow using the original stats
            }
            {
                float num72 = item.shootSpeed;
                int num73 = damage;
                float num74 = knockBack;
                num74 = player.GetWeaponKnockback(item, num74);
                player.itemTime = item.useTime;
                Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
                float num78 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
                float num79 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
                if (player.gravDir == -1f)
                {
                    num79 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector2.Y;
                }
                float num80 = (float)Math.Sqrt((double)(num78 * num78 + num79 * num79));
                float num81 = num80;
                if ((float.IsNaN(num78) && float.IsNaN(num79)) || (num78 == 0f && num79 == 0f))
                {
                    num78 = (float)player.direction;
                    num79 = 0f;
                    num80 = num72;
                }
                else
                {
                    num80 = num72 / num80;
                }
                num78 *= num80;
                num79 *= num80;
                int num107 = 4;
                for (int num108 = 0; num108 < num107; num108++)
                {
                    vector2 = new Vector2(player.position.X + (float)player.width * 0.5f + (float)(Main.rand.Next(201) * -(float)player.direction) + ((float)Main.mouseX + Main.screenPosition.X - player.position.X), player.MountedCenter.Y);
                    vector2.X = (vector2.X + player.Center.X) / 2f + (float)Main.rand.Next(-300, 301);
                    vector2.Y -= (float)(100 * num108);
                    num78 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
                    num79 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
                    if (num79 < 0f)
                    {
                        num79 *= -1f;
                    }
                    if (num79 < 20f)
                    {
                        num79 = 30f;
                    }
                    num80 = (float)Math.Sqrt((double)(num78 * num78 + num79 * num79));
                    num80 = num72 / num80;
                    num78 *= num80;
                    num79 *= num80;
                    float speedX4 = num78 + (float)Main.rand.Next(-50, 41) * 0.02f;
                    float speedY5 = num79 + (float)Main.rand.Next(-50, 41) * 0.02f;
                    int projectile = Projectile.NewProjectile(vector2.X, vector2.Y, speedX4, speedY5, mod.ProjectileType("BladeofBalance"), num73, num74, i, 0f, (float)Main.rand.Next(15));
                }
            }
            return true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blade of Balance");
            Tooltip.SetDefault("");
        }
    }
}