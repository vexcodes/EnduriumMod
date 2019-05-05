using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items
{
	public class AccretionBar : ModItem
	{
        public override void SetDefaults()
		{
			item.width = 30;
			item.height = 30;
			item.maxStack = 999;
			item.value = 255000;
            item.rare = 10;
		}

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Accretion Bar");
            Tooltip.SetDefault("'The hardest substance in the Galaxy, having the power of a black hole.'");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar);
            recipe.AddIngredient(ItemID.SpectreBar);
            recipe.AddIngredient(ItemID.ShroomiteBar);
            recipe.AddIngredient(ItemID.ChlorophyteBar);
            recipe.AddIngredient(ItemID.HallowedBar);
            recipe.AddIngredient(ItemID.TitaniumBar);
            recipe.AddIngredient(ItemID.AdamantiteBar);
            recipe.AddIngredient(ItemID.MythrilBar);
            recipe.AddIngredient(ItemID.OrichalcumBar);
            recipe.AddIngredient(ItemID.CobaltBar);
            recipe.AddIngredient(ItemID.PalladiumBar);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
        }
    }
}
