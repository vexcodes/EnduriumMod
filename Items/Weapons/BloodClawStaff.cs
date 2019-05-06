using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class BloodClawStaff : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 44;
            item.magic = true;
            item.mana = 12;
            item.width = 62;
            item.height = 64;
            item.useTime = 39;
            item.useAnimation = 39;
            item.useStyle = 5;
            Item.staff[item.type] = true;

            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3.25f;
            item.value = 50000;
            item.rare = 5;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("BloodyBeam");
            item.shootSpeed = 7f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 20);
            recipe.AddIngredient(ItemID.Vertebrae, 5);
            recipe.AddIngredient(ItemID.TissueSample, 12);
            recipe.AddIngredient(null, ("BloodDust"), 75);
            recipe.AddIngredient(null, ("CursedHeart"));
            recipe.AddTile(null, "GraniteAltar");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 65f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Leeching Claw");
            Tooltip.SetDefault("Fires a leeching wave\nHitting enemies has a chance to recover health\nHitting enemies spawns extra beams around the player");
        }
    }
}