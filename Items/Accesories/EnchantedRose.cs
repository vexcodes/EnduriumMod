using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    public class EnchantedRose : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 32;
            item.height = 56;

            item.value = Terraria.Item.buyPrice(0, 1, 0, 0);
            item.rare = 3;
            item.accessory = true;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enchanted Rose");
            Tooltip.SetDefault("Increases max mana by 40.\nDecreases mana ussage by 12%\nIncreases magic critical strike by 12%\nAutomatically uses mana potions when needed");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statManaMax2 += 40;
            player.manaCost *= 0.88f;
            player.magicCrit += 12;
            player.manaFlower = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("WaterEye"));
            recipe.AddIngredient(ItemID.ManaFlower, 1);
            recipe.AddIngredient(null, ("GraniteEnergyCore"), 5);
            recipe.AddIngredient(null, ("IceEnergy"), 2);
            recipe.AddIngredient(ItemID.FallenStar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
