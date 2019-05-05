using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Buffs
{
    public class Jumper : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Jumper");
            Description.SetDefault("Be the Jump Man!");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.jumpSpeedBoost += 9.5f;
        }
    }
}