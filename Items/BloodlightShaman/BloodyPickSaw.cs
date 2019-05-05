using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.BloodlightShaman
{
    public class BloodyPickSaw : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 13;
            item.melee = true;
            item.width = 46;
            item.height = 46;
            item.useTime = 9;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.axe = 15;
			            item.pick = 75;
            item.knockBack = 6;
            item.value = 50000;
            item.rare = 6;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloodlight Picksaw");
            Tooltip.SetDefault("");
        }
				        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			            recipe.AddIngredient(null, ("BloodlightBar"), 18);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
