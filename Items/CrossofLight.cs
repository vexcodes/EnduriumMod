using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace EnduriumMod.Items
{
    public class CrossofLight : ModItem
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
            DisplayName.SetDefault("Cross of Light");
            Tooltip.SetDefault("'Let there be light'");
        }

		public override bool UseItem(Player player)
		{
			Main.dayTime = true;
			return true;
		}
								        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 30);
            recipe.AddIngredient(null, ("MagmaCore"), 5);
			recipe.AddIngredient(null, ("MeteoritePowerCore"), 5);
			recipe.AddIngredient(null, ("IronCross"));
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
}
}