using Terraria.ModLoader;

namespace EnduriumMod.Items
{
    public class BlankTab : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 50;
            item.height = 57;
            item.maxStack = 99;
            item.value = Terraria.Item.sellPrice(0, 0, 0, 0);
            item.rare = 2;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blank Tab");
            Tooltip.SetDefault("");
        }
    }
}