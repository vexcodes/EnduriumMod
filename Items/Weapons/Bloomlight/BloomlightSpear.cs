using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Bloomlight
{
    public class BloomlightSpear : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 32;

            item.melee = true;
            item.width = 54;
            item.height = 54;
            item.maxStack = 1;
            item.useTime = 14;
            item.useAnimation = 14;
            item.knockBack = 5f;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTurn = true;
            item.useStyle = 5;
            item.value = Item.sellPrice(0, 6, 0, 0);
            item.rare = 8;
            item.shoot = mod.ProjectileType("BloomlightSpear");
            item.shootSpeed = 11f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloomlight Spear");
            Tooltip.SetDefault("");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BloomlightBar"), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));                                                                                          // perturbedSpeed = perturbedSpeed * scale; 
            Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            return false; // return false because we don't want tmodloader to shoot projectile
        }
    }
}