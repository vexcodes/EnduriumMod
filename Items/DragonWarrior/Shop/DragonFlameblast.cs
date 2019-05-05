using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace EnduriumMod.Items.DragonWarrior.Shop
{
    public class DragonFlameblast : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 89;
            item.magic = true;
            item.mana = 14;
            item.width = 50;
            item.height = 54;
            item.useAnimation = 28;
            item.useTime = 28;
            item.useStyle = 5;
            Item.staff[item.type] = true;
            item.noMelee = true; //so the item's animation doesn't do damage

            item.knockBack = 6.25f;
            item.value = 45000;
            item.rare = 6;
            item.UseSound = SoundID.Item43;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("DragonFlameblast");
            item.shootSpeed = 18f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon Flameblast");
            Tooltip.SetDefault("Creates fire element magic");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 80f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            int numberProjectiles = 4 + Main.rand.Next(2); // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(8));
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                int numgay = Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 326, damage, knockBack, player.whoAmI);
                Main.projectile[numgay].friendly = true;
                Main.projectile[numgay].hostile = false;
                Main.projectile[numgay].penetrate = 1;
            }
            return true;
        }
    }
}