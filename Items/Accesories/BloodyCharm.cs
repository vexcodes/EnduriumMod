using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    public class BloodyCharm : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 30;
            item.height = 32;
            item.value = Terraria.Item.buyPrice(0, 1, 50, 0);
            item.rare = 3;
            item.accessory = true;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Badge of Chaos");
            Tooltip.SetDefault("When below 50% health throwing critical strike chance is increased by 10%");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.statLife <= (player.statLifeMax2 * 0.5f))
            {
                player.thrownCrit += 10;
            }
        }
		        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
						            recipe.AddIngredient(null, ("BloodFangCore"), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
