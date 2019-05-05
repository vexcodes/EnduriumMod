using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.ThePrismArcanum
{
    public class ShadowFlare : ModItem
    {
	        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Flare");
            Tooltip.SetDefault("Shoots a barrage of bouncing shadows");
        }
        public override void SetDefaults()
        {

            item.damage = 40;
            item.magic = true;
            item.mana = 30;
            item.width = 46;
            item.height = 46;
            item.useTime = 48;
            item.useAnimation = 48;
            item.useStyle = 5;
            Item.staff[item.type] = true;


            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3.25f;
            item.value = 90000;
            item.rare = 6;
            item.UseSound = SoundID.Item72;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("ShadowFlareBolt");
            item.shootSpeed = 11f;
        }
		        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 5 + Main.rand.Next(5);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(55));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("IceFlare"));
            recipe.AddIngredient(null, ("ShadowRemnants"), 20);
            recipe.AddIngredient(null, ("DuskSteel"), 16);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}