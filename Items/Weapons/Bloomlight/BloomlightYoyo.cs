using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Bloomlight
{
    public class BloomlightYoyo : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 40;
            item.melee = true;
            item.useTime = 54;
            item.useAnimation = 54;
            item.useStyle = 5;
            item.channel = true;
            item.knockBack = 5f;
            item.value = Terraria.Item.sellPrice(0, 10, 25, 0);
            item.rare = 8;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("BloomlightYoyo");
            item.noUseGraphic = true;
            item.noMelee = true;
            item.UseSound = SoundID.Item1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloomlight Yoyo");
            Tooltip.SetDefault("");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BloomlightBar"), 14);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
