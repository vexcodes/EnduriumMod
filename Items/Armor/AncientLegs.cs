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
    public class AncientLegs : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 18;

            item.value = 12500;
            item.rare = 2;
            item.defense = 2; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Shoes");
            Tooltip.SetDefault("Increases max mana by 10 and minion damage by 5%");
        }


        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 10;
			player.minionDamage += 0.05f;
        }
				        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("AncientMandible"), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
