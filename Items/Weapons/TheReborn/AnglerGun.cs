using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.TheReborn
{
    public class AnglerGun : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 200;
            item.channel = true;
            item.ranged = true;
            item.width = 62;
            item.height = 28;
            item.crit = 16;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 1;
            item.value = 900000;
            item.rare = 9;
            item.UseSound = SoundID.Item10;
            item.autoReuse = true;
            item.useTurn = false;
            item.shootSpeed = 15f;
            item.shoot = mod.ProjectileType("MechanicalAngler");  //This defines what type of projectile this weapon will shoot  
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical Angler Fish Gun");
            Tooltip.SetDefault("");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PiranhaGun);
            recipe.AddIngredient(null, ("CoreofRebirth"));
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}