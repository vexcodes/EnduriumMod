using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class ThunderStrike : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 42;
            item.thrown = true;
            item.noMelee = true;
            item.width = 14;
            item.height = 36;
            item.useTime = 29;
            item.crit = 20;
            item.useAnimation = 29;
            item.useStyle = 1;
            item.knockBack = 9;
            item.value = Terraria.Item.buyPrice(0, 5, 0, 0);
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("ThunderStrike");
            item.shootSpeed = 8f;
            item.useTurn = true;
            item.maxStack = 1;
            item.consumable = false;
            item.noUseGraphic = true;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thunder Strike");
            Tooltip.SetDefault("The lesser your health the faster you throw the weapon\nExplodes on contact");
        }
    }
}
