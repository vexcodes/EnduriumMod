using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.ForestChest
{
    public class Chameleon : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 12;
            item.melee = true;  
            item.useTime = 29;  
            item.useAnimation = 29; 
            item.useStyle = 5;
            item.channel = true;
            item.knockBack = 2f;
            item.value = Terraria.Item.sellPrice(0, 1, 25, 0);
            item.rare = 3;
            item.autoReuse = false;  
            item.shoot = mod.ProjectileType("Chameleon");   
            item.noUseGraphic = true; 
            item.noMelee = true;
            item.UseSound = SoundID.Item1; 
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chameleon");
            Tooltip.SetDefault("");
        }
    }
}
