using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Buffs
{
    public class BloodConsumption : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Blood Coagalant");
            Description.SetDefault("'Tastes soo good!'");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen += 15;
        }
    }
}