using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    public class ErodedPrism : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 30;
            item.height = 32;
            item.value = Terraria.Item.buyPrice(0, 3, 0, 0);
            item.rare = 4;
            item.accessory = true;
            item.defense = 2;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eroded Crystal");
            Tooltip.SetDefault("Decreases damage slightly\nIncreases life regeneration");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeDamage *= 0.95f;
            player.thrownDamage *= 0.95f;
            player.lifeRegen = +2;
            player.rangedDamage *= 0.95f;
            player.magicDamage *= 0.95f;
            player.minionDamage *= 0.95f;
        }
    }
}
