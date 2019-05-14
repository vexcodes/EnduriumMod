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
    public class BloomlightLegs : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 18;

            item.value = 12500;
            item.rare = 3;
            item.defense = 4; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloomlight Cuisses");
            Tooltip.SetDefault("Increases movement speed\nInreases magic, ranged and throwing critical strike chance by 4%");
        }


        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.15f;
			player.thrownCrit += 4;
            player.rangedCrit += 4;
            player.magicCrit += 4;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BloomlightBar"), 18);
			            recipe.AddIngredient(null, ("NatureEssence"), 7);
						            recipe.AddIngredient(null, ("PutridSpore"), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
