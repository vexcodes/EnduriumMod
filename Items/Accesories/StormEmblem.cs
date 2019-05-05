using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
namespace EnduriumMod.Items.Accesories
{
    public class StormEmblem : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 20;
            item.height = 26;

            item.value = Terraria.Item.buyPrice(0, 15, 0, 0);
            item.rare = 7;
            item.accessory = true;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Storm Emblem");
            Tooltip.SetDefault("Increases ranged damage by 18%.\nRanged projectiles inflict shadowflame.");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)  //this is so when the item is equipped will give this stats to the player
        {
            player.rangedDamage += 0.18f;
        }
						        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.RangerEmblem);
			            recipe.AddIngredient(null, ("RangedTab"));
			recipe.AddIngredient(null, ("DarkDust"), 15);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 15);

            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
