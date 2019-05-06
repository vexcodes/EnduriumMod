using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.DragonWarrior
{
    public class DragonBurstShot : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 60;
            item.ranged = true;
            item.width = 62;
            item.height = 26;
            item.useTime = 5;

            item.useAnimation = 20;
            item.reuseDelay = 5;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 8f;
            item.value = 125000;
            item.rare = 8;
            item.UseSound = SoundID.Item36;
            item.autoReuse = false;
            item.shoot = 10;
            item.shootSpeed = 30f;
            item.useAmmo = AmmoID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon Quickshot");
            Tooltip.SetDefault("Rapidly Fires 5 Bullets");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("DragonShard"), 15);
            recipe.AddIngredient(null, ("DragonBlood"), 15);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 25);
            recipe.AddTile(null, "AltarofFire");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }
    }
}