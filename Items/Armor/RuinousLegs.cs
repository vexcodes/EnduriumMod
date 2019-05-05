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
    public class RuinousLegs : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 18;

            item.value = 40000;
            item.rare = 8;
            item.defense = 13; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ruinous Guisses");
            Tooltip.SetDefault("Increases melee damage and movement speed by 15%");
        }


        public override void UpdateEquip(Player player)
        {
		player.moveSpeed += 0.15f;
		player.meleeDamage += 0.15f;
        }
	  					           public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("RuinousCrystal"), 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
