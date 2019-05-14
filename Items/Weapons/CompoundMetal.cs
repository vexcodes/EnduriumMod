using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class CompoundMetal : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 90;
            item.melee = true;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.channel = true;
            item.knockBack = 8f;
            item.value = Terraria.Item.sellPrice(0, 25, 25, 0);
            item.rare = 9;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("CompoundMetal");
            item.noUseGraphic = true;
            item.noMelee = true;
            item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.JungleYoyo);
            recipe.AddIngredient(null, ("TropicalFragment"), 2);
            recipe.AddIngredient(null, ("TempleFragment"), 10);
            recipe.AddIngredient(null, ("DarkDust"), 16);
            recipe.AddTile(null, "SoulForge");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)

        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("CompoundMetal"), damage, knockBack, player.whoAmI, 0f, 0f); //This is spawning a projectile of type FrostburnArrow using the original stats
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("CompoundMetal2"), damage, knockBack, player.whoAmI, 0f, 0f); //This is spawning a projectile of type FrostburnArrow using the original stats
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("CompoundMetal1"), damage, knockBack, player.whoAmI, 0f, 0f); //This is spawning a projectile of type FrostburnArrow using the original stats

            return false; // return false because we don't want tmodloader to shoot projectile
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Compound Metal");
            Tooltip.SetDefault("");
        }
    }
}