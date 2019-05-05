using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EnduriumMod.NPCs;

namespace EnduriumMod.Buffs
{
    public class ReaperNature : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Reaper Nature");
            Description.SetDefault("The powers of a nature god slowly devour your insides, you can feel your skin melting");
			            Main.debuff[Type] = true;   //Tells the game if this is a buf or not.
            Main.pvpBuff[Type] = true;  //Tells the game if pvp buff or not. 
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MyPlayer>(mod).ReaperNature = true;
        }
				public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<EnduriumModGlobalNPC>(mod).NatureReaper = true;
		}
    }
}