using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.EndurianWarlock
{
    public class FalconCrossbow : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 55;
            item.ranged = true;
            item.width = 26;
            item.height = 50;
            item.useTime = 31;
            item.useAnimation = 31;
            item.useStyle = 5;

            item.noMelee = true;
            item.knockBack = 3;
            item.value = Terraria.Item.buyPrice(0, 5, 0, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 10f;
            item.useAmmo = AmmoID.Arrow;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 3 + Main.rand.Next(6);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(2));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elder Crossbow");
            Tooltip.SetDefault("");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("ElderBranch"), 20);
            recipe.AddTile(null, "AltarofNature");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}