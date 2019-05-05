using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.MiniBiomes
{
    public class MarbleStaff : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 17;
            item.magic = true;
            item.mana = 14;
            item.width = 40;
            item.height = 40;
            item.useTime = 21;
            item.useAnimation = 21;
            item.useStyle = 5;
            Item.staff[item.type] = true;


            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3.25f;
            item.value = 30000;
            item.rare = 4;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("RosyBlast");
            item.shootSpeed = 12f;
        }
		        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rosy Gold Staff");
            Tooltip.SetDefault("");
        }
	        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("RosyGoldChunk"), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}