using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Herbs
{
    public class PutridGel : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 22;
            item.height = 22;
            item.maxStack = 99;
            item.value = Terraria.Item.sellPrice(0, 0, 5, 0);
            item.rare = 2;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Putrid Gel");
            //Tooltip.SetDefault("Used in advanced potion brewing");
        }
    }
}