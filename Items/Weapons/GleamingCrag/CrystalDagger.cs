using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.GleamingCrag
{
    public class CrystalDagger : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 46;
            item.thrown = true;
            item.noMelee = true;
            item.width = 14;
            item.height = 36;
            item.useTime = 16;
            item.crit = 30;
            item.useAnimation = 16;
            item.useStyle = 1;
            item.knockBack = 2;
            item.value = Terraria.Item.buyPrice(0, 0, 10, 0);
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("CrystalDagger");
            item.shootSpeed = 13f;
            item.useTurn = true;
            item.maxStack = 999;
            item.consumable = true;
            item.noUseGraphic = true;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Devine Dagger");
            Tooltip.SetDefault("Hitting tiles creates energy");
        }
    }
}
