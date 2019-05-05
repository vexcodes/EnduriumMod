using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.ThePrismArcanum
{
    public class TheArcticWind : ModItem
    {
	        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Arctic Wind");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {

            item.damage = 26;
            item.magic = true;
            item.mana = 10;
            item.width = 46;
            item.height = 46;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            Item.staff[item.type] = true;


            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3.25f;
            item.value = 20000;
            item.rare = 6;
            item.UseSound = SoundID.Item72;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("PrismMagic2");
            item.shootSpeed = 1f;
        }
    }
}