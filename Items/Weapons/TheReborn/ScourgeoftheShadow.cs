using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.TheReborn
{
    public class ScourgeoftheShadow : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 180;
            item.melee = true;
            item.noMelee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 24;
            item.crit = 10;
            item.useAnimation = 24;
            item.useStyle = 1;
            item.knockBack = 9;
            item.value = Terraria.Item.buyPrice(1, 0, 0, 0);
            item.rare = 10;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("ScourgeoftheShadow");
            item.shootSpeed = 12f;
            item.useTurn = true;
            item.consumable = false;
            item.noUseGraphic = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ScourgeoftheCorruptor);
            recipe.AddIngredient(null, ("CoreofRebirth"));
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scourge of the Shadows");
            Tooltip.SetDefault("");
        }
    }
}
