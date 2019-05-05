using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    public class EyeofFlesh : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 30;
            item.height = 32;
            item.value = Terraria.Item.buyPrice(0, 2, 50, 0);
            item.rare = -12;
			item.expert = true;
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eye of Flesh");
            Tooltip.SetDefault("Increases damage resistance and max health by 10%");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 = (int)((float)player.statLifeMax2 * 1.1f);
			            player.endurance += 0.1f;
        }
    }
}
