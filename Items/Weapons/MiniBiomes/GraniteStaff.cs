using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.MiniBiomes
{
    public class GraniteStaff : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 21;
            item.magic = true;
            item.mana = 25;
            item.width = 46;
            item.height = 46;
            item.useTime = 33;
            item.useAnimation = 33;
            item.useStyle = 5;
            Item.staff[item.type] = true;


            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 7.25f;
            item.value = 30000;
            item.rare = 5;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("GraniteParticle");
            item.shootSpeed = 9f;
        }
		        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Particle Staff");
            Tooltip.SetDefault("Rips through enemy defense");
        }
	        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("GraniteScale"), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}