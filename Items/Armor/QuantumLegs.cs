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
    public class QuantumLegs : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 18;

            item.value = 40000;
            item.rare = 8;
            item.defense = 10; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Quantum Leggings");
            Tooltip.SetDefault("Increases throwing critical strike chance by 20%");
        }


        public override void UpdateEquip(Player player)
        {
									            player.thrownCrit += 20;
        }
    }
}
