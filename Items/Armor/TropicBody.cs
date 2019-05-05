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
    public class TropicBody : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 18;

            item.value = 72500;
            item.rare = 5;
            item.defense = 14; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tropic Breastplate");
            Tooltip.SetDefault("Increases throwing critical strike chance by 12%\nGreatly increases running speed");
        }


        public override void UpdateEquip(Player player)
        {
            player.thrownCrit += 12;
			player.runAcceleration *= 1.35f;
			player.maxRunSpeed *= 1.12f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "TropicalFragment", 1);
			            recipe.AddRecipeGroup("Tier3HMBars", 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
