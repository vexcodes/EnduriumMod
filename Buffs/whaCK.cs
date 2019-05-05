using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EnduriumMod.NPCs;

namespace EnduriumMod.Buffs
{
    public class whACk : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Putrid Plague");
            Description.SetDefault("'A different kind of poison'");
			            Main.debuff[Type] = true;   //Tells the game if this is a buf or not.
            Main.pvpBuff[Type] = true;  //Tells the game if pvp buff or not. 
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen = -50;
        }
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<EnduriumModGlobalNPC>(mod).whaCK = true;
		}
    }
}