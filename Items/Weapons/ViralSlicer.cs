using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class ViralSlicer : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 80;
            item.melee = true;
            item.width = 52;
            item.height = 52;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 1;

            item.knockBack = 1;
            item.value = 25000;
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("ViralSlicer");
            item.shootSpeed = 12f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Viral Slicer");
            Tooltip.SetDefault("'All that is living will end eventually'");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("TropicalFragment"), 3);
            recipe.AddIngredient(null, ("DuskSteel"), 25);
            recipe.AddIngredient(null, ("BioScale"), 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}