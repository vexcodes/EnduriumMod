using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace EnduriumMod.Items
{
    public class CrossofDarkness : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 38;
            item.height = 32;
            item.maxStack = 1;

            item.rare = 6;
            item.useAnimation = 55;
            item.useTime = 55;
            item.useStyle = 4;
            item.UseSound = SoundID.Item43;

        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cross of Darkness");
            Tooltip.SetDefault("'Darkness shall rise'");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("CursedHeart"));
            recipe.AddIngredient(null, ("PrismShard"), 5);
            recipe.AddIngredient(null, ("IceEnergy"), 5);
            recipe.AddIngredient(ItemID.FallenStar, 5);
            recipe.AddIngredient(null, ("IronCross"));
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool UseItem(Player player)
        {
            Main.dayTime = false;
            return true;
        }
    }
}