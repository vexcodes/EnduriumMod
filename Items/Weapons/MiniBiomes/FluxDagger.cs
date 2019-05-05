using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.MiniBiomes
{
    public class FluxDagger : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 27;
            item.thrown = true;
            item.noMelee = true;
            item.width = 18;
            item.height = 42;
            item.useTime = 31;
            item.useAnimation = 31;
            item.useStyle = 1;
            item.knockBack = 6f;
            item.value = Terraria.Item.buyPrice(0, 2, 0, 0);
            item.rare = 7;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("FluxDagger");
            item.shootSpeed = 14f;
            item.useTurn = true;
            item.noUseGraphic = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Energy Dagger");
            Tooltip.SetDefault("'Energized'");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("GraniteScale"), 16);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}