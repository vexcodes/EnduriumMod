using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.GleamingCrag
{
    public class SeraphicScimitar : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 51;
            item.melee = true;
            item.width = 46;
            item.height = 46;
            item.useTime = 34;
            item.useAnimation = 34;
            item.useStyle = 1;

            item.knockBack = 1;
            item.value = 25000;
            item.rare = 6;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("CrystalSplit");
            item.shootSpeed = 8f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("GleamingCrag"), 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Seraphic Scimitar");
            Tooltip.SetDefault("Fires splitting Crystal bolts");
        }
    }
}
