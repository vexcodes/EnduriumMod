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
    public class BloodReaperBody : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 22;
            item.height = 22;

            item.value = 12000;
            item.rare = 3;
            item.defense = 3; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Fang Chainplate");
            Tooltip.SetDefault("Increases damage by 2%");
        }


        public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.02f;
            player.meleeDamage += 0.02f;
            player.magicDamage += 0.02f;
            player.thrownDamage += 0.02f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BloodFangCore"), 21);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}