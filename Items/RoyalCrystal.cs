using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items
{ 
    public class RoyalCrystal : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 20;
            item.height = 20;

            item.maxStack = 999;
            item.value = Terraria.Item.sellPrice(0, 1, 0, 0);
            item.rare = 2;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Royal Crystal");
        }
		        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("GraniteScale"), 5);
		    recipe.AddIngredient(null, ("RosyGoldChunk"), 5);
			recipe.AddIngredient(null, ("PrismShard"), 5);
            recipe.AddIngredient(null, ("TempleFragment"), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 15);
            recipe.AddRecipe();
        }
    }
}