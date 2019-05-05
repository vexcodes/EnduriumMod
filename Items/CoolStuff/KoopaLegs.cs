using System.Collections.Generic;
using Terraria.ModLoader;

namespace EnduriumMod.Items.CoolStuff
{
    [AutoloadEquip(EquipType.Legs)]
    public class KoopaLegs : ModItem
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
      DisplayName.SetDefault("Koopa Leggings");
            Tooltip.SetDefault("Great for impersonating Big Endurium Supporters!");
        }

    }
}
