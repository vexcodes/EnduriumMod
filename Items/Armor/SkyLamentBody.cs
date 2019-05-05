using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class SkyLamentBody : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 22;
            item.height = 22;

            item.value = 22000;
            item.rare = 4;
            item.defense = 5; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sky Lament Chainplate");
            Tooltip.SetDefault("Increases critical strike chance by 6%");
        }


        public override void UpdateEquip(Player player)
        {
            player.thrownCrit += 6;
            player.rangedCrit += 6;
            player.magicCrit += 6;
            player.meleeCrit += 6;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("SkyGlazeAlloy"), 16);
            recipe.AddTile(null, "SkyLamentAnvil");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}