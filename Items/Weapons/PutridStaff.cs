using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class PutridStaff : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 42;
            item.magic = true;
            item.mana = 15;
            item.width = 46;
            item.height = 46;
            item.reuseDelay = 20;
            item.useTime = 11;
            item.useAnimation = 33;
            item.useStyle = 5;
            Item.staff[item.type] = true;

            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3.25f;
            item.value = 50000;
            item.rare = 5;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("PutridPlague");
            item.shootSpeed = 15f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 20);
            recipe.AddIngredient(ItemID.RottenChunk, 5);
            recipe.AddIngredient(ItemID.ShadowScale, 12);
            recipe.AddIngredient(null, ("PutridSpore"), 75);
            recipe.AddIngredient(null, ("CursedHeart"));
            recipe.AddTile(null, "GraniteAltar");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Toxic Touch");
            Tooltip.SetDefault("Fires 3 plague spreading projectiles\nHitting enemies releases plague spores\nIf any projectile kills an enemy, additional spores are released");
        }
    }
}