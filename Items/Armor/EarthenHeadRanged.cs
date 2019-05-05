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
    public class EarthenHeadRanged : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 26;
            item.height = 26;

            item.value = 10000;
            item.rare = 6;
            item.defense = 9; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Earthen Headgear");
            Tooltip.SetDefault("Increases ranged critical strike chance by 12%");
        }
	  					           public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BioScale"), 16);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == mod.ItemType("EarthenBody") && legs.type == mod.ItemType("EarthenLegs");
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlinesForbidden = true;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "'The spirits of earth will guide your way\nIncreases ranged damage by 18%";
			player.AddBuff(BuffID.Hunter, 2);
                player.rangedDamage += 0.18f;
	    }

        public override void UpdateEquip(Player player)
        {
            player.rangedCrit += 12;
        }
    }
}
