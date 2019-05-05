﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Buffs
{
    public class Overgrowth3 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Overgrowth Defense");
            Description.SetDefault("Bonus Endurance");
            Main.debuff[Type] = false;   //Tells the game if this is a buf or not.
            Main.pvpBuff[Type] = true;  //Tells the game if pvp buff or not. 
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MyPlayer>(mod).Overgrowth3 = true;
        }
    }
}