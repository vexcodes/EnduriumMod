using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace EnduriumMod.Items.Weapons.ForestMimic
{
    public class NatureStaff2 : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 53;
            item.magic = true;
            item.mana = 15;
            item.width = 48;
            item.height = 48;
            item.useTime = 38;
            item.useAnimation = 38;
            Item.staff[item.type] = true;
            item.useStyle = 5;
            item.knockBack = 2;
            item.value = Terraria.Item.buyPrice(0, 8, 75, 0);
            item.rare = 2;
            item.UseSound = SoundID.Item8;
            item.autoReuse = true;
            item.shoot = ProjectileID.Leaf;
            item.shootSpeed = 9f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Overgrowth Rod");
            Tooltip.SetDefault("");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("TropicalFragment"), 2);
            recipe.AddRecipeGroup("Tier3HMBars", 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 5 + Main.rand.Next(2);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(18));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}