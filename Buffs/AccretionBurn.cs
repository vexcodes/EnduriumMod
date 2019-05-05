using Terraria;
using Terraria.ModLoader;
using EnduriumMod.NPCs;

namespace EnduriumMod.Buffs
{
    public class AccretionBurn : ModBuff
	{
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Accretion Burn");
            Description.SetDefault("'Decading'");
            Main.debuff[Type] = true;   //Tells the game if this is a buf or not.
            Main.pvpBuff[Type] = true;  //Tells the game if pvp buff or not. 
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<EnduriumModGlobalNPC>(mod).AccretionBurn = true;
        }
    }
}
