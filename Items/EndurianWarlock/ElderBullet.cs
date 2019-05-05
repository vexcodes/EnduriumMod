using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.EndurianWarlock
{
    public class ElderBullet : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elder Bullet");
            Tooltip.SetDefault("Releases elder energy upon collision");
        }
        public override void SetDefaults()
        {
            item.damage = 20;
            item.ranged = true;
            item.width = 22;
            item.height = 36;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 1.5f;
            item.value = 1200;
            item.rare = 3;
            item.shoot = mod.ProjectileType("ElderBullet");
            item.shootSpeed = 13f;
            item.ammo = AmmoID.Bullet;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("ElderBranch"), 5);
            recipe.AddIngredient(null, ("DarkDust"));
            recipe.AddTile(null, "AltarofNature");
            recipe.SetResult(this, 150);
            recipe.AddRecipe();
        }
    }
}