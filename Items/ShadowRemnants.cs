using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items
{
    public class ShadowRemnants : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 50;
            item.height = 57;
            item.maxStack = 99;
            item.value = Terraria.Item.sellPrice(0, 0, 15, 0);
            item.rare = 4;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Remnants");
            Tooltip.SetDefault("Magic of a necrotic being");
        }
    }
}