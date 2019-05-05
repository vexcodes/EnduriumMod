using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Buffs
{
    public class HeavyArmor : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Heavy Armor");
            Description.SetDefault("'Hard'");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.endurance += 0.1f;
					player.accRunSpeed -= 0.75f;
		player.rocketBoots -= 1;
		player.moveSpeed -= 0.25f;
		player.lavaMax += 420;
		player.wingTimeMax -= 10;
        }
    }
}