using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EnduriumMod.NPCs;

namespace EnduriumMod.Buffs
{
    public class HeartOfNatureCooldown : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Revive cooldown");
            Description.SetDefault("Taking lethal damage will result in dying");
			            Main.debuff[Type] = true;   //Tells the game if this is a buf or not.
            Main.pvpBuff[Type] = true;  //Tells the game if pvp buff or not. 
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MyPlayer>(mod).HeartOfTheForestCooldown = true;
        }
    }
}