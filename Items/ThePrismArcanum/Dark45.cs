using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.ThePrismArcanum
{
    public class Dark45 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark 45");
            Tooltip.SetDefault("Rapidly fires bullets\nHas a chance to release a homing shadow round");
        }
        public override void SetDefaults()
        {
            item.damage = 32;
            item.ranged = true;
            item.width = 56;
            item.height = 32;
            item.useAnimation = 6;
            item.useTime = 6;
            item.reuseDelay = 8;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = Terraria.Item.buyPrice(0, 26, 0, 0);
            item.rare = 6;
            item.UseSound = SoundID.Item41;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 19f;
            item.useAmmo = AmmoID.Bullet;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 50f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            int numberProjectiles = 1;
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(8));
            for (int i = 0; i < numberProjectiles; i++)
            {
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            if (Main.rand.Next(3) == 0)
            {
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("Dark45"), damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}