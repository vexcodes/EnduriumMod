using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class StarBreaker : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 50;
            item.melee = true;
            item.width = 36;
            item.height = 36;
            item.useTime = 2;
            item.useAnimation = 23;
            item.useStyle = 1;
            item.pick = 280;
            item.knockBack = 1;
            item.value = 1000000;
            item.rare = 9;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Breaker");
            Tooltip.SetDefault("Can break the curse of stars.");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("StarShard"), 5);
            recipe.AddIngredient(null, ("CoreofInfusion"), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}