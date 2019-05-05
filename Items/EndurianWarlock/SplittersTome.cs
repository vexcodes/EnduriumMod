using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace EnduriumMod.Items.EndurianWarlock
{
    public class SplittersTome : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 68;
            item.magic = true;
            item.mana = 12;
            item.width = 50;
            item.height = 54;
            item.useAnimation = 21;
            item.useTime = 21;
            item.useStyle = 5;
            Item.staff[item.type] = true;
            item.noMelee = true; //so the item's animation doesn't do damage

            item.knockBack = 6.25f;
            item.value = 95000;
            item.rare = 8;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("PlagueSplit");
            item.shootSpeed = 18f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Splitter's Tome");
            Tooltip.SetDefault("Fires a splitting projectile");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 80f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            int numgay = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI, 1f, 1f); //This is spawning a projectile of type FrostburnArrow using the original stats
            Main.projectile[numgay].friendly = true;
            Main.projectile[numgay].hostile = false;
            Main.projectile[numgay].ai[0] = 1f;
            Main.projectile[numgay].penetrate = 1;
            return true;
        }
    }
}