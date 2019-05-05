using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace EnduriumMod.Items.ThePrismArcanum
{
    public class DarkCleaver : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 20;
            item.thrown = true;
            item.noMelee = false;
            item.width = 30;
            item.height = 42;
            item.useTime = 10;
            item.crit = 40;
            item.useAnimation = 10;
            item.useStyle = 1;
            item.knockBack = 9;
            item.value = Terraria.Item.buyPrice(0, 12, 6, 0);
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("DarkCleaver");
            item.shootSpeed = 12f;
            item.useTurn = true;
            item.noUseGraphic = true;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("FrozenCleaver"));
            recipe.AddIngredient(null, ("ShadowRemnants"), 18);
            recipe.AddIngredient(null, ("DuskSteel"), 18);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)

        {
            int numberProjectiles = 2 + Main.rand.Next(2); // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12)); // 30 degree spread.
                                                                                                                // If you want to randomize the speed to stagger the projectiles
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false; // return false because we don't want tmodloader to shoot projectile
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Cleaver");
            Tooltip.SetDefault("");
        }
    }
}
