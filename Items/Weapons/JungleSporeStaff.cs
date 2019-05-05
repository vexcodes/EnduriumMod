using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class JungleSporeStaff : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 19;
            item.magic = true;
            item.mana = 10;
            item.width = 46;
            item.height = 46;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = 5;
            Item.staff[item.type] = true;


            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 7.25f;
            item.value = 10000;
            item.rare = 5;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("PoisonBolt");
            item.shootSpeed = 9f;
        }
		        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tropical Spore Staff");
            Tooltip.SetDefault("'The tropical paradise'");
        }
    }
}