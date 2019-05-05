using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
namespace EnduriumMod.Items.Accesories
{
    public class MinersBelt : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 20;
            item.height = 26;

            item.value = Terraria.Item.buyPrice(0, 1, 0, 0);
            item.rare = 3;
            item.accessory = true;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Miner's Belt");
            Tooltip.SetDefault("Increases mining speed by 20% while underground");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)  //this is so when the item is equipped will give this stats to the player
        {
		if (!player.ZoneOverworldHeight)
		{
				player.pickSpeed -= 0.2f;
				}
        }
														        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Leather, 2);
						            recipe.AddIngredient(null, ("PutridSpore"), 10);
									            recipe.AddRecipeGroup("PlatinumBars", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
