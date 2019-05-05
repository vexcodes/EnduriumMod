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
    public class BloodlightBody : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 22;
            item.height = 22;

            item.value = 12000;
            item.rare = 3;
            item.defense = 4; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloodlight Breastplate");
            Tooltip.SetDefault("Increases life regeneration and max health\nIncreases critical strike chance and damage by 3%");
        }

						        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			            recipe.AddIngredient(null, ("BloodlightBar"), 24);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateEquip(Player player)
        {
				            player.statLifeMax2 += 10;
			            player.lifeRegen = +1;
					            player.rangedDamage += 0.03f;
            player.meleeDamage += 0.03f;
			player.meleeCrit += 3;
			player.magicCrit += 3;
			player.rangedCrit += 3;
			player.thrownCrit += 3;
            player.magicDamage += 0.03f;
            player.thrownDamage += 0.03f;
        }
    }
}