using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.ThePrismArcanum
{
    public class CrypticBand : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 30;
            item.height = 32;
            item.value = Terraria.Item.buyPrice(0, 4, 50, 0);
            item.rare = 4;
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryptic Band");
            Tooltip.SetDefault("Grants immunity to Cursed and Shiver");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[BuffID.Cursed] = true;
			            player.buffImmune[mod.BuffType("Shiver")] = true;
        }
    }
}
