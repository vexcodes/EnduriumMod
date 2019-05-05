using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    public class RoyalQuiver : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 30;
            item.height = 32;
            item.value = Terraria.Item.buyPrice(0, 4, 50, 0);
            item.rare = 8;
            item.accessory = true;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Royal Quiver");
            Tooltip.SetDefault("Increases ranged damage by 15%\nIncreases ranged critical strike chance by 5%\nYou have 40% chance to not consume arrows");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MagicQuiver);
            recipe.AddIngredient(null, ("RangedTab"));
            recipe.AddIngredient(null, ("AngelFeather"), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.rangedDamage *= 1.15f;
            player.rangedCrit += 5;
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).RoyalQuiver = true;
        }
    }
}