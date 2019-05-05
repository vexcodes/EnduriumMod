using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.TheSpiritOfBloom
{
    public class BloomSawblade : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 16;
            item.thrown = true;
            item.noMelee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 23;
            item.crit = 10;
            item.useAnimation = 23;
            item.useStyle = 1;
            item.knockBack = 9;
            item.value = Terraria.Item.buyPrice(0, 0, 1, 0);
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("BloomSawblade");
            item.shootSpeed = 10f;
            item.useTurn = true;
            item.consumable = false;
            item.noUseGraphic = true;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloom Sawblade");
            Tooltip.SetDefault("Homes onto enemies");
        }

		        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BloomlightBar"), 5);
			            recipe.AddIngredient(null, ("TrueNatureEssence"), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 200);
            recipe.AddRecipe();
        }
    }
}
