using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.EndurianWarlock
{
    public class FalconBroadsword : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 90;
            item.melee = true;
            item.width = 48;
            item.height = 62;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = 1;
            item.shoot = mod.ProjectileType("JungleEnergyBlade");
            item.shootSpeed = 12f;
            item.knockBack = 1;
            item.value = 45000;
            item.rare = 6;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("ElderBranch"), 20);
            recipe.AddTile(null, "AltarofNature");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numberProjectiles = 3; // 3, 4, or 5 shots
            float rotation = MathHelper.ToRadians(8);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage - 20, knockBack, player.whoAmI);
            }
            return false;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(2) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 89);
            }
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Falcon Broadsword");
            Tooltip.SetDefault("Fires 3 falcon blades in an even spread");
        }
    }
}