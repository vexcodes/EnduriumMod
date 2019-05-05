using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Buffs
{
    public class BloomlightBuffRanged : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Bloomlight Archer");
            Description.SetDefault("Increases ranged damage");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.rangedDamage += 0.05f;
        }
    }
}