using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.BloodlightShaman
{
    public class BloodyHammer : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 13;
            item.melee = true;
            item.width = 46;
            item.height = 46;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = 1;
            item.hammer = 50;
            item.knockBack = 6;
            item.value = 50000;
            item.rare = 6;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloodlight Hammer");
            Tooltip.SetDefault("");
        }
				        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			            recipe.AddIngredient(null, ("BloodlightBar"), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
