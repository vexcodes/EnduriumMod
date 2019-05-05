using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.DragonWarrior.Shop
{
    public class DragonGreatblade : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 90;
            item.melee = true;
            item.width = 46;
            item.height = 46;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = 1;

            item.knockBack = 1;
            item.value = 25000;
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("DragonGreatblade");
            item.shootSpeed = 12f;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon Greatblade");
            Tooltip.SetDefault("Creates slow moving flames");
        }
    }
}
