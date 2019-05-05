using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.ThePrismArcanum
{
    public class DarkLament : ModItem
    {
	        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Lament");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {

            item.damage = 60;
            item.magic = true;
            item.mana = 16;
            item.width = 46;
            item.height = 46;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = 5;
            Item.staff[item.type] = true;


            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3.25f;
            item.value = 20000;
            item.rare = 6;
            item.UseSound = SoundID.Item72;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("DarkMagic");
            item.shootSpeed = 0.05f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("TheArcticWind"));
            recipe.AddIngredient(null, ("ShadowRemnants"), 20);
            recipe.AddIngredient(null, ("DuskSteel"), 16);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}