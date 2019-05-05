using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.SkyLament
{
    public class GlimmerKnive : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 21;
            item.thrown = true;
            item.noMelee = true;
            item.width = 22;
            item.height = 32;
            item.useTime = 20;
            item.crit = 15;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 9;
            item.value = Terraria.Item.buyPrice(0, 0, 4, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("GlimmerKnive");
            item.shootSpeed = 12f;
            item.useTurn = true;
            item.maxStack = 999;
            item.consumable = true;
            item.noUseGraphic = true;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glimmer Knive");
            Tooltip.SetDefault("");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("SkyGlazeAlloy"), 3);
            recipe.AddTile(null, "SkyLamentAnvil");
            recipe.SetResult(this, 75);
            recipe.AddRecipe();
        }
    }
}
