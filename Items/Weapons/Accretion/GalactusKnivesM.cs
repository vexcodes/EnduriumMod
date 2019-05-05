using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Accretion
{
    public class GalactusKnivesM : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Galactus Kunai");
            Tooltip.SetDefault("'Tear through time and space.'");
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.crit += 40;
            item.damage = 120;
            item.melee = true;
            item.rare = 11;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useAnimation = 13;
            item.useStyle = 1;
            item.useTime = 13;
            item.knockBack = 4f;
            item.UseSound = SoundID.Item39;
            item.autoReuse = true;
            item.height = 40;
            item.maxStack = 1;
            item.value = 6700000;
            item.shoot = mod.ProjectileType("GalactusKnifeM");
            item.shootSpeed = 34f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AccretionBar", 37);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numberProjectiles = 5; // 3, 4, or 5 shots
            float rotation = MathHelper.ToRadians(14);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
                float scale = 1f - (Main.rand.NextFloat() * .5f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}
