using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.SkyLament
{
    public class SkyPickaxe : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 16;
            item.melee = true;
            item.width = 36;
            item.height = 36;
            item.useTime = 9;
            item.useAnimation = 18;
            item.useStyle = 1;
            item.pick = 60;
            item.knockBack = 6;
            item.value = 50000;
            item.rare = 6;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sky Glory Pickaxe");
            Tooltip.SetDefault("");
        }
								public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("SkyGlazeAlloy"), 20);
            recipe.AddTile(null, "SkyLamentAnvil");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
