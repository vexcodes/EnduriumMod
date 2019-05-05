using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class AcidDouser : ModItem
    {
        public override void SetDefaults()
        {

            item.useStyle = 5;
            item.useAnimation = 20;
            item.useTime = 20;
            item.shootSpeed = 20f;
            item.knockBack = 2f;
            item.width = 20;
            item.height = 12;
            item.damage = 46;
            item.rare = 10;
            item.value = Item.sellPrice(0, 25, 0, 0);
            item.noMelee = true;
            item.noUseGraphic = true;
            item.ranged = true;
            item.channel = true;
            item.shoot = mod.ProjectileType("AcidDouser");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Acid Douser");
            Tooltip.SetDefault("Fires bolts of pure acid\nInflicts Venom\nDoesn't consume ammo");
        }
    }
}
