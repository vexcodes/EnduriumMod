using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class TropicHead : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 18;

            item.value = 72500;
            item.rare = 5;
            item.defense = 10; //42
        }
		        public override void ArmorSetShadows(Player player)
        {
						player.armorEffectDrawShadow = true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tropic Mask");
            Tooltip.SetDefault("Increases throwing damage by 10%\nGreatly increases jump height");
        }
		        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == mod.ItemType("TropicBody") && legs.type == mod.ItemType("TropicLegs");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Critical striking an enemy with a throwing weapon causes it to erupt into several tropical bolts\nThrowing critical strike chance cannot be higher than 15%";
     		((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).TropicEruption = true;
            if (player.thrownCrit >= 15)
            {
                player.thrownCrit = 15;
            }

        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage *= 1.1f;
            player.jumpSpeedBoost += 2.5f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "TropicalFragment", 1);
			            recipe.AddRecipeGroup("Tier3HMBars", 16);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
