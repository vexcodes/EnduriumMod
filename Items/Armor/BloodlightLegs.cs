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
    public class BloodlightLegs : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 22;
            item.height = 22;

            item.value = 12000;
            item.rare = 3;
            item.defense = 2; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloodlight Leggings");
            Tooltip.SetDefault("Increases life regeneration and max health\nIncreases critical strike chance and damage by 2%");
        }
						        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			            recipe.AddIngredient(null, ("BloodlightBar"), 18);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateEquip(Player player)
        {
				            player.statLifeMax2 += 5;
			            player.lifeRegen = +1;
					            player.rangedDamage += 0.02f;
            player.meleeDamage += 0.02f;
			player.meleeCrit += 2;
			player.magicCrit += 2;
			player.rangedCrit += 2;
			player.thrownCrit += 2;
            player.magicDamage += 0.02f;
            player.thrownDamage += 0.02f;
        }
    }
}