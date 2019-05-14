using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items
{
    public class CoreofCreation : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 30;
            item.height = 30;
            item.maxStack = 999;
            item.scale = 1.4f;
            item.value = Terraria.Item.sellPrice(0, 10, 0, 0);
            item.rare = 10;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Core of Creation");
            Tooltip.SetDefault("'You came this far, and achived so much'");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 8));
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("Aquamarine"), 4);
            recipe.AddIngredient(null, ("CrypticPowerCell"), 4);
            recipe.AddIngredient(null, ("MeteoritePowerCore"), 4);
            recipe.AddIngredient(null, ("MagmaCore"), 4);
            recipe.AddIngredient(null, ("FrigidFragment"), 4);
            recipe.AddIngredient(null, ("FieryTissue"), 4);
            recipe.AddIngredient(null, ("BloodFangCore"), 4);
            recipe.AddIngredient(null, ("TempleFragment"), 4);
            recipe.AddIngredient(ItemID.LunarOre, 4);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
        }
    }
}