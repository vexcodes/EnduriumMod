using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    public class TheCrossofLifeshift : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 30;
            item.height = 32;
            item.value = Terraria.Item.buyPrice(0, 25, 50, 0);
            item.rare = 5;
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sigil of The Ancient");
            Tooltip.SetDefault("Increases movement speed\nRegenerates and increases health\nGetting hit might boost your speed and life regeneration for a short amount of time.\nDuring that time you will dodge any attack.");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
		            player.statLifeMax2 += 30;
			            player.lifeRegen = +3;
            player.moveSpeed += 0.33f;
          ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).SwiftEmblemV2 = true;
        }
				        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
									            recipe.AddIngredient(null, ("NatureSigil"));
						            recipe.AddIngredient(null, ("SwiftSigil"));
						            recipe.AddIngredient(null, ("BloodEnergy"), 3);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
