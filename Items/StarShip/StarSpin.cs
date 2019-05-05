using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.StarShip
{
    public class StarSpin : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 120;
            item.melee = true;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 5;
            item.channel = true;
            item.knockBack = 3f;
            item.value = Terraria.Item.sellPrice(0, 2, 25, 0);
            item.rare = -12;
			item.expert = true;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("StarSpin");
            item.noUseGraphic = true;
            item.noMelee = true;
            item.UseSound = SoundID.Item1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Spin");
            Tooltip.SetDefault("'It shall rain from the skies'");
        }
    }
}
