using System;
using Microsoft.Xna.Framework;
using Terraria.GameContent.UI;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items  //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class ForestSpiritSoul : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 24;   //The size in width of the sprite in pixels.
            item.height = 22;   //The size in height of the sprite in pixels.
            item.maxStack = 999; //This defines the items max stack
            item.value = Item.buyPrice(0, 1, 5, 0); //	How much the item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this item price is 10 gold and to sell it its 2 gold)
            item.rare = -12;    //The color the title of your Weapon when hovering over it ingame . -12 is the expert rainbow like the treasure bags color  .
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Forest Spirit Soul");
            Tooltip.SetDefault("The Endurian family used to trade with these");
        }
    }
}