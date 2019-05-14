using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class LightningScepter : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 40;
            item.magic = true;
            item.width = 62;
            item.height = 26;
            item.useTime = 6;
            item.mana = 4;
            item.useAnimation = 6;
            item.useStyle = 5;
            Item.staff[item.type] = true;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 8f;
            item.value = 125000;
            item.rare = 8;
            //item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("ZAP");
            item.shootSpeed = 10f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lightning Scepter");
            Tooltip.SetDefault("'ZAP'");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 95f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(16));
            Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);

            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 25);
            recipe.AddIngredient(null, ("StarCrystal"), 6);
            recipe.AddIngredient(ItemID.SoulofSight, 25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}