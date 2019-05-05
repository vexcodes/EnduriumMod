using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.TheSpiritOfBloom
{
    public class TheStaffOfBloom : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 21;
            item.magic = true;
            item.noMelee = true;
            item.width = 14;
            item.height = 36;
            item.useTime = 23;
            
            item.useAnimation = 23;
         item.useStyle = 5;
            Item.staff[item.type] = true;
            item.knockBack = 5;
            item.value = Terraria.Item.buyPrice(0, 2, 10, 0);
            item.rare = 4;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
			item.mana = 10;
            item.shoot = mod.ProjectileType("PlagueFeather");
            item.shootSpeed = 19f;
            item.useTurn = false;
            item.consumable = false;

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 80f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            int numgay = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[numgay].friendly = true;
            Main.projectile[numgay].hostile = false;
            Main.projectile[numgay].penetrate = 1;

            return true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Spirit Leaf Staff");
            Tooltip.SetDefault("Inflicts nature reaper");
        }

		        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BloomlightBar"), 17);
			            recipe.AddIngredient(null, ("TrueNatureEssence"), 16);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
