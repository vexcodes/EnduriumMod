using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.TheScourge
{
    public class TheScourge : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 100;

            item.melee = true;
            item.width = 52;
            item.height = 52;
            item.maxStack = 1;
            item.useTime = 30;
            item.useAnimation = 30;
            item.knockBack = 2f;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTurn = true;
            item.useStyle = 5;
            item.value = Item.sellPrice(0, 25, 25, 0);
            item.rare = 8;
            item.shoot = mod.ProjectileType("TheScourge");
            item.shootSpeed = 12f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Scourge");
            Tooltip.SetDefault("'A powerfull reaper roaming around the jungle, harvesting souls'");
        }
    }
}
