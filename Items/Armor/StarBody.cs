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
    public class StarBody : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 18;

            item.value = 120000;
            item.rare = 10;
            item.defense = 30; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Chestplate");
            Tooltip.SetDefault("Increases damage by 20% and critical strike chance by 12%");
        }


        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.20f;
            player.thrownCrit += 12;
            player.magicDamage += 0.20f;
            player.magicCrit += 12;
            player.rangedDamage += 0.20f;
            player.rangedCrit += 12;
            player.meleeDamage += 0.20f;
            player.meleeCrit += 12;
            player.minionDamage += 0.20f;
        }
    }
}