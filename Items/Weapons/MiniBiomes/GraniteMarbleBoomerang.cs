using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.MiniBiomes
{
    public class GraniteMarbleBoomerang : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 22;
		item.width = 18;  //The width of the .png file in pixels divided by 2.
		item.noMelee = true;  //Dictates whether this is a melee-class weapon.
		item.noUseGraphic = true;
		item.useAnimation = 20;
		item.useStyle = 1;
		item.useTime = 20;
		item.knockBack = 5.5f;  //Ranges from 1 to 9.
		item.UseSound = SoundID.Item1;
		item.thrown = true;  //Dictates whether the weapon can be "auto-fired".
		item.height = 34;  //The height of the .png file in pixels divided by 2.
		item.value = 50000;  //Value is calculated in copper coins.
		item.rare = 2;  //Ranges from 1 to 11.
		item.shoot = mod.ProjectileType("GraniteMarbleBoomerang");
		item.shootSpeed = 13.5f;
	}
						    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.Next(5) == 0)
        {
        	int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 121);
        }
    }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("GraniteBoomerang"));
			            recipe.AddIngredient(null, ("MarbleBomerang"));
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rosy Granite Boomerang");
            Tooltip.SetDefault("");
        }
    }
}