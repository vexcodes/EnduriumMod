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
    public class EarthenBody : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 18;

            item.value = 40000;
            item.rare = 5;
            item.defense = 16; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Earthen Bodyguard");
            Tooltip.SetDefault("Increases damage by 10%");
        }


        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.1f;
            player.meleeDamage += 0.1f;
            player.rangedDamage += 0.1f;
            player.thrownDamage += 0.1f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BioScale"), 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}