using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace EnduriumMod.Items.Weapons.ForestMimic
{
    public class BloomRang : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 52;
            item.thrown = true;
            item.width = 36;
            item.height = 36;
            item.useTime = 28;
            item.useAnimation = 28;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = Terraria.Item.buyPrice(0, 15, 35, 0);
            item.rare = 8;
            item.shootSpeed = 16f;
            item.shoot = mod.ProjectileType("BloomRang");
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
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
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloom-a-Rang");
            Tooltip.SetDefault("Hitting enemies causes explosions");
        }
    }
}