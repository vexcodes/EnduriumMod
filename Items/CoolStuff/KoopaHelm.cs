using System.Collections.Generic;
using Terraria.ModLoader;

namespace EnduriumMod.Items.CoolStuff
{
    [AutoloadEquip(EquipType.Head)]
    public class KoopaHelm : ModItem
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
            DisplayName.SetDefault("Koopa Helmet");
            Tooltip.SetDefault("Great for impersonating Big Endurium Supporters!");
        }
    }
}
