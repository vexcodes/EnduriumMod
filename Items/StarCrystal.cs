using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items
{
    public class StarCrystal : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 26;
            item.height = 26;
            item.maxStack = 99;
            item.value = Terraria.Item.sellPrice(0, 1, 0, 0);
            item.rare = 4;
			item.consumable = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Crystal");
            Tooltip.SetDefault("'A bunch of fallen stars fused with magical powers'");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("Aquamarine"), 5);
            recipe.AddIngredient(ItemID.FallenStar, 5);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.AddIngredient(ItemID.SoulofNight);
            recipe.AddTile(null, "SoulForge");

            recipe.SetResult(this, 5);
            recipe.AddRecipe();
        }
    }
}