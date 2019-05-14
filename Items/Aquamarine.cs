using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items
{
    public class Aquamarine : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 50;
            item.height = 57;
            item.maxStack = 99;
            item.value = Terraria.Item.sellPrice(0, 0, 25, 0);
            item.rare = 7;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aquamarine");
            Tooltip.SetDefault("");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("AquaticCluster"), 10);
            recipe.AddIngredient(null, ("IceEnergy"), 1);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();
        }
    }
}