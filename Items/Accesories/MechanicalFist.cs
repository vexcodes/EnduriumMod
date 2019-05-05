using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    [AutoloadEquip(EquipType.HandsOn)]
    public class MechanicalFist : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 24;
            item.height = 34;
            item.value = Terraria.Item.buyPrice(0, 20, 50, 0);
            item.rare = 6;
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical Fist");
            Tooltip.SetDefault("Increases melee knockback\nIncreases melee damage, critical strike chance and speed by 15%");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
		player.kbGlove = true;
		            player.meleeDamage += 0.15f;
		            player.meleeCrit += 15;
				player.meleeSpeed += 0.15f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MechanicalGlove);
			recipe.AddIngredient(ItemID.EyeoftheGolem);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
