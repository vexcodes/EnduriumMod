using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class MechanicalMachinegun : ModItem
    {
        public override void SetDefaults()
        {
            item.useStyle = 5;
            item.useAnimation = 4;
            item.useTime = 4;
            item.shootSpeed = 20f;
            item.knockBack = 5f;
            item.width = 114;
            item.height = 20;
            item.damage = 29;
            item.rare = 6;
            item.value = Item.sellPrice(0, 25, 0, 0);
            item.noMelee = true;
            item.noUseGraphic = true;
            item.ranged = true;
            item.channel = true;
            item.shoot = mod.ProjectileType("MechanicalMachinegun");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Minishark);
            recipe.AddIngredient(ItemID.IllegalGunParts, 5);
            recipe.AddIngredient(null, ("RoyalCrystal"), 25);
            recipe.AddIngredient(null, ("HolySilver"), 10);
            recipe.AddTile(null, "SoulForge");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical Machinegun");
            Tooltip.SetDefault("'Fire at will!'\nTurns all bullets into high velocity bullets");
        }
    }
}
