using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class PrismaticWarhammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prismatic Warhammer");
        }

        public override void SetDefaults()
        {
            item.width = 66;  //The width of the .png file in pixels divided by 2.
            item.damage = 82;  //Keep this reasonable please.
            item.noMelee = true;  //Dictates whether this is a melee-class weapon.
            item.noUseGraphic = true;
            item.autoReuse = true;
            item.useAnimation = 32;
            item.useStyle = 1;
            item.crit += 20;
            item.useTime = 32;
            item.knockBack = 4f;  //Ranges from 1 to 9.
            item.UseSound = SoundID.Item1;
            item.thrown = true;  //Dictates whether the weapon can be "auto-fired".
            item.height = 50;  //The height of the .png file in pixels divided by 2.
            item.value = 123123;  //Value is calculated in copper coins.
            item.rare = 7;  //Ranges from 1 to 11.
            item.shoot = mod.ProjectileType("PrismaticWarhammer");
            item.shootSpeed = 20f;
        }
    }
}
