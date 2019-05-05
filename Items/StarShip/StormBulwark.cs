using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.StarShip
{
    [AutoloadEquip(EquipType.Shield)]
    public class StormBulwark : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 28;
            item.height = 40;

            item.value = 100000;
            item.rare = 8;
            item.accessory = true;
            item.defense = 10;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Storm Bulwark");
            Tooltip.SetDefault("Dealing damage charges a storm shield, this shield blocks up to 40% damage\nTaking damage removes the shield");
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            MyPlayer p = player.GetModPlayer<MyPlayer>();
            player.endurance = p.StormShieldCharge;
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).StormShield = true;
        }
    }
}