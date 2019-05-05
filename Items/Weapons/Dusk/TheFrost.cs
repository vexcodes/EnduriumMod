using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Dusk
{
    public class TheFrost : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 38;
            item.melee = true;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 5;
            item.channel = true;
            item.knockBack = 2f;
            item.value = Terraria.Item.sellPrice(0, 10, 25, 0);
            item.rare = 6;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("TheFrost");
            item.noUseGraphic = true;
            item.noMelee = true;
            item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("FrigidFragment"), 15);
            recipe.AddIngredient(null, ("DuskSteel"), 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Frost");
            Tooltip.SetDefault("");
        }
    }
}
