using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Acid
{
    public class AcidBane : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 60;
            item.ranged = true;
            item.width = 30;
            item.height = 62;
            item.useTime = 19;

            item.useAnimation = 19;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 4f;
            item.value = 125000;
            item.rare = 8;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = 19; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 20f;
            item.useAmmo = 40;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4, 0);
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Acid Bane");
            Tooltip.SetDefault("Sometimes Turns arrows into acid arrows");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 10f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(4));
            Projectile.NewProjectile(position.X, position.Y, (int)(perturbedSpeed.X *= 0.7f), (int)(perturbedSpeed.Y *= 0.7f), mod.ProjectileType("AccretionArrow"), damage, knockBack, player.whoAmI);
            return true; // return false because we don't want tmodloader to shoot projectile
        }
    }
}
