using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Rift
{
    public class ShadowRiftStaff : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 112;
            item.mana = 10;
            item.magic = true;
            item.width = 70;
            item.height = 74;
            item.maxStack = 1;
            item.useTime = 56;
            item.useAnimation = 56;
            item.knockBack = 5f;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.useTurn = false;
            Item.staff[item.type] = true;
            item.useStyle = 5;
            item.value = Item.sellPrice(0, 25, 25, 0);
            item.rare = 8;
            item.shoot = mod.ProjectileType("VoidRift");
            item.shootSpeed = 6f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Void Rift Staff");
            Tooltip.SetDefault("'Releasing souls of thousents'");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 95f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("RiftShard"), 17);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
