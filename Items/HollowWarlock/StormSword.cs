using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.HollowWarlock
{
    public class StormSword : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 180;
            item.melee = true;
            item.width = 70;
            item.height = 74;
            item.useTime = 38;
            item.useAnimation = 38;
            item.useStyle = 1;

            item.knockBack = 1;
            item.value = 1500000;
            item.rare = 8;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("RoyalBlade");
            item.shootSpeed = 16f;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Storm Sword");
            Tooltip.SetDefault("'Cut through foes with the power of lightning'");
        }
    }
}