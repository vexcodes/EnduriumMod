using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.TheSpiritOfBloom
{
    public class LanceofPurity : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 42;

            item.melee = true;
            item.width = 64;
            item.height = 64;
            item.maxStack = 1;
            item.useTime = 51;
            item.useAnimation = 51;
            item.knockBack = 4f;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTurn = true;
            item.useStyle = 5;
            item.value = Item.sellPrice(0, 10, 25, 0);
            item.rare = 5;
            item.shoot = mod.ProjectileType("LanceofPurityS");
            item.shootSpeed = 2f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lance of Purity");
            Tooltip.SetDefault("'Lance of a holy reaper'");
        }

        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("SpiritSpear"));
            recipe.AddIngredient(null, ("ErodedShard"), 10);
            recipe.AddIngredient(null, ("RosyGoldChunk"), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}
