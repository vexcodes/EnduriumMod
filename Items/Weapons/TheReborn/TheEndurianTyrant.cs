using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.TheReborn
{
    public class TheEndurianTyrant : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 140;
            item.width = 72;  //The width of the .png file in pixels divided by 2.
            item.noMelee = true;  //Dictates whether this is a melee-class weapon.
            item.noUseGraphic = true;
            item.autoReuse = true;
            item.useAnimation = 19;
            item.useStyle = 1;
            item.useTime = 19;
            item.knockBack = 25f;  //Ranges from 1 to 9.
            item.UseSound = SoundID.Item1;
            item.thrown = true;  //Dictates whether the weapon can be "auto-fired".
            item.height = 72;  //The height of the .png file in pixels divided by 2.
            item.value = 1000000;  //Value is calculated in copper coins.
            item.rare = 10;  //Ranges from 1 to 11.
            item.shoot = mod.ProjectileType("TheEndurianTyrant");
            item.shootSpeed = 30f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("TheTyrant"));
            recipe.AddIngredient(null, ("CoreofRebirth"));
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("War Tyrant of Might");
            Tooltip.SetDefault("'The power of the tyrant is sealed withing'\nHitting enemies will cause explosions\nCritical strikes will give you a throwing damage boost for a short time");
        }
    }
}