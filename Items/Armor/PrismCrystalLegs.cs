using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class PrismCrystalLegs : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 18;

            item.value = 22500;
            item.rare = 5;
            item.defense = 7; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Void Crystal Leggings");
            Tooltip.SetDefault("Increases movement speed");
        }


        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.25f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("CursedHeart"));
						recipe.AddIngredient(null, ("PrismShard"), 4);
			recipe.AddIngredient(null, ("MagicPowder"), 5);
			recipe.AddIngredient(null, ("GraniteEnergyCore"), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
