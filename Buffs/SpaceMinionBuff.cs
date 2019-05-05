using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Buffs
{
    public class SpaceMinionBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("U.F.O");
            Description.SetDefault("The alien creature will fight for you");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;

        }


        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(mod, "MyPlayer");
            if (player.ownedProjectileCounts[mod.ProjectileType("SpaceMinion")] > 0)
            {
                modPlayer.SpaceMinionBuff = true;
            }
            if (!modPlayer.SpaceMinionBuff)
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