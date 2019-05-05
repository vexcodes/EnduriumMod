using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.TheScourge
{
    public class JungleHatchet : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 80;
            item.thrown = true;
            item.noMelee = true;
            item.width = 14;
            item.height = 36;
            item.useTime = 28;
            item.crit = 10;
            item.useAnimation = 28;
            item.useStyle = 1;
            item.knockBack = 9;
            item.value = Terraria.Item.buyPrice(0, 2, 10, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("JungleHatchet");
            item.shootSpeed = 10f;
            item.useTurn = true;
            item.consumable = false;
            item.noUseGraphic = true;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Hatchet");
            Tooltip.SetDefault("Splits into 4 thorns\nInflicts nature terror");
        }
    }
}
