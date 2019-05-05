using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.HollowWarlock
{
    public class FrostSlash : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 52;
            item.thrown = true;
            item.noMelee = false;
            item.width = 14;
            item.height = 36;
            item.useTime = 4;
            item.crit = 49;
            item.useAnimation = 4;
            item.useStyle = 1;
            item.knockBack = 9;
            item.value = Terraria.Item.buyPrice(0, 8, 0, 0);
            item.rare = 8;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("FrostSlash");
            item.shootSpeed = 16f;
            item.useTurn = true;
            item.consumable = false;
            item.noUseGraphic = true;

        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frost Slash");
            Tooltip.SetDefault("'Chilled'");
        }
    }
}
