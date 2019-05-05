using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.CoolStuff
{
    public class Lolipop : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 50;
            item.height = 50;
            item.maxStack = 99;
            item.value = Terraria.Item.sellPrice(99, 0, 0, 0);
            item.rare = -11;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Lolipop");
            Tooltip.SetDefault("'The legendary candy'");
        }
    }
}