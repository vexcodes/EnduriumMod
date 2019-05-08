using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Buffs
{
    public class SpiritEnergy : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Spirit Energy");
            Description.SetDefault("Increases damage");
            Main.debuff[Type] = false;   //Tells the game if this is a buf or not.
            Main.pvpBuff[Type] = true;  //Tells the game if pvp buff or not. 
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.thrownDamage += 0.1f;
            player.meleeDamage += 0.1f;
            player.magicDamage += 0.1f;
            player.rangedDamage += 0.1f;
            player.minionDamage += 0.1f;
        }
    }
}