using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.DragonWarrior.Shop
{
    public class TheDragun : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 80;
            item.melee = true;
            item.useTime = 40;
            item.useAnimation = 40;
            item.useStyle = 5;
            item.channel = true;
            item.knockBack = 5f;
            item.value = Terraria.Item.sellPrice(0, 25, 0, 0);
            item.rare = 9;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("TheDragun");
            item.noUseGraphic = true;
            item.noMelee = true;
            item.UseSound = SoundID.Item1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Dragon");
            Tooltip.SetDefault("Fires flame shells at nearby enemies");
        }
    }
}
