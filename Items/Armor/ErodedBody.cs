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
    public class ErodedBody : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 22;
            item.height = 22;

            item.value = 52000;
            item.rare = 7;
            item.defense = 5; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eroded Chestplate");
            Tooltip.SetDefault("Increases thrown damage by 9%");
        }


        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.09f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("ErodedShard"), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}