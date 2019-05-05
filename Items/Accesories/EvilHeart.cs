using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    public class EvilHeart : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 30;
            item.height = 32;
            item.value = Terraria.Item.buyPrice(0, 3, 0, 0);
            item.rare = 5;
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Evil Heart");
            Tooltip.SetDefault("Decreases health slightly\nIncreases damage");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeDamage *= 1.1f;
            player.thrownDamage = 1.1f;
            player.lifeRegen = -2;
            player.statLifeMax2 -= 25;
            player.rangedDamage = 1.1f;
            player.magicDamage = 1.1f;
            player.minionDamage = 1.1f;
        }
    }
}
