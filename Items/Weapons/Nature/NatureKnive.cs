using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Nature
{
    public class NatureKnive : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 17;
            item.thrown = true;
            item.noMelee = true;
            item.width = 22;
            item.height = 32;
            item.useTime = 24;
            item.crit = 13;
            item.useAnimation = 24;
            item.useStyle = 1;
            item.knockBack = 9;
            item.value = Terraria.Item.buyPrice(0, 0, 3, 50);
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("NatureKnive");
            item.shootSpeed = 12f;
            item.useTurn = true;
            item.maxStack = 999;
            item.consumable = true;
            item.noUseGraphic = true;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tropical Dagger");
            Tooltip.SetDefault("");
        }
					        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("NatureEssence"), 5);
            recipe.AddIngredient(null, ("ThornWood"), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 75);
            recipe.AddRecipe();
        }
    }
}
