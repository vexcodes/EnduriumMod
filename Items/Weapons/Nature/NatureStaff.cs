using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Nature
{
    public class NatureStaff : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 15;
            item.magic = true;
            item.mana = 5;
            item.width = 46;
            item.height = 46;
            item.useTime = 17;
            item.useAnimation = 17;
            item.useStyle = 5;
            Item.staff[item.type] = true;


            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3.25f;
            item.value = 20000;
            item.rare = 3;
            item.UseSound = SoundID.Item72;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("NatureBlast");
            item.shootSpeed = 9f;
        }
		        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tropical Staff");
            Tooltip.SetDefault("");
        }
					        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("NatureEssence"), 16);
            recipe.AddIngredient(null, ("ThornWood"), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}