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

            item.damage = 52;
            item.magic = true;
            item.mana = 15;
            item.width = 46;
            item.height = 46;
            item.useTime = 46;
            item.useAnimation = 46;
            item.useStyle = 1;


            item.noMelee = false; //so the item's animation doesn't do damage
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
            recipe.AddIngredient(null, ("PutridSpore"), 5);
            recipe.AddIngredient(null, ("CursedHeart"));
            recipe.AddTile(null, "GraniteAltar");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Putrid Shade Scepter");
            Tooltip.SetDefault("Lunches a plague spore into the air\nThe plague will consume enemies and inflict several debuffs\nWhen enemies are consumed the plague releases additional spores");
        }
    }
}