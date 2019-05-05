using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items
{
    public class MeteoritePowerCore : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 22;
            item.maxStack = 99;
            item.value = Terraria.Item.sellPrice(0, 0, 25, 0);
            item.rare = 4;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meteorite Energy Core");
            Tooltip.SetDefault("Used in crafting powerfull magma and flame items.");
        }
    }
}