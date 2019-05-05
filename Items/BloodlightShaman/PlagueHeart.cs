using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.BloodlightShaman
{
    public class PlagueHeart : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 24;
            item.melee = true;
            item.useTime = 40;
            item.useAnimation = 40;
            item.useStyle = 5;
            item.channel = true;
            item.knockBack = 3f;
            item.value = Terraria.Item.sellPrice(0, 2, 25, 0);
            item.rare = -12;
			item.expert = true;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("PlagueHeart");
            item.noUseGraphic = true;
            item.noMelee = true;
            item.UseSound = SoundID.Item1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plague Heart");
            Tooltip.SetDefault("Infects the enemy");
        }
    }
}
