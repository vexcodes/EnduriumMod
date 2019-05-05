using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Accretion
{
    public class AccretionTome : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 170;
            item.crit += 23;
            item.magic = true;
            item.mana = 16;
            item.width = 18;
            item.height = 22;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = 900000;
            item.rare = 11;
            item.UseSound = SoundID.Item15;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("AccretionOrb");
            item.shootSpeed = 3f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Accretion Tome");
            Tooltip.SetDefault("'The all-seeing eye manifests the book'\nLauches Accretion Orbs that home in enemies.");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AccretionBar", 36);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 3 + Main.rand.Next(2); // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(24)); // 30 degree spread.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false; // return false because we don't want tmodloader to shoot projectile
        }
    }
}