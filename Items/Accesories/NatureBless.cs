using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
namespace EnduriumMod.Items.Accesories
{
    public class NatureBless : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 20;
            item.height = 26;

            item.value = Terraria.Item.buyPrice(0, 15, 0, 0);
            item.rare = 1;
            item.accessory = true;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blessed Ring");
            Tooltip.SetDefault("Increases minion damage by 10%.");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)  //this is so when the item is equipped will give this stats to the player
        {
            player.minionDamage += 0.10f;
        }
    }
}
