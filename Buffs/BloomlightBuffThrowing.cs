using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Buffs
{
    public class BloomlightBuffThrowing : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Bloomlight Ninja");
            Description.SetDefault("Increases throwing damage");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.thrownDamage += 0.05f;
        }
    }
}