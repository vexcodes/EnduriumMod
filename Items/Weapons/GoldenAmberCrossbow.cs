using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class GoldenAmberCrossbow : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 24;
            item.ranged = true;
            item.width = 52;
            item.height = 32;
            item.useTime = 27;
            item.useAnimation = 27;
            item.useStyle = 5;

            item.noMelee = true;
            item.knockBack = 4;
            item.value = Terraria.Item.buyPrice(0, 10, 25, 0);
            item.rare = 4;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 10f;
            item.useAmmo = AmmoID.Arrow;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golden Amber Crossbow");
            Tooltip.SetDefault("");
        }
    }
}