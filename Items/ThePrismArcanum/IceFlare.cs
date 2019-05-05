using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.ThePrismArcanum
{
    public class IceFlare : ModItem
    {
	        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Flare");
            Tooltip.SetDefault("Shoots a barrage of ice");
        }
        public override void SetDefaults()
        {

            item.damage = 40;
            item.magic = true;
            item.mana = 20;
            item.width = 46;
            item.height = 46;
            item.useTime = 46;
            item.useAnimation = 46;
            item.useStyle = 5;
            Item.staff[item.type] = true;


            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3.25f;
            item.value = 90000;
            item.rare = 6;
            item.UseSound = SoundID.Item72;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("IceFlareBolt");
            item.shootSpeed = 11f;
        }
		        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 8 + Main.rand.Next(3);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(55));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}