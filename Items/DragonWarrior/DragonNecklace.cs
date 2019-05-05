using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.DragonWarrior
{
    public class DragonNecklace : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 30;
            item.height = 32;
            item.value = Terraria.Item.buyPrice(0, 2, 50, 0);
            item.rare = 2;
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon Medalion");
            Tooltip.SetDefault("'Stores a powerfull being inside'\nEmpowers dragon weaponary");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
          ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).DragonBuff = true;
        }
    }
}
