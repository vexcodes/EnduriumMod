using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Buffs
{
    public class FlamerainCooldown : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Flamerain Cooldown");
            Description.SetDefault("You cant cast the flamerain");
        }
    }
}