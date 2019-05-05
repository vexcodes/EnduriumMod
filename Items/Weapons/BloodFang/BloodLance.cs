using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.BloodFang
{
    public class BloodLance : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 14;

            item.melee = true;
            item.width = 52;
            item.height = 52;
            item.maxStack = 1;
            item.useTime = 18;
            item.useAnimation = 18;
            item.knockBack = 4f;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTurn = true;
            item.useStyle = 5;
            item.value = Item.sellPrice(0, 1, 25, 0);
            item.rare = 3;
            item.shoot = mod.ProjectileType("BloodLance");
            item.shootSpeed = 7f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Clot Lance");
            Tooltip.SetDefault("'Let the blood flow'");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BloodFangCore"), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
