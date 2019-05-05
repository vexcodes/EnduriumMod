using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class CorruptedPiercer : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 56;
            item.noMelee = true;
            item.ranged = true;
            item.width = 50;
            item.height = 68;
            item.useTime = 32;
            item.useAnimation = 32;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = AmmoID.Arrow;
            item.knockBack = 1;
            item.value = 100000;
            item.rare = 7;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 23f;

        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-16, 0);
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Corrupted Piercer");
            Tooltip.SetDefault("Every 5th fired arrow explodes into cursed inferno");
        }
        public int Dodo = 0;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Dodo += 1;
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 103, damage, knockBack, player.whoAmI, 0f, 0f); //This is spawning a projectile of type FrostburnArrow using the original stats
            if (Dodo >= 5)
            {
                Dodo = 0;
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("CursedPiercer"), damage + 50, knockBack, player.whoAmI, 0f, 0f); //This is spawning a projectile of type FrostburnArrow using the original stats
            }
            return false; //Makes sure to not fire the original projectile

        }
    
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemonBow);
            recipe.AddIngredient(ItemID.CursedFlames, 25);
            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}