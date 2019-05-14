using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items
{
    public class GleamingCrag : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 26;
            item.height = 26;
            item.maxStack = 99;
            item.value = Terraria.Item.sellPrice(0, 0, 5, 0);
            item.rare = 6;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofNight, 2);
            recipe.AddIngredient(ItemID.SoulofLight, 2);
            recipe.AddIngredient(ItemID.CrystalShard, 2);
            recipe.AddIngredient(null, ("GemofHollow"), 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 4);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gleaming Crag");
            Tooltip.SetDefault("'Our powers, combined'");
        }
    }
}