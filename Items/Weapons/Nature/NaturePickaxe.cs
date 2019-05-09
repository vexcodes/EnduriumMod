using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Nature
{
    public class NaturePickaxe : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 13;
            item.melee = true;
            item.width = 36;
            item.height = 36;
            item.useTime = 10;
            item.useAnimation = 18;
            item.useStyle = 1;
            item.pick = 55;
            item.knockBack = 5;
            item.value = 30000;
            item.rare = 1;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tropical Pickaxe");
            Tooltip.SetDefault("");
        }
					        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("NatureEssence"), 7);
            recipe.AddIngredient(null, ("ThornWood"), 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
