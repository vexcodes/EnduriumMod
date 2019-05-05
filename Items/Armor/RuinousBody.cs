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
    public class RuinousBody : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 18;

            item.value = 40000;
            item.rare = 8;
            item.defense = 16; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ruinous Chestplate");
            Tooltip.SetDefault("Increases melee and movement speed by 10%");
        }


        public override void UpdateEquip(Player player)
        {
		player.meleeSpeed += 0.1f;
        }
	  					           public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("RuinousCrystal"), 30);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
