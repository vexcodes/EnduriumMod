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
    public class TropicLegs : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 18;

            item.value = 72500;
            item.rare = 5;
            item.defense = 8; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tropic Shoes");
            Tooltip.SetDefault("Increases throwing velocity by 10%\nIncreases movement speed by 18%");
        }


        public override void UpdateEquip(Player player)
        {
            player.thrownVelocity += 0.1f;
			player.moveSpeed *= 1.1f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "TropicalFragment", 1);
			            recipe.AddRecipeGroup("Tier3HMBars", 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
