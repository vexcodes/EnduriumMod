using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Rift
{
    public class ShadowRiftScythe : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 100;
            item.melee = true;
            item.width = 54;
            item.height = 54;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = 1;

            item.knockBack = 5;
            item.value = 1055000;
            item.rare = 10;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("SoulScythe");
            item.shootSpeed = 50f;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul Scythe");
            Tooltip.SetDefault("'The reaper that took their souls'");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numberProjectiles = 2; // 3, 4, or 5 shots
            float rotation = MathHelper.ToRadians(12);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 65f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
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
