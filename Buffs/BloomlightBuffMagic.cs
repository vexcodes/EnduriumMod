using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Buffs
{
    public class BloomlightBuffMagic : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Bloomlight Mage");
            Description.SetDefault("Increases magic damage");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.magicDamage += 0.05f;
        }
    }
}