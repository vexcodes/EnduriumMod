using System.Collections.Generic;
using Terraria.ModLoader;

namespace EnduriumMod.Items.CoolStuff
{
    [AutoloadEquip(EquipType.Body)]
    public class QuesoBody : ModItem
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
            DisplayName.SetDefault("Queso's Breastplate");
            Tooltip.SetDefault("Great For Impersonating The Cheesiest Endurium Dev\nSpell Failed");
        }

    }
}