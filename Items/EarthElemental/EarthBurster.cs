using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace EnduriumMod.Items.EarthElemental
{
    public class EarthBurster : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 18;
            item.ranged = true;
            item.width = 42;
            item.height = 26;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 1;
            item.value = Terraria.Item.buyPrice(0, 10, 30, 0);
            item.rare = 6;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 17f;
            item.useAmmo = AmmoID.Bullet;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Earth Gatling Gun");
            Tooltip.SetDefault("");
        }
    }
}