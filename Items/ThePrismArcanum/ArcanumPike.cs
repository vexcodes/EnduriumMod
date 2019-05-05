using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.ThePrismArcanum
{
    public class ArcanumPike : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 37;
            item.melee = true;
            item.width = 68;
            item.height = 68;
            item.maxStack = 1;
            item.useTime = 31;
            item.useAnimation = 31;
            item.knockBack = 4f;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTurn = true;
            item.useStyle = 5;
            item.value = Item.sellPrice(0, 15, 25, 0);
            item.rare = 6;
            item.shoot = mod.ProjectileType("ArcanumPike");
            item.shootSpeed = 10f;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arcanum Pike");
            Tooltip.SetDefault("");
        }
    }
}
		