using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Buffs
{
    public class SnowflakeMinionBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("A strange Snowflake");
            Description.SetDefault("'Chilled'");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;

        }


        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(mod, "MyPlayer");
            if (player.ownedProjectileCounts[mod.ProjectileType("SnowflakeMinion")] > 0)
            {
                modPlayer.SnowflakeMinionBuff = true;
            }
            if (!modPlayer.SnowflakeMinionBuff)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else
            {
                player.buffTime[buffIndex] = 18000;
            }
        }
    }
}