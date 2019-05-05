using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Buffs
{
    public class BloomingLife : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Blooming Life");
            Description.SetDefault("Blooming Nature");
        }
        public override void Update(Player player, ref int buffIndex)
        {
			                player.lifeRegen += 120;
        }
    }
}