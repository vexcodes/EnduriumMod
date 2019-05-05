using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    public class TempleBadge : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 30;
            item.height = 32;
            item.value = Terraria.Item.buyPrice(0, 30, 0, 0);
            item.rare = 3;
            item.accessory = true;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Temple Badge");
            Tooltip.SetDefault("'Wield it on your shoulder and tell everyone who you are'\nIncreases damage and movement speed if full on health");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.statLife == (player.statLifeMax2))
            {
			player.moveSpeed *= 1.4f;
                player.magicDamage += 0.15f;
				                player.meleeDamage += 0.15f;
								                player.rangedDamage += 0.15f;
												                player.thrownDamage += 0.15f;
																                player.minionDamage += 0.15f;
            }
        }
    }
}
