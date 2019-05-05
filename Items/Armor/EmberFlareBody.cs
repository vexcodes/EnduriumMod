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
    public class EmberFlareBody : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 22;
            item.height = 22;

            item.value = 12000;
            item.rare = 5;
            item.defense = 12; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ember Flare Breastplate");
            Tooltip.SetDefault("Increases magic critical strike chance by 16%");
        }
	  					           public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("FieryTissue"), 16);
			            recipe.AddIngredient(null, ("DuskSteel"), 24);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateEquip(Player player)
        {
            player.magicCrit += 16;
        }
    }
}