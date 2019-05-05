using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Placeable
{
    public class GraniteAltar : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 22;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 10;
            item.useTime = 10;
            item.useStyle = 1;
            item.rare = 4;
            item.consumable = true;
            item.value = Terraria.Item.buyPrice(0, 15, 0, 0);
            item.createTile = mod.TileType("GraniteAltar"); //put your CustomBlock Tile name
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Energy Altar");
            Tooltip.SetDefault("Used to craft high tech items.");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("GraniteEnergyCore"), 15);
			recipe.AddIngredient(null, ("PrismShard"), 8);       
			recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}