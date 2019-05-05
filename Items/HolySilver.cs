using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items
{
    public class HolySilver : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 50;
            item.height = 57;
            item.maxStack = 99;
            item.value = Terraria.Item.sellPrice(0, 50, 0, 0);
            item.rare = 4;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("AquaticCluster"), 20);
            recipe.AddIngredient(null, ("SkyLamentOre"), 20);
            recipe.AddIngredient(null, ("DuskOre"), 20);
            recipe.AddIngredient(null, ("IceEnergy"), 1);
            recipe.AddTile(null, "SoulForge");
            recipe.SetResult(this, 5);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Silver");
            Tooltip.SetDefault("");
        }
    }
}