using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.BloodlightShaman
{
    public class FleshCrown : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 30;
            item.height = 32;
            item.value = Terraria.Item.buyPrice(0, 5, 0, 0);
            item.rare = -12;
            item.accessory = true;
            item.expert = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crown of Flesh");
            Tooltip.SetDefault("Increases minion damage by 8% and max minions by 1\nWhile below 50% health you recover health faster");
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.minionDamage *= 1.08f;
            player.maxMinions += 1;
            if (player.statLife <= player.statLifeMax2 / 2)
            {
                player.lifeRegen += 2;
            }
        }
    }
}