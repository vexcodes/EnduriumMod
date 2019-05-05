using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items
{
    public class BloodEnergy : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 22;
            item.height = 20;
            item.maxStack = 99;
            item.value = Terraria.Item.sellPrice(0, 0, 25, 0);
            item.rare = 6;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloody Energy");
            Tooltip.SetDefault("'You can feel it pulse'");
			            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(9, 7));
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }
    }
}