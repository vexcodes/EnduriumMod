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
    public class CrypticBody : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 22;
            item.height = 22;

            item.value = 120000;
            item.rare = 6;
            item.defense = 7; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryptic Arcane Chainplate");
            Tooltip.SetDefault("Increases summon damage by 10% and max minions by 1");
        }


        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 1;
			player.minionDamage += 0.03f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("CrypticPowerCell"), 21);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}