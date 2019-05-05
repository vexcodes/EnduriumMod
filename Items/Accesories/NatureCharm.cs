using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    public class NatureCharm : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 30;
            item.height = 32;
            item.value = Terraria.Item.buyPrice(0, 1, 50, 0);
            item.rare = 4;
            item.accessory = true;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tropical Badge");
            Tooltip.SetDefault("Increases throwing damage by 5%");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thrownDamage += 0.05f;
        }
		        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
						            recipe.AddIngredient(null, ("NatureEssence"), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
