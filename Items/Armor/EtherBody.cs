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
    public class EtherBody : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 18;

            item.value = 40000;
            item.rare = 5;
            item.defense = 9; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ether Bodyplate");
            Tooltip.SetDefault("Increases max minions");
        }


        public override void UpdateEquip(Player player)
        {
			player.maxMinions += 3;
        }
	  					           public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("FrigidFragment"), 16);
			            recipe.AddIngredient(null, ("DuskSteel"), 24);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
