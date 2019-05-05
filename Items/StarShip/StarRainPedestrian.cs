using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.StarShip
{
    public class StarRainPedestrian : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 250;
            item.thrown = true;
            item.width = 70;
            item.height = 74;
            item.maxStack = 1;
            item.useTime = 14;
            item.useAnimation = 14;
            item.knockBack = 5f;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.autoReuse = true;
            item.useTurn = true;
            item.useStyle = 5;
            item.value = Item.sellPrice(0, 50, 25, 0);
            item.rare = 8;
            item.shoot = mod.ProjectileType("StarRainPedestrian");
            item.shootSpeed = 7f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Strike");
            Tooltip.SetDefault("");
        }
    }
}
	