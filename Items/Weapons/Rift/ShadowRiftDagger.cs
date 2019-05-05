using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Rift
{
    public class ShadowRiftDagger : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 49;
            item.thrown = true;
            item.noMelee = false;
            item.width = 14;
            item.height = 36;
            item.useTime = 7;
            item.crit = 49;
            item.useAnimation = 7;
            item.useStyle = 1;
            item.knockBack = 9;
            item.value = Terraria.Item.buyPrice(0, 8, 0, 0);
            item.rare = 8;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("ShadowRiftDagger");
            item.shootSpeed = 16f;
            item.useTurn = true;
            item.maxStack = 999;
            item.consumable = true;
            item.noUseGraphic = true;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("RiftShard"), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 800);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Shiv");
            Tooltip.SetDefault("'Corrupting everyone who went in his path'");
        }
    }
}
