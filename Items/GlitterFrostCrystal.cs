using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items
{
    public class GlitterFrostCrystal : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 30;
            item.height = 30;
            item.maxStack = 99;

            item.value = Terraria.Item.sellPrice(0, 2, 1, 0);
            item.rare = 8;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frost Crystal");
        }    
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("IceEnergy"), 4);
			recipe.AddIngredient(ItemID.CrystalShard, 2);
            recipe.AddTile(null, "SoulForge");
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
        }
    }
}