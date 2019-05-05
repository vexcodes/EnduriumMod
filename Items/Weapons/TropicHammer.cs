using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class TropicHammer : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 82;
            item.thrown = true;
            item.width = 46;
            item.height = 46;
            item.useTime = 32;
            item.useAnimation = 32;
            item.useStyle = 1;
            item.shoot = mod.ProjectileType("TropicHammer");
            item.shootSpeed = 14f;
            item.knockBack = 1;
            item.value = 25000;
            item.rare = 4;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tropic Hammer");
            Tooltip.SetDefault("Throws a furious tropic hammer that explodes into tropic spikes upon hitting an enemy");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("TropicalFragment"), 2);
            recipe.AddRecipeGroup("Tier3HMBars", 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
