using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.ForestChest
{
    public class LeafStorm : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 14;
            item.magic = true;
            item.mana = 14;
            item.width = 28;
            item.height = 30;
		 	item.useAnimation = 12;
			item.useTime = 6;
			item.reuseDelay = 50;
            item.useStyle = 5;


            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 6.25f;
            item.value = 15000;
            item.rare = 5;
            item.UseSound = SoundID.Item72;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("LeafStorm");
            item.shootSpeed = 12f;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Leaf Storm");
            Tooltip.SetDefault("Casts a barrage of leafs");
        }
    }
}