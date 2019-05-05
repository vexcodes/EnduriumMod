using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    public class HellstormCore : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 22;
            item.height = 22;

            item.value = Terraria.Item.buyPrice(0, 1, 0, 0);
            item.rare = 3;
            item.accessory = true;

        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Hellstorm Core");
      Tooltip.SetDefault("Increases ranged damage by 11%");
    }

        public override void UpdateAccessory(Player player, bool hideVisual)  //this is so when the item is equipped will give this stats to the player
        {
            player.rangedDamage += 0.11f;
        }
		        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			            recipe.AddIngredient(null, ("MeteoritePowerCore"), 5);
            recipe.AddIngredient(ItemID.HellstoneBar, 18);
			            recipe.AddIngredient(ItemID.MeteoriteBar, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
