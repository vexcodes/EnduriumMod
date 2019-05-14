using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
namespace EnduriumMod.Items.Accesories
{
    [AutoloadEquip(EquipType.Shoes)]

    public class CrystalflareRunners : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 20;
            item.height = 26;

            item.value = Terraria.Item.buyPrice(0, 20, 0, 0);
            item.rare = 7;
            item.accessory = true;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystalflare Runners");
            Tooltip.SetDefault("Boosts flight and allows for extremely fast running\nAllows the ability to climb walls and dash\nGives a chance to dodge attacks");
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.accRunSpeed += 12f;
            player.rocketBoots += 4;
            player.moveSpeed += 0.85f;
            player.blackBelt = true;
            player.dash = 1;
            player.wingTimeMax += 40;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FrostsparkBoots);
            recipe.AddIngredient(984);
            recipe.AddIngredient(null, "HolySilver", 5);
            recipe.AddIngredient(null, "Aquamarine", 30);
            recipe.AddTile(null, "SoulForge");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}