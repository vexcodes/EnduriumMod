using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items
{ 
    public class RosyGoldChunk : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 20;
            item.height = 20;

            item.maxStack = 999;
            item.value = Terraria.Item.sellPrice(0, 0, 3, 0);
            item.rare = 2;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rosy Gold Chunk");
        }
    }
}