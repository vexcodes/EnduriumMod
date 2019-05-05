using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    [AutoloadEquip(EquipType.Shield)]
    public class GoldenAmberBattleShield : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 28;
            item.height = 40;

            item.value = 100000;
            item.rare = 5;
            item.accessory = true;
			item.defense = 8;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golden Amber Shield");
            Tooltip.SetDefault("");
        }
    }
}
