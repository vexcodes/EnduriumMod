using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class HellfireStaff : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 60;
            item.magic = true;
            item.mana = 20;
            item.width = 46;
            item.height = 46;
            item.useTime = 31;
            item.useAnimation = 31;
            item.useStyle = 5;
            Item.staff[item.type] = true;


            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3.25f;
            item.value = 80000;
            item.rare = 3;
            item.UseSound = SoundID.Item43;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("FireBlast");
            item.shootSpeed = 11f;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Staff of Inferno");
            Tooltip.SetDefault("");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 3 + Main.rand.Next(2);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(7));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            int numberProjectiles2 = 2 + Main.rand.Next(2);
            for (int c = 0; c < numberProjectiles2; c++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(3));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("Flame"), damage, knockBack, player.whoAmI);
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("HellfireScepter"));
            recipe.AddIngredient(ItemID.Flamelash);
            recipe.AddIngredient(null, ("RoyalCrystal"), 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}