using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class IronSawblade : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 13;
            item.thrown = true;
            item.noMelee = true;
            item.width = 14;
            item.height = 36;
            item.useTime = 21;
            item.crit = 8;
            item.useAnimation = 21;
            item.useStyle = 1;
            item.knockBack = 4;
            item.value = Terraria.Item.buyPrice(0, 0, 2, 0);
            item.rare = 0;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("IronSawblade");
            item.shootSpeed = 11f;
            item.useTurn = true;
            item.maxStack = 999;
            item.consumable = true;
            item.noUseGraphic = true;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Iron Sawblade");
            Tooltip.SetDefault("");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 75);
            recipe.AddRecipe();
        }
    }
}
