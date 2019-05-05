using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.MiniBiomes
{
    public class MarbleGreatbow : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 30;
            item.ranged = true;
            item.width = 24;
            item.height = 56;
            item.useTime = 46;
            item.useAnimation = 46;
            item.useStyle = 5;

            item.noMelee = true;
            item.knockBack = 4;
            item.value = Terraria.Item.buyPrice(0, 1, 25, 0);
            item.rare = 4;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 25f;
            item.useAmmo = AmmoID.Arrow;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rosy Gold Greatbow");
            Tooltip.SetDefault("Fires arrows at an extreme speed");
        }
			    public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
		}
					        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("RosyGoldChunk"), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}