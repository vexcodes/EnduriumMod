using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.EarthElemental
{
	public class ThePlague : ModItem
	{
        public override void SetDefaults()
        {

            item.damage = 38;
            item.melee = true;  
            item.useTime = 54;  
            item.useAnimation = 54; 
            item.useStyle = 5;
            item.channel = true;
            item.knockBack = 5f;
            item.value = Terraria.Item.sellPrice(0, 10, 25, 0);
            item.rare = 8;
            item.autoReuse = false;  
            item.shoot = mod.ProjectileType("ThePlague");   
            item.noUseGraphic = true; 
            item.noMelee = true;
            item.UseSound = SoundID.Item1; 
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Plague Verdant");
            Tooltip.SetDefault("");
        }
    }
}
