using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class TheWildBlade : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 20;
            item.thrown = true;
            item.noMelee = true;
            item.width = 14;
            item.height = 36;
            item.useTime = 40;
            item.crit = 25;
            item.useAnimation = 40;
            item.useStyle = 1;
            item.knockBack = 9;
            item.value = Terraria.Item.buyPrice(0, 10, 0, 0);
            item.rare = 6;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("TheWildBlade");
            item.shootSpeed = 16f;
            item.useTurn = true;
            item.consumable = false;
            item.noUseGraphic = true;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Wild Blade");
            Tooltip.SetDefault("'Dance with the blades'");
        }
    }
}
