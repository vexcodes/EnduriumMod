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
    public class OvergrowthChest : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 18;

            item.value = 40000;
            item.rare = 8;
            item.defense = 13; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endurian Chestplate");
            Tooltip.SetDefault("Increases damage by 21%");
        }


        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.21f;
            player.meleeDamage += 0.21f;
            player.rangedDamage += 0.21f;
            player.thrownDamage += 0.21f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("AcidCore"), 28);
            recipe.AddIngredient(null, ("DarkDust"), 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}