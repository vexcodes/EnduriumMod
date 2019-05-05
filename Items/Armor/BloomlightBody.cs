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
    public class BloomlightBody : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 22;
            item.height = 22;

            item.value = 12000;
            item.rare = 6;
            item.defense = 7; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloomlight Breastplate");
            Tooltip.SetDefault("Increases magic, ranged and throwing damage by 6%");
        }


        public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.06f;
            player.magicDamage += 0.06f;
            player.thrownDamage += 0.06f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BloomlightBar"), 21);
			            recipe.AddIngredient(null, ("NatureEssence"), 12);
            recipe.AddIngredient(null, ("PutridSpore"), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}