using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.EarthElemental
{
    public class SporeCleaver : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 38;
            item.thrown = true;
            item.noMelee = true;
            item.width = 14;
            item.height = 36;
            item.useTime = 23;
            item.crit = 10;
            item.useAnimation = 23;
            item.useStyle = 1;
            item.knockBack = 9;
            item.value = Terraria.Item.buyPrice(0, 10, 10, 0);
            item.rare = 7;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("SporeCleaver");
            item.shootSpeed = 10f;
            item.useTurn = true;
            item.consumable = false;
            item.noUseGraphic = true;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spore Cleaver");
            Tooltip.SetDefault("Splits into spore energy upon hitting an enemy");
        }
    }
}
