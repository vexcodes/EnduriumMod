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
    public class BoneLegs : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 18;

            item.value = 12500;
            item.rare = 2;
            item.defense = 4; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bone Greaves");
            Tooltip.SetDefault("Increases damage resistance by 4%");
        }


        public override void UpdateEquip(Player player)
        {
		            player.endurance += 0.04f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BoneScrap"), 18);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
