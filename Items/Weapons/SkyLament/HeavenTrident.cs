using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.SkyLament
{
    public class HeavenTrident : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 18;

            item.melee = true;
            item.width = 44;
            item.height = 44;
            item.maxStack = 1;
            item.useTime = 19;
            item.useAnimation = 19;
            item.knockBack = 3f;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTurn = true;
            item.useStyle = 5;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 4;
            item.shoot = mod.ProjectileType("HeavenTrident");
            item.shootSpeed = 6f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heaven Grail");
            Tooltip.SetDefault("");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 2;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("HeavenTrident"), damage, knockBack, player.whoAmI);
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("SkyGlazeAlloy"), 12);
            recipe.AddTile(null, "SkyLamentAnvil");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
