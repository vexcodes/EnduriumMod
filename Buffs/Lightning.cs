using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Buffs
{
    public class Lightning : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Lightning");
            Description.SetDefault("Be the one! Run like the wind!");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed += 0.25f;
            player.accRunSpeed += 1f;
        }
    }
}