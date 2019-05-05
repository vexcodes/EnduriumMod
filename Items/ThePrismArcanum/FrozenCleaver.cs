using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.ThePrismArcanum
{
    public class FrozenCleaver : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 10;
            item.thrown = true;
            item.noMelee = false;
            item.width = 32;
            item.height = 38;
            item.useTime = 12;
            item.crit = 37;
            item.useAnimation = 12;
            item.useStyle = 1;
            item.knockBack = 9;
            item.value = Terraria.Item.buyPrice(0, 12, 6, 0);
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("FrozenCleaver");
            item.shootSpeed = 12f;
            item.useTurn = true;
            item.noUseGraphic = true;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frozen Cleaver");
            Tooltip.SetDefault("");
        }
    }
}
