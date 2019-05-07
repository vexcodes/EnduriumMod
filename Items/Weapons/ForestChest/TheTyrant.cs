using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.ForestChest
{
    public class TheTyrant : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 80;
            item.width = 52;  //The width of the .png file in pixels divided by 2.
            item.noMelee = true;  //Dictates whether this is a melee-class weapon.
            item.noUseGraphic = true;
            item.autoReuse = false;
            item.useAnimation = 24;
            item.useStyle = 1;
            item.useTime = 24;
            item.knockBack = 25f;  //Ranges from 1 to 9.
            item.UseSound = SoundID.Item1;
            item.thrown = true;  //Dictates whether the weapon can be "auto-fired".
            item.height = 52;  //The height of the .png file in pixels divided by 2.
            item.value = 900000;  //Value is calculated in copper coins.
            item.rare = 10;  //Ranges from 1 to 11.
            item.shoot = mod.ProjectileType("TheTyrant");
            item.shootSpeed = 24f;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Tyrant");
            Tooltip.SetDefault("'The power of the tyrant is sealed withing'\nCritical strikes will cause explosions");
        }
        public override bool CanUseItem(Player player)
        {
            return false;
        }
    }
}