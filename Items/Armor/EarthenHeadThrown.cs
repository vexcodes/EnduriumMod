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
    public class EarthenHeadThrown : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 26;
            item.height = 26;

            item.value = 10000;
            item.rare = 6;
            item.defense = 6; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Earthen Hat");
            Tooltip.SetDefault("Increases throwing critical strike chance by 10%");
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
            player.setBonus = "'The spirits of earth will guide your way\nIncreases throwing damage and velocity by 16%";
			player.AddBuff(BuffID.Hunter, 2);
                player.thrownDamage += 0.16f;
				player.thrownVelocity += 0.16f;
	    }

        public override void UpdateEquip(Player player)
        {
            player.thrownCrit += 10;
        }
    }
}
