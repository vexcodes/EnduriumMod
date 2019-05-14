using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Bloomlight
{
    public class OrbTome : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Razor Tome");
            Tooltip.SetDefault("'Casts cutting leaves");
        }
        public override void SetDefaults()
        {

            item.damage = 24;
            item.magic = true;
            item.mana = 10;
            item.width = 46;
            item.height = 46;
            item.useTime = 11;
            item.useAnimation = 33;
            item.reuseDelay = 15;
            item.useStyle = 5;


            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3.25f;
            item.value = 20000;
            item.rare = 3;
            item.UseSound = SoundID.Item72;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("OrbTome");
            item.shootSpeed = 14f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BloomlightBar"), 14);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}