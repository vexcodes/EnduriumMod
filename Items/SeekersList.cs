using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items
{
    public class SeekersList : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 50;
            item.height = 57;
            item.maxStack = 999;
            item.value = Terraria.Item.sellPrice(0, 0, 0, 0);
            item.rare = -12;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Seeker's List");
            Tooltip.SetDefault("It says 'Hello, i am the seeker and i came from a far away land\nYou can't buy a lot from me using normal coins\nI use an ancient form of currency, it's precious to me\nI also have a supply action going on\nIn the place where i life these things are very precious\nGolden amber: carried by desert creatures,\nOdd gemstone: some ancient underground warriors must have it,\nWeird sludge: slimes! Slimes everywhere!\nMagic cherry: This is not that usefull to me, but it's my favourite food!");
        }
    }
}