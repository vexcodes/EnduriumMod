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
    public class CrypticLegs : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 18;

            item.value = 125000;
            item.rare = 5;
            item.defense = 4; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryptic Arcane Shoes");
            Tooltip.SetDefault("Increases summon damage by 8%");
        }


        public override void UpdateEquip(Player player)
        {
			player.minionDamage += 0.08f;
        }
				        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("CrypticPowerCell"), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
