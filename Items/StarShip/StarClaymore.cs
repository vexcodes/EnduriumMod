using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.StarShip
{
    public class StarClaymore : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 240;
            item.melee = true;
            item.width = 70;
            item.height = 74;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;

            item.knockBack = 1;
            item.value = 1500000;
            item.rare = 8;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("StarClaymore");
            item.shootSpeed = 16f;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Claymore");
            Tooltip.SetDefault("'An excalibur from space'\nHitting enemies with the sword greatly boosts melee speed and grants a defense boost");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            MyPlayer p = player.GetModPlayer<MyPlayer>();
            if (p.StarExcalibur >= 1f)
            {
                p.StarExcalibur -= 0.05f;
            }
            return true;
        }
    }
}