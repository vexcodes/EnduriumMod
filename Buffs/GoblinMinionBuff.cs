using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Buffs
{
    public class GoblinMinionBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Goblin Warrior");
            Description.SetDefault("The Goblin Warrior Will Protect You");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;

        }


        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(mod, "MyPlayer");
            if (player.ownedProjectileCounts[mod.ProjectileType("GoblinMinion")] > 0)
            {
                modPlayer.GoblinMinionBuff = true;
            }
            if (!modPlayer.GoblinMinionBuff)
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