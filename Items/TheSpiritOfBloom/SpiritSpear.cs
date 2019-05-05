using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.TheSpiritOfBloom
{
    public class SpiritSpear : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 19;

            item.melee = true;
            item.width = 64;
            item.height = 64;
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
            item.shoot = mod.ProjectileType("SpiritSpear");
            item.shootSpeed = 9f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spirit Lance");
            Tooltip.SetDefault("Attacks will restore health\nInflicts nature reaper");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BloomlightBar"), 18);
			            recipe.AddIngredient(null, ("TrueNatureEssence"), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
