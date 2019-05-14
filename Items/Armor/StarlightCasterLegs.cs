using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class StarlightCasterLegs : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 18;

            item.value = 40000;
            item.rare = 6;
            item.defense = 8; //42
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("GleamingCrag"), 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Starlight Caster Leggings");
            Tooltip.SetDefault("Increases magic critical strike chance");
        }


        public override void UpdateEquip(Player player)
        {
            player.magicCrit += 8;
        }
    }
}
