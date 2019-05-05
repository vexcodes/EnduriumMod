using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class RainbowRailgun : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 140;
            item.ranged = true;
            item.width = 78;
            item.height = 34;
            item.useTime = 6;
            item.crit = 40;
            item.useAnimation = 6;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 4f;
            item.value = 1000000;
            item.rare = -12;
            item.UseSound = SoundID.Item67;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("rainbowsliper");  //This defines what type of projectile this weapon will shoot  
            item.shootSpeed = 20f;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8, 0);
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rainbow Railgun");
            Tooltip.SetDefault("Releases voltage of rainbow energy");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 90f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;
        }
    }
}