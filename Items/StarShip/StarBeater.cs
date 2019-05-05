using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.StarShip
{
    public class StarBeater : ModItem
    {
        public override void SetDefaults()
        {

            item.useStyle = 5;
            item.useAnimation = 20;
            item.useTime = 20;
            item.shootSpeed = 20f;
            item.knockBack = 2f;
            item.width = 76;
            item.height = 28;
            item.damage = 142;
            item.rare = 10;
            item.value = Item.sellPrice(1, 0, 0, 0);
            item.noMelee = true;
            item.autoReuse = true;
            item.UseSound = SoundID.Item82;
            item.ranged = true;
            item.shoot = mod.ProjectileType("SnowballFurious");
            item.shootSpeed = 4f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 60f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Planet Stormer");
            Tooltip.SetDefault("Fires bolts of pure lightning");
        }
    }
}