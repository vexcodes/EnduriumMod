using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Rift
{
    public class ShadowRiftBlade : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 150;
            item.melee = true;
            item.width = 46;
            item.height = 46;
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = 1;

            item.knockBack = 1;
            item.value = 25000;
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("VoidBlade");
            item.shootSpeed = 8f;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fate Blade");
            Tooltip.SetDefault("'Cutting their lives short'");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 1; // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X *= 1.5f, perturbedSpeed.Y *= 1.5f, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("RiftShard"), 21);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
