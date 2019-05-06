using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.BloodlightShaman
{
    public class TheGoliath : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 14;
            item.ranged = true;
            item.width = 50;
            item.height = 30;
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 1;
            item.value = Terraria.Item.buyPrice(0, 3, 30, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 16f;
            item.useAmmo = AmmoID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sanguine Goliath");
            Tooltip.SetDefault("'An Unknown Source'");
        }


        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 48f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            MyPlayer p = player.GetModPlayer<MyPlayer>();
            if (p.SanguineGoliathDirection == 1)
            {
                p.SanguineGoliathOffSet -= 5;
            }
            if (p.SanguineGoliathDirection == -1)
            {
                p.SanguineGoliathOffSet += 5;
            }
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.ToRadians(p.SanguineGoliathOffSet));
            float scale = 1f - (Main.rand.NextFloat() * .3f);
            perturbedSpeed = perturbedSpeed * scale;
            Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("BloodyRocket"), damage, knockBack, player.whoAmI);

            return false;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }
    }
}