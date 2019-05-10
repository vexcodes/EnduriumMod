using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class GoldenKunai : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 17;
            item.thrown = true;
            item.noMelee = true;
            item.width = 14;
            item.height = 36;
            item.useTime = 24;
            item.crit = 15;
            item.useAnimation = 24;
            item.useStyle = 1;
            item.knockBack = 2;
            item.value = Terraria.Item.buyPrice(0, 0, 4, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("GoldenKunai");
            item.shootSpeed = 12f;
            item.useTurn = true;
            item.maxStack = 999;
            item.consumable = true;
            item.noUseGraphic = true;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golden Kunai");
            Tooltip.SetDefault("");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldBar, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }
    }
}
