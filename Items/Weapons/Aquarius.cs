using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class Aquarius : ModItem
	{
        public override void SetDefaults()
        {

            item.damage = 40;
            item.melee = true;  
            item.useTime = 54;  
            item.useAnimation = 54; 
            item.useStyle = 5;
            item.channel = true;
            item.knockBack = 5f;
            item.value = Terraria.Item.sellPrice(0, 10, 25, 0);
            item.rare = 8;
            item.autoReuse = false;  
            item.shoot = mod.ProjectileType("Aquarius");   
            item.noUseGraphic = true; 
            item.noMelee = true;
            item.UseSound = SoundID.Item1; 
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aquarius");
            Tooltip.SetDefault("");
        }
		        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Amarok);
			recipe.AddIngredient(ItemID.Yelets);
		    recipe.AddIngredient(null, ("RoyalCrystal"), 25);
			recipe.AddIngredient(ItemID.SoulofLight, 20);
			recipe.AddIngredient(ItemID.SoulofNight, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
