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
    public class GraniteBody : ModItem
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
            DisplayName.SetDefault("Granite Bodyplate");
            Tooltip.SetDefault("Increases damage by 5%");
        }


        public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.05f;
            player.meleeDamage += 0.05f;
            player.magicDamage += 0.05f;
            player.thrownDamage += 0.05f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("GraniteScale"), 21);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}