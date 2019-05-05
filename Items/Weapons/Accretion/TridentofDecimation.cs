using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Accretion
{
	public class TridentofDecimation : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infernix");
            Tooltip.SetDefault("Throw a trident that releases a long lasting explosion with 8 additional tridents");
        }

        public override void SetDefaults()
		{
			item.width = 64;  //The width of the .png file in pixels divided by 2.
			item.damage = 180;  //Keep this reasonable please.
			item.noMelee = true;  //Dictates whether this is a melee-class weapon.
			item.noUseGraphic = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.useTime = 15;
			item.knockBack = 9f;  //Ranges from 1 to 9.
			item.UseSound = SoundID.Item1;
			item.thrown = true;  //Dictates whether the weapon can be "auto-fired".
			item.height = 64;  //The height of the .png file in pixels divided by 2.
			item.value = 333000;  //Value is calculated in copper coins.
			item.rare = 11;  //Ranges from 1 to 11.
			item.shoot = mod.ProjectileType("TridentofDecimation");
			item.shootSpeed = 40f;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AccretionBar", 33);
            recipe.AddTile(TileID.LunarCraftingStation);
	        recipe.SetResult(this);
	        recipe.AddRecipe();
		}
    }
}
