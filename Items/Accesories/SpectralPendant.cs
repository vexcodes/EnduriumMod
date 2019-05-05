using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    public class SpectralPendant : ModItem
    {
        public override void SetDefaults()
        {

		    item.damage = 50;
            item.width = 30;
            item.height = 32;
            item.value = Terraria.Item.buyPrice(0, 5, 50, 0);
            item.rare = 5;
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectral Pendant");
            Tooltip.SetDefault("Getting hit causes spectral energy to appear\nIncreases movement speed");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).TheOneThingThatCreatesEnergyOnGettingHitAndStuff = true;
			                player.moveSpeed += 0.5f;
									player.accRunSpeed *= 1.5f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
						recipe.AddIngredient(ItemID.SpectreBar, 20);
			            recipe.AddIngredient(null, ("AngelFeather"), 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
