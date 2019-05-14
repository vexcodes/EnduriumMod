using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class BloodSpikelash : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 25;
            item.melee = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.knockBack = 8;
            item.value = 246000;
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.channel = true;
            item.shoot = mod.ProjectileType("BloodSpikelash");
            item.shootSpeed = 12f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Spikelash");
            Tooltip.SetDefault("'A dangerous thorned spikeball'");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Chain, 5);
            recipe.AddRecipeGroup("PlatinumBars", 10);
            recipe.AddIngredient(null, ("MeteoritePowerCore"), 5);
            recipe.AddIngredient(null, ("BloodFangCore"), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}

