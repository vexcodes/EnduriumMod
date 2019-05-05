using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.MiniBiomes
{
    public class MarbleDagger : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 19;
            item.thrown = true;
            item.noMelee = true;
            item.width = 38;
            item.height = 38;
            item.useTime = 42;
            item.crit = 18;
            item.useAnimation = 42;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = Terraria.Item.buyPrice(0, 1, 0, 0);
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("MarbleDagger");
            item.shootSpeed = 23f;
            item.useTurn = true;
            item.consumable = false;
            item.noUseGraphic = true;

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 2 + Main.rand.Next(3);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("MarbleDagger"), damage, knockBack, player.whoAmI);
            }
            return true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rosy Gold Daggers");
            Tooltip.SetDefault("'A volley of burning knives'");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("RosyGoldChunk"), 19);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}