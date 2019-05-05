using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.SkyLament
{
    public class SkyWarHammer : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 41;
            item.melee = true;
            item.width = 64;
            item.height = 64;
            item.useTime = 12;
            item.useAnimation = 48;
            item.useStyle = 1;
            item.hammer = 60;
            item.knockBack = 6;
            item.value = 50000;
            item.rare = 7;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sky War Hammer");
            Tooltip.SetDefault("");
        }
		        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("SkyGlazeAlloy"), 16);
            recipe.AddTile(null, "SkyLamentAnvil");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
