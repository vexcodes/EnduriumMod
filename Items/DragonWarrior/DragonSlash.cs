using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.DragonWarrior
{
    public class DragonSlash : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 150;
            item.melee = true;
            item.width = 46;
            item.height = 46;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;

            item.knockBack = 1;
            item.value = 25000;
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("DragonSlash");
            item.shootSpeed = 12f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("DragonShard"), 13);
            recipe.AddIngredient(null, ("DragonBlood"), 13);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 25);
            recipe.AddTile(null, "AltarofFire");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon Feast Blade");
            Tooltip.SetDefault("Fires a blade of hot magma");
        }
    }
}