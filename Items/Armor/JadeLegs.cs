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
    public class JadeLegs : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 18;

            item.value = 12500;
            item.rare = 6;
            item.defense = 5; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jade Greaves");
            Tooltip.SetDefault("Decreases mana cost by 13%");
        }


        public override void UpdateEquip(Player player)
        {
		            player.manaCost *= 0.87f;
        }
				        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("Jade"), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
