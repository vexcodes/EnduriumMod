using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Acid
{
    public class AcidPike : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 56;

            item.melee = true;
            item.width = 70;
            item.height = 74;
            item.maxStack = 1;
            item.useTime = 14;
            item.useAnimation = 14;
            item.knockBack = 5f;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTurn = true;
            item.useStyle = 5;
            item.value = Item.sellPrice(0, 25, 25, 0);
            item.rare = 8;
            item.shoot = mod.ProjectileType("AcidPike");
            item.shootSpeed = 18f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endurian Pike");
            Tooltip.SetDefault("");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("AcidCore"), 17);
            recipe.AddIngredient(null, ("DarkDust"), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
	