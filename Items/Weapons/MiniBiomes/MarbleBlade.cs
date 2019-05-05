using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.MiniBiomes
{
    public class MarbleBlade : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 22;
            item.melee = true;
            item.width = 50;
            item.height = 50;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = 1;
            
            item.knockBack = 6;
            item.value = 35000;
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rosy Gold Sword");
            Tooltip.SetDefault("");
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
