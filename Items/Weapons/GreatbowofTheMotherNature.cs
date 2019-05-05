using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class GreatbowofTheMotherNature : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 140;
            item.ranged = true;
            item.width = 40;
            item.height = 78;
            item.useAnimation = 20;
            item.useTime = 20;

            item.useStyle = 5;
            item.knockBack = 6f;
            item.value = 800000;
            item.rare = 9;
            item.UseSound = SoundID.Item102;
            item.autoReuse = true;
            item.useTurn = false;
            item.shoot = 3;
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 4f;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terrestial Greatbow of Earth");
            Tooltip.SetDefault("Turns all arrows into terrestial energy");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("GreatbowOfCinder"));
            recipe.AddIngredient(null, ("SoulofDusk"), 25);
            recipe.AddTile(null, "AltarofNature");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int i = Main.myPlayer;
            {
                float num82 = (float)Main.mouseX + Main.screenPosition.X - position.X;
                float num83 = (float)Main.mouseY + Main.screenPosition.Y - position.Y;
                Vector2 vector23 = new Vector2(num82, num83);
                int num75 = mod.ProjectileType("Terrestial");
                int num77 = (int)((float)item.damage * player.rangedDamage);
                int num78 = 2;
                vector23 *= 0.5f;
                Vector2 value4 = vector23.SafeNormalize(-Vector2.UnitY);
                float num201 = 0.0174532924f * -(float)player.direction;
                for (float num202 = -2.5f; num202 < 2f; num202 += 1f)
                {
                    Projectile.NewProjectile(position, (vector23 + value4 * num202 * 0.5f).RotatedBy((double)(num202 * num201), default(Vector2)), num75, num77, num78, i, 0f, 0f);
                }
                return false;

            }
        }
    }
}
