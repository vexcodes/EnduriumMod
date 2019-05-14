using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    [AutoloadEquip(EquipType.Shield)]
    public class FrozenShield : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 28;
            item.height = 40;

            item.value = 100000;
            item.rare = 5;
            item.accessory = true;
            item.defense = 3;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frozen Bulwark");
            Tooltip.SetDefault("Gives immunity to the chilled and frozen debuff\nYou take 6% less damage");
        }
        public override void UpdateAccessory(Player player, bool hideVisual)  //this is so when the item is equipped will give this stats to the player
        {
            player.endurance += 0.06f;
            player.buffImmune[BuffID.Frozen] = true;
            player.buffImmune[BuffID.Chilled] = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BoneScrap"), 5);
            recipe.AddIngredient(null, ("IceEnergy"), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}