using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class PrismCrystalBody : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 22;
            item.height = 22;

            item.value = 122000;
            item.rare = 5;
            item.defense = 3; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Voidwalker Breastplate");
            Tooltip.SetDefault("Increases melee critical strike chance by 12%");
        }


        public override void UpdateEquip(Player player)
        {
            player.meleeCrit += 12;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("CursedHeart"));
			recipe.AddIngredient(null, ("PrismShard"), 6);
			recipe.AddIngredient(null, ("MagicPowder"), 8);
			recipe.AddIngredient(null, ("CrypticPowerCell"), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}