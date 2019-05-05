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
    public class MarbleLegs : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 22;
            item.height = 22;

            item.value = 12000;
            item.rare = 4;
            item.defense = 1; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rosy Gold Leggings");
            Tooltip.SetDefault("Increases throwing damage and velocity by 5%");
        }


        public override void UpdateEquip(Player player)
        {
		    player.thrownDamage += 0.05f;
			player.thrownVelocity += 0.05f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("RosyGoldChunk"), 09);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}