using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace EnduriumMod.Items.Weapons.Permarine
{
    public class AstralValediciton : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 132;
            item.crit += 13;
            item.magic = true;
            item.mana = 8;
            item.width = 72;
            item.height = 84;
            item.useTime = 11;
            item.useAnimation = 11;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = 900000;
            item.rare = 11;
            item.UseSound = SoundID.Item15;
            Item.staff[item.type] = true;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("GammaBolt");
            item.shootSpeed = 12f;
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
            DisplayName.SetDefault("Astral Valediciton");
            Tooltip.SetDefault("'The endless fire will burn your soul'");
        }
    }
}