using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace EnduriumMod.Items.TheSpiritOfBloom
{
    public class TrueNatureEssence : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 40;
            item.height = 40;
            item.maxStack = 99;
            item.value = Terraria.Item.sellPrice(0, 0, 10, 0);
            item.rare = -12;
			item.expert = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Nature Essence");
            Tooltip.SetDefault("");
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }
    }
}