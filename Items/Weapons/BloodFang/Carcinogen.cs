using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.BloodFang
{
    public class Carcinogen : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 14;
            item.melee = true;  
            item.useTime = 29;  
            item.useAnimation = 29; 
            item.useStyle = 5;
            item.channel = true;
            item.knockBack = 2f;
            item.value = Terraria.Item.sellPrice(0, 1, 25, 0);
            item.rare = 3;
            item.autoReuse = false;  
            item.shoot = mod.ProjectileType("Carcinogen");   
            item.noUseGraphic = true; 
            item.noMelee = true;
            item.UseSound = SoundID.Item1; 
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Carcinogen");
            Tooltip.SetDefault("'Spread the plague'");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BloodFangCore"), 14);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
