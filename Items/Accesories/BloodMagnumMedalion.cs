using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    public class BloodMagnumMedalion : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 30;
            item.height = 32;
            item.value = Terraria.Item.buyPrice(0, 2, 50, 0);
            item.rare = 2;
            item.accessory = true;
            item.defense = 1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infected Medalion");
            Tooltip.SetDefault("Hitting enemies occasionally gives you the Blood Blessing buff");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
          ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).BloodFang = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BloodEnergy"), 1);
            recipe.AddIngredient(null, ("BloodFangCore"), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
