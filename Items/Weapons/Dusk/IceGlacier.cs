using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Dusk
{
    public class IceGlacier : ModItem
    {
        int num1 = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glacier Claymore");
            Tooltip.SetDefault("Ocasionally releases ice bolts");
        }
        public override void SetDefaults()
        {

            item.damage = 50;
            item.melee = true;
            item.width = 52;
            item.height = 22;
            item.useTime = 33;
            item.useAnimation = 33;
            item.useStyle = 1;
            item.knockBack = 4.25f;
            item.value = 30000;
            item.rare = 5;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("IceGlacier");
            item.shootSpeed = 7f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("FrigidFragment"), 15);
            recipe.AddIngredient(null, ("DuskSteel"), 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-3, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 1 + Main.rand.Next(1); // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(4)); // 30 degree spread.                                                                                         // If you want to randomize the speed to stagger the projectiles
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI, Main.mouseX, Main.mouseY);
            }
            if (Main.rand.Next(4) == 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12)); // 30 degree spread.                                                                                         // If you want to randomize the speed to stagger the projectiles
                    float scale = 1f - (Main.rand.NextFloat() * .3f);
                    perturbedSpeed = perturbedSpeed * scale;
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 118, damage, knockBack, player.whoAmI, Main.mouseX, Main.mouseY);
                }
            }
                return false;
        }
    }
}
    

		