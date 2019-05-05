using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    public class SkylureCharm : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 30;
            item.height = 32;
            item.value = Terraria.Item.buyPrice(0, 1, 50, 0);
            item.rare = 7;
            item.accessory = true;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Skylure Emblem");
            Tooltip.SetDefault("Increases throwing damage, critical strike chance and velocity by 5%");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thrownDamage += 0.05f;
            player.thrownVelocity += 0.05f;
            player.thrownCrit += 5;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("SkyGlazeAlloy"), 20);
            recipe.AddTile(null, "SkyLamentAnvil");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
