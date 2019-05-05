using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class BloodClawStaff : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 54;
            item.magic = true;
            item.mana = 12;
            item.width = 62;
            item.height = 64;
            item.useTime = 39;
            item.useAnimation = 39;
            item.useStyle = 5;
			        Item.staff[item.type] = true;

            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3.25f;
            item.value = 50000;
            item.rare = 5;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("BloodyBeam");
            item.shootSpeed = 7f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 20);
        recipe.AddIngredient(ItemID.Vertebrae, 5);
            recipe.AddIngredient(null, ("BloodDust"), 5);
            recipe.AddIngredient(null, ("CursedHeart"));
            recipe.AddTile(null, "GraniteAltar");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vampire Claw Staff");
            Tooltip.SetDefault("Creates a beam of blood energy\nUpon hitting an enemy the beam will split\nHitting an enemy has a chance to steal health");
        }
    }
}