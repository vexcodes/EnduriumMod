using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.TheSpiritOfBloom
{
    public class BlessedBlade : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 27;
            item.melee = true;
            item.width = 76;
            item.height = 76;
            item.useTime = 36;
            item.useAnimation = 36;
            item.useStyle = 1;

            item.knockBack = 1;
            item.value = 15000;
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("WrathOfTheForest05");
            item.shootSpeed = 8f;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blessed Natura");
            Tooltip.SetDefault("Shoots a blooming beam\nInflicts nature reaper");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BloomlightBar"), 16);
            recipe.AddIngredient(null, ("TrueNatureEssence"), 13);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}