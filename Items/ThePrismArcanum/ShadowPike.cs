using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.ThePrismArcanum
{
    public class ShadowPike : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 60;

            item.melee = true;
            item.width = 68;
            item.height = 68;
            item.maxStack = 1;
            item.useTime = 21;
            item.useAnimation = 21;
            item.knockBack = 4f;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTurn = true;
            item.useStyle = 5;
            item.value = Item.sellPrice(0, 15, 25, 0);
            item.rare = 6;
            item.shoot = mod.ProjectileType("ShadowPike");
            item.shootSpeed = 11f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("ArcanumPike"));
            recipe.AddIngredient(null, ("ShadowRemnants"), 18);
            recipe.AddIngredient(null, ("DuskSteel"), 18);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Pike");
            Tooltip.SetDefault("");
        }
    }
}