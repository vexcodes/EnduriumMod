using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    public class BlessedEmblem : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 30;
            item.height = 32;
            item.value = Terraria.Item.buyPrice(0, 15, 50, 0);
            item.rare = 8;
            item.accessory = true;
            item.defense = 8;
			item.expert = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Divine Spirit Emblem");
            Tooltip.SetDefault("Minion attacks may bless you with several buffs, and spawn a spirit that will explode and heal you\nIncreases minion damage by 12%\nNon-summoner class damage reduced by 30%");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
		            player.minionDamage += 0.13f;
            player.statLifeMax2 += 75;
			            player.rangedDamage -= 0.3f;
            player.meleeDamage -= 0.3f;
            player.magicDamage -= 0.3f;
            player.thrownDamage -= 0.3f;
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).HealingSpirit = true;
        }
    }
}
