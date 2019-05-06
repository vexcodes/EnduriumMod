using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    public class StaroftheMoon : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 30;
            item.height = 32;
            item.value = Terraria.Item.buyPrice(0, 15, 50, 0);
            item.rare = 5;
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star of the Moonlight");
            Tooltip.SetDefault("Increases max mana by 25\nGetting hit fully refills your mana");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statManaMax2 += 25;
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).ManaRefill = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MagicCuffs);
            recipe.AddIngredient(null, ("Aquamarine"), 25);
            recipe.AddIngredient(null, ("IceEnergy"), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}