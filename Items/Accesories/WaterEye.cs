using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    public class WaterEye : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 22;
            item.height = 22;

            item.value = Terraria.Item.buyPrice(0, 1, 0, 0);
            item.rare = 3;
            item.accessory = true;

        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("The Water Bubble");
      Tooltip.SetDefault("Increases max mana by 10.\nDecreases mana ussage by 10%\nIncreases magic critical strike by 3%");
    }

        public override void UpdateAccessory(Player player, bool hideVisual)  //this is so when the item is equipped will give this stats to the player
        {
            player.statManaMax2 += 10;
            player.manaCost *= 0.9f;
            player.magicCrit += 3;
        }
    }
}
