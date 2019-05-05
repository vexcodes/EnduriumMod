using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class StarLegs : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 18;

            item.value = 120000;
            item.rare = 10;
            item.defense = 20; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Leggings");
            Tooltip.SetDefault("Increases damage and critical strike chance by 10%");
        }


        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.10f;
            player.thrownCrit += 10;
			            player.magicDamage += 0.10f;
            player.magicCrit += 10;
						            player.rangedDamage += 0.10f;
            player.rangedCrit += 10;
						            player.meleeDamage += 0.10f;
            player.meleeCrit += 10;
						            player.minionDamage += 0.10f;
        }
    }
}
	