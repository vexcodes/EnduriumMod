using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class StarMachineChainGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Arc Chain Gun");
            Tooltip.SetDefault("Rapidly fires lasers that explode on contact");
        }
        public override void SetDefaults()
        {

            item.damage = 78;
            item.magic = true;
            item.mana = 5;
            item.width = 68;
            item.height = 28;
            item.useTime = 8;
            item.useAnimation = 8;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 4.25f;
            item.value = 230000;
            item.rare = 7;
            item.UseSound = SoundID.Item41;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("Laser");
            item.shootSpeed = 14f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("StarBlast"));
            recipe.AddIngredient(ItemID.LaserMachinegun);
            recipe.AddIngredient(ItemID.ChainGun);
            recipe.AddIngredient(ItemID.FragmentNebula, 15);
            recipe.AddIngredient(ItemID.LunarBar, 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(3, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 55f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;

        }
    }
}