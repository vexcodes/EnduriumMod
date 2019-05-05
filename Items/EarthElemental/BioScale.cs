using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.EarthElemental
{
    public class BioScale : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 32;
            item.height = 32;
            item.maxStack = 20;

            item.rare = 4;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Scale of Earth");
      Tooltip.SetDefault("'Imbued with unknown power'");
    }
    }
}
