using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.GleamingCrag
{
    public class IlluminatedIris : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 91;
            item.magic = true;
            item.mana = 16;
            item.width = 46;
            item.height = 46;
            item.useTime = 32;
            item.useAnimation = 32;
            item.useStyle = 1;


            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3.25f;
            item.value = 80000;
            item.rare = 3;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("IlluminatedIres");
            item.shootSpeed = 11f;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Illuminated Iris");
            Tooltip.SetDefault("Fires two bouncing balls of illuminated energy");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 2;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
                int gay = Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                Main.projectile[gay].penetrate = 1;
                Main.projectile[gay].timeLeft = 60;
            }
            return false;
        }
    }
}