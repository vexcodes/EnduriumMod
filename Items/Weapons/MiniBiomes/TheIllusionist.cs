using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.MiniBiomes
{
    public class TheIllusionist : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 17;
            item.melee = true;
            item.useTime = 29;
            item.useAnimation = 29;
            item.useStyle = 5;
            item.channel = true;
            item.knockBack = 5f;
            item.value = Terraria.Item.sellPrice(0, 3, 25, 0);
            item.rare = 5;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("TheIllusionist");
            item.noUseGraphic = true;
            item.noMelee = true;
            item.UseSound = SoundID.Item1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Illusionist");
            Tooltip.SetDefault("");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("TheIllusionist"), damage, knockBack, player.whoAmI, 0f, 0f); //This is spawning a projectile of type FrostburnArrow using the original stats
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("TheIllusionist2"), damage, knockBack, player.whoAmI, 0f, 0f); //This is spawning a projectile of type FrostburnArrow using the original stats
            return false; // return false because we don't want tmodloader to shoot projectile
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("GraniteScale"), 17);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}