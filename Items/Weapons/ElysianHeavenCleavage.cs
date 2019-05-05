using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class ElysianHeavenCleavage : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 100;
            item.magic = true;
            item.mana = 10;
            item.width = 54;
            item.height = 54;
            item.useAnimation = 9;
            item.useTime = 3;
            item.reuseDelay = 4;
            item.useStyle = 5;
            Item.staff[item.type] = true;
            item.knockBack = 4f;
            item.value = 5000000;
            item.rare = 9;
            item.UseSound = SoundID.Item9;
            item.autoReuse = true;
            item.useTurn = false;
            item.shoot = 660;
            item.shootSpeed = 20f;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elysian Division");
            Tooltip.SetDefault("");
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int i = Main.myPlayer;
            float num82 = (float)Main.mouseX + Main.screenPosition.X - position.X;
            float num83 = (float)Main.mouseY + Main.screenPosition.Y - position.Y;
            int num76 = 24;
            int num75 = Main.rand.Next(2);
            if (num75 == 0)
            {
                num75 = mod.ProjectileType("HeavenRupture");
            }
            else
            {
                num75 = mod.ProjectileType("TrueHeavenRupture");
            }
            int num77 = (int)((float)item.damage * player.magicDamage);
            int num78 = 2;
            float f = Main.rand.NextFloat() * 6.28318548f;
            float value8 = 30f;
            float value9 = 100f;
            Vector2 vector26 = position + f.ToRotationVector2() * MathHelper.Lerp(value8, value9, Main.rand.NextFloat());
            int num2;
            for (int num209 = 0; num209 < 50; num209 = num2 + 1)
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
            return false;
        }
    }
}