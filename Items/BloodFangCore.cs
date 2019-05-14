using Terraria.ModLoader;

namespace EnduriumMod.Items
{
    public class BloodFangCore : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 22;
            item.maxStack = 99;
            item.value = Terraria.Item.sellPrice(0, 0, 25, 0);
            item.rare = 1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Fang");
            Tooltip.SetDefault("");
        }
    }
}