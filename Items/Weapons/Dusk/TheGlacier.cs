using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Dusk
{
    public class TheGlacier : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 51;
            item.thrown = true;
            item.useTime = 40;
            item.useAnimation = 40;
            item.useStyle = 5;
            item.channel = true;
            item.knockBack = 2f;
            item.value = Terraria.Item.sellPrice(0, 12, 0, 0);
            item.rare = 6;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("TheGlacier");
            item.shootSpeed = 12f;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.UseSound = SoundID.Item1;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Glacier");
            Tooltip.SetDefault("Has homing properties");
        }
    }
}