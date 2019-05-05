using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    public class EmberCactusFruit : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 30;
            item.height = 32;
            item.value = Terraria.Item.buyPrice(0, 12, 50, 0);
            item.rare = 2;
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ember Cactus");
            Tooltip.SetDefault("Increases minion damage by 6%.");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.minionDamage += 0.06f;
        }
    }
}
