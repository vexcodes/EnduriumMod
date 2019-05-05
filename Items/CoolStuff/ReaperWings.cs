using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.CoolStuff
{
    [AutoloadEquip(EquipType.Wings)]
    public class ReaperWings : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 22;
            item.height = 20;

            item.value = Terraria.Item.buyPrice(0, 25, 0, 0);
            item.rare = 7;
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reaper Cat Wings");
            Tooltip.SetDefault("Great for impersonating... cats?\nProvides near infinite flight");
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 10000;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.99f;
            ascentWhenRising = 0.25f;
            maxCanAscendMultiplier = 10f;
            maxAscentMultiplier = 5f;
            constantAscend = 0.235f;
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 15f;
            acceleration *= 9f;
        }
    }
}