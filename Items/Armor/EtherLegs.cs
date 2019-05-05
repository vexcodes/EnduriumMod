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
    public class EtherLegs : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 18;

            item.value = 40000;
            item.rare = 5;
            item.defense = 5; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ether Guisses");
            Tooltip.SetDefault("Increases summon damage by 18%");
        }


        public override void UpdateEquip(Player player)
        {
			            player.minionDamage += 0.18f;
        }
	  					           public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("FrigidFragment"), 12);
			            recipe.AddIngredient(null, ("DuskSteel"), 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
