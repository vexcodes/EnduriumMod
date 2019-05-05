using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    public class GlowingScale : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 30;
            item.height = 32;
            item.value = Terraria.Item.buyPrice(0, 2, 50, 0);
            item.rare = 3;
            item.accessory = true;
            item.defense = 1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ember Scale");
            Tooltip.SetDefault("'Resin of the tree'\nIncreases your max amount of minions by 2, but decreases damage by 30%");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxMinions += 2;
            player.minionDamage -= 0.3f;
        }
    }
}
