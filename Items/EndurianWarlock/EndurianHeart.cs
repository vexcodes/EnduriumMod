using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.EndurianWarlock
{
    public class EndurianHeart : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 30;
            item.height = 32;
            item.value = Terraria.Item.buyPrice(0, 10, 50, 0);
            item.rare = -12;
            item.accessory = true;
            item.expert = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heart of the Forest");
            Tooltip.SetDefault("Taking lethal damage will instead bring you back to 200 health as if nothing happened\nThis effect has a cooldown of 2 minutes, during that time life regeneration is slightly lowered");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).HeartOfTheForest = true;
        }
    }
}