using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace EnduriumMod.Items.TheScourge
{
    public class SapSpray : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 80;
            item.magic = true;
            item.mana = 12;
            item.width = 50;
            item.height = 54;
            item.useAnimation = 10;
            item.useTime = 10;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage

            item.knockBack = 6.25f;
            item.value = 45000;
            item.rare = 6;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("Sap");
            item.shootSpeed = 18f;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sap Spray");
            Tooltip.SetDefault("Fires Sap");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            {
                Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 40f;
                if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
                {
                    position += muzzleOffset;
                }
            }
            return true;
        }
    }
}