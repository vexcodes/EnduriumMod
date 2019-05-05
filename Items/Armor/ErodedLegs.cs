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
    public class ErodedLegs : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 22;
            item.height = 22;

            item.value = 52000;
            item.rare = 7;
            item.defense = 4; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eroded Shoes");
            Tooltip.SetDefault("Increases thrown velocity by 20%");
        }


        public override void UpdateEquip(Player player)
        {
            player.thrownVelocity += 0.2f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("ErodedShard"), 11);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}