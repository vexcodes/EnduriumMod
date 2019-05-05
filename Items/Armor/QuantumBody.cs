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
    public class QuantumBody : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 18;

            item.value = 40000;
            item.rare = 8;
            item.defense = 15; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Quantum Bodyplate");
            Tooltip.SetDefault("Increases throwing damage by 20%");
        }


        public override void UpdateEquip(Player player)
        {
									            player.thrownDamage += 0.20f;
        }
    }
}
