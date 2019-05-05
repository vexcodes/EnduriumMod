using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class GoldenAmberClaymore : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 29;
            item.melee = true;
            item.width = 46;
            item.height = 46;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 1;
            
            item.knockBack = 1;
            item.value = 150000;
            item.rare = 6;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golden Amber Blade");
            Tooltip.SetDefault("");
        }
    }
}
