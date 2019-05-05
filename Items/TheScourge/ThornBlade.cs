using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.TheScourge
{
    public class ThornBlade : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 140;
            item.melee = true;
            item.width = 50;
            item.height = 50;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 1;

            item.knockBack = 1;
            item.value = 15000;
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("ThornBlade");
            item.shootSpeed = 12f;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thorn Blade");
            Tooltip.SetDefault("Shoots a piercing blade\nInflicts nature terror");
        }
    }
}