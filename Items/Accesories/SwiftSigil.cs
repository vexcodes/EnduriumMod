using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    public class SwiftSigil : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 30;
            item.height = 32;
            item.value = Terraria.Item.buyPrice(0, 5, 50, 0);
            item.rare = 4;
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Divine Swift Sigil");
            Tooltip.SetDefault("Increases movement speed\nGetting hit might boost your speed for a short amount of time.\nDuring that time you will dodge any attack.");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed += 0.25f;
          ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).SwiftEmblem = true;
        }
				        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
						            recipe.AddIngredient(null, ("GraniteEnergyCore"), 5);
			            recipe.AddIngredient(null, ("MagicPowder"), 15);
			            recipe.AddIngredient(null, ("IronCross"));
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
