using Terraria.ModLoader;

namespace EnduriumMod.Items
{
    public class AncientMandible : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 50;
            item.height = 57;
            item.maxStack = 99;
            item.value = Terraria.Item.sellPrice(0, 0, 5, 0);
            item.rare = 1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Primeval Mandible");
            Tooltip.SetDefault("The ancient mandible");
        }
    }
}