using System.Collections.Generic;
using Terraria.ModLoader;

namespace EnduriumMod.Items.CoolStuff
{
    [AutoloadEquip(EquipType.Body)]
    public class ReaperBody : ModItem
    {
        public override void SetDefaults()
        {



            item.width = 28;
            item.height = 20;
            item.rare = 1;
            item.vanity = true;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Kitty's Chainplate");
      Tooltip.SetDefault("Great for impersonating... cats?");
    }

    }
}
