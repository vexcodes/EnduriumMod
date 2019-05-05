using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.TheSpiritOfBloom
{
    public class BlessedHatchet : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 19;
            item.thrown = true;
            item.noMelee = true;
            item.width = 14;
            item.height = 36;
            item.useTime = 33;
            item.crit = 10;
            item.useAnimation = 33;
            item.useStyle = 1;
            item.knockBack = 9;
            item.value = Terraria.Item.buyPrice(0, 2, 10, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("BlessedHatchet");
            item.shootSpeed = 10f;
            item.useTurn = true;
            item.consumable = false;
            item.noUseGraphic = true;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Falcon Hatchet");
            Tooltip.SetDefault("Splits into 2 leafs after some time\nInflicts nature reaper");
        }

		        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BloomlightBar"), 17);
			            recipe.AddIngredient(null, ("TrueNatureEssence"), 13);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
