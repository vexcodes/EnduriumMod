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
    public class RuinousHead : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 18;

            item.value = 40000;
            item.rare = 8;
            item.defense = 14; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ruinous Mask");
            Tooltip.SetDefault("Increases melee damage and movement speed by 15%");
        }
		        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == mod.ItemType("RuinousBody") && legs.type == mod.ItemType("RuinousLegs");
        }

        public override void ArmorSetShadows(Player player)
        {
			player.armorEffectDrawShadow = true;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases melee critical strike chance by 15%\nMelee close range attacks might inflict royal curse, lowering enemy defense";
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).RoyalCurseInflict = true;

        }

        public override void UpdateEquip(Player player)
        {
		player.moveSpeed += 0.15f;
		player.meleeCrit += 15;
		player.meleeDamage += 0.15f;
        }
	  					           public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("RuinousCrystal"), 26);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
