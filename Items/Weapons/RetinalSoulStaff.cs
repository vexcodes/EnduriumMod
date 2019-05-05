using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class RetinalSoulStaff : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 90;
            item.magic = true;
            item.width = 62;
            item.height = 26;
            item.useTime = 25;
            item.mana = 5;
            item.useAnimation = 25;
            item.useStyle = 5;
            Item.staff[item.type] = true;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 8f;
            item.value = 125000;
            item.rare = 8;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("RetinalSoulStaff1");
            item.shootSpeed = 9f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Retinal Soul Staff");
            Tooltip.SetDefault("Fires both ichor and cursed inferno");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 95f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("RetinalSoulStaff2"), damage, knockBack, player.whoAmI, 0f, 0f);
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("RetinalSoulStaff1"), damage, knockBack, player.whoAmI, 0f, 0f);
            }

            return false; //Makes sure to not fire the original projectile
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 20);
            recipe.AddIngredient(null, ("StarCrystal"), 4);
            recipe.AddIngredient(ItemID.SoulofSight, 25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}