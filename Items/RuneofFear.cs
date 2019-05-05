using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items
{
    public class RuneofFear : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 28;
            item.height = 22;
            item.maxStack = 99;
            item.value = Terraria.Item.sellPrice(0, 0, 12, 0);
            item.rare = 5;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rune of Fear");
            Tooltip.SetDefault("");
        }
    }
}