using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class MeteoriteSawblade : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 25;
            item.thrown = true;
            item.noMelee = true;
            item.width = 14;
            item.height = 36;
            item.useTime = 28;
            item.crit = 25;
            item.useAnimation = 28;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = Terraria.Item.buyPrice(0, 0, 10, 0);
            item.rare = 5;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("MeteoriteSawblade");
            item.shootSpeed = 16f;
            item.useTurn = true;
            item.maxStack = 999;
            item.consumable = true;
            item.noUseGraphic = true;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meteorite Sawblade");
            Tooltip.SetDefault("");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MeteoriteBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 150);
            recipe.AddRecipe();
        }
    }
}
