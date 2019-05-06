using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class Shadeghasm : ModItem
    {
        public override void SetDefaults()
        {

            item.useStyle = 5;
            item.useAnimation = 20;
            item.useTime = 20;
            item.shootSpeed = 20f;
            item.knockBack = 2f;
            item.width = 20;
            item.height = 12;
            item.damage = 60;
            item.rare = 10;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.noMelee = true;
            item.noUseGraphic = true;
            item.ranged = true;
            item.channel = true;
            item.shoot = mod.ProjectileType("ShadegasmGun");

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("TropicalFragment"), 3);
            recipe.AddIngredient(null, ("DuskSteel"), 25);
            recipe.AddIngredient(null, ("BioScale"), 15);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadegasm");
            Tooltip.SetDefault("Fires Plaugue energy");
        }
    }
}