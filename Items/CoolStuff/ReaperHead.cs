using System.Collections.Generic;
using Terraria.ModLoader;

namespace EnduriumMod.Items.CoolStuff
{
    [AutoloadEquip(EquipType.Head)]
    public class ReaperHead : ModItem
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
      DisplayName.SetDefault("Kitty's Hood");
      Tooltip.SetDefault("Great for impersonating... cats?");
    }


        public override bool DrawHead()
        {
            return true;
        }
    }
}
