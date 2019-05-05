using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.StarShip
{
    public class EyeoftheStorm : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 34;
            item.height = 42;
            item.value = Terraria.Item.buyPrice(0, 15, 50, 0);
            item.rare = -12;
            item.expert = true;
            item.accessory = true;
          
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eye of The Storm");
            Tooltip.SetDefault("'Open your third eye'");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.magicCrit += 10;
            player.AddBuff(mod.BuffType("EyeofTheStorm"), 1);
            player.meleeCrit += 10;
            player.rangedCrit += 10;
            player.thrownCrit += 10;
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).EyeofTheStorm = true;
        }
    }
}