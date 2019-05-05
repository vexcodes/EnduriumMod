using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.SkyLament
{
    public class DancingStar : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 21;
            item.melee = true;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = 5;
            item.channel = true;
            item.knockBack = 3f;
            item.value = Terraria.Item.sellPrice(0, 2, 25, 0);
            item.rare = 3;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("DancingStar");
            item.noUseGraphic = true;
            item.noMelee = true;
            item.UseSound = SoundID.Item1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dancing Star");
            Tooltip.SetDefault("");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("SkyGlazeAlloy"), 10);
            recipe.AddTile(null, "SkyLamentAnvil");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
