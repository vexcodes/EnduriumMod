using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace EnduriumMod.Items
{
    public class NatureEssence : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 22;
            item.height = 22;
            item.maxStack = 99;
            item.value = Terraria.Item.sellPrice(0, 0, 10, 0);
            item.rare = 7;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nature Essence");
            Tooltip.SetDefault("");
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }
    }
}