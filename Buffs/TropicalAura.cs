using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EnduriumMod.NPCs;

namespace EnduriumMod.Buffs
{
    public class TropicalAura : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Tropical Aura");
            Description.SetDefault("Increases life regen");
			            Main.debuff[Type] = false;   //Tells the game if this is a buf or not.
            Main.pvpBuff[Type] = true;  //Tells the game if pvp buff or not. 
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MyPlayer>(mod).TropicalAura = true;
        }
    }
}