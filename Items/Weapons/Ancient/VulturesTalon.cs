using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.DataStructures;
using System.Collections.Generic;

namespace EnduriumMod.Items.Weapons.Ancient
{
    public class VulturesTalon : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 10;
            item.crit += 2;
            item.ranged = true;
            item.width = 22;
            item.height = 44;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 7;
            item.UseSound = SoundID.Item5;
            item.value = 900000;
            item.rare = 1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("DesertPierce");
            item.shootSpeed = 20f;
            item.useAmmo = 40;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vultures Talon");
            Tooltip.SetDefault("Fires a desert arrow every third shot");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("AncientMandible"), 9);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        int sket = 0;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            sket += 1;
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 10f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            if (sket >= 3)
            {
                sket = 0;
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(7));
                Projectile.NewProjectile(position.X, position.Y, (int)(perturbedSpeed.X *= 1.2f), (int)(perturbedSpeed.Y *= 1.2f), mod.ProjectileType("DesertPierce"), damage, knockBack, player.whoAmI);
                return false;
            }
            return true; // return false because we don't want tmodloader to shoot projectile
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4, 0);
        }
    }
}