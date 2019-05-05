using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    public class MeleeTab : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 26;
            item.height = 24;
            item.value = Terraria.Item.buyPrice(0, 2, 50, 0);
            item.rare = 3;
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Warrior Tab");
            Tooltip.SetDefault("Increases melee damage by 7%");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeDamage += 0.07f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BlankTab"));
            recipe.AddRecipeGroup("PlatinumBars", 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
