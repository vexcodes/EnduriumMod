using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.CoolStuff
{
    public class QuesoBlaster : ModItem
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
												item.damage = 600;
												item.mana = 6;
												item.rare = -12;
												item.value = Item.sellPrice(10, 0, 0, 0);
												item.noMelee = true;
												item.noUseGraphic = true;
												item.magic = true;
												item.channel = true;
               item.shoot = mod.ProjectileType("QuesoBlaster");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Queso Blaster");
            Tooltip.SetDefault("'Slay your enemies with the cheesiest power of the best cheese'");
        }
    }
}
