using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Nature
{
    public class NatureBow : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 21;
            item.ranged = true;
            item.width = 26;
            item.height = 50;
            item.useTime = 35;
            item.useAnimation = 35;
            item.useStyle = 5;

            item.noMelee = true;
            item.knockBack = 4;
            item.value = Terraria.Item.buyPrice(0, 1, 25, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 10f;
            item.useAmmo = AmmoID.Arrow;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tropical Bow");
            Tooltip.SetDefault("");
        }
					        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("NatureEssence"), 17);
            recipe.AddIngredient(null, ("ThornWood"), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}