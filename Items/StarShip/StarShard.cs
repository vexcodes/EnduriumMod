using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.StarShip
{ 
    public class StarShard : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 20;
            item.height = 20;

            item.maxStack = 999;
            item.value = Terraria.Item.sellPrice(0, 5, 0, 0);
            item.rare = 7;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Shards");
			Tooltip.SetDefault("'Energized'");
        }
    }
}