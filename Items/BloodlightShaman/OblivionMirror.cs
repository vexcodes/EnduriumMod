using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace EnduriumMod.Items.BloodlightShaman
{
    public class OblivionMirror : ModItem
    {
        public override void SetDefaults()
        {

			item.width = 38;
			item.height = 32;
			item.maxStack = 1;
			item.value = 350000;
			item.rare = 6;
			item.useAnimation = 55;
			item.useTime = 55;
			item.useStyle = 4;
			item.UseSound = SoundID.Item43;
	
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Totem");
            Tooltip.SetDefault("'The rise of undead'");
        }
		public override bool CanUseItem(Player player)
		{
			if (!Main.dayTime && !Main.bloodMoon)
			
				
				return true;
				
			return false;
			
		}

		public override bool UseItem(Player player)
		{
		Main.NewText("The smell of gore fills the air", 255, 0, 0);
			Main.bloodMoon = true;
			return true;
		}
}
}