using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Buffs
{
    public class PoseidonsGuard : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Sea Guardian");
            Description.SetDefault("The best guard of poseidon's tribe is with you");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;

        }


        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(mod, "MyPlayer");
            if (player.ownedProjectileCounts[mod.ProjectileType("PoseidonsGuard")] > 0)
            {
                modPlayer.PoseidonsGuard = true;
            }
            if (!modPlayer.PoseidonsGuard)
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