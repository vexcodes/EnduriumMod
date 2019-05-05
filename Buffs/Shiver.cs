using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EnduriumMod.NPCs;

namespace EnduriumMod.Buffs
{
    public class Shiver : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Shiver");
            Description.SetDefault("Your soul is being torn apart");
			            Main.debuff[Type] = true;   //Tells the game if this is a buf or not.
            Main.pvpBuff[Type] = true;  //Tells the game if pvp buff or not. 
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen = -24;
			player.moveSpeed *= 0.8f;
        }
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<EnduriumModGlobalNPC>(mod).Shiver = true;
		}
    }
}