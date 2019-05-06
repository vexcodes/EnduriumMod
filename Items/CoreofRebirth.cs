using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items
{
    public class CoreofRebirth : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 32;
            item.height = 32;
            item.maxStack = 20;

            item.rare = 10;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Core of Rebirth");
            Tooltip.SetDefault("'The Reincarnation'\nUnobtaineable, do not question the texture");
        }

        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("MoonPlasm"), 25);
            recipe.AddIngredient(null, ("EmberofFlames")); //the gatekeeper
            recipe.AddIngredient(null, ("ShardofNight")); //the cultist
            recipe.AddIngredient(null, ("TropicRune")); //plantera
            recipe.AddIngredient(null, ("CoreofInfusion"));//star fortress
            recipe.AddIngredient(null, ("SoulofDusk"), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}
