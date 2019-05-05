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
    public class StarlightCasterBody : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 18;

            item.value = 40000;
            item.rare = 5;
            item.defense = 8; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Starlight Caster Chainplate");
            Tooltip.SetDefault("");
        }


        public override void UpdateEquip(Player player)
        {
        }
    }
}
