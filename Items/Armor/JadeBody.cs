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
    public class JadeBody : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 22;
            item.height = 22;

            item.value = 12000;
            item.rare = 6;
            item.defense = 8; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jade Scalemail");
            Tooltip.SetDefault("Increases max mana by 60");
        }


        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 60;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("Jade"), 28);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}