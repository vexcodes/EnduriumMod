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
    public class OvergrowthLegs : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 18;

            item.value = 32500;
            item.rare = 8;
            item.defense = 10; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endurian Leggings");
            Tooltip.SetDefault("Increases critical strike chance by 18%");
        }
			  					           public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("AcidCore"), 21);
						            recipe.AddIngredient(null, ("DarkDust"), 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownCrit += 18;
            player.rangedCrit += 18;
            player.magicCrit += 18;
            player.meleeCrit += 18;
        }

    }
}
