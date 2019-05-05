using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Buffs
{
    public class Eye : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Bloodlight Eye");
            Description.SetDefault("The spiritual amalgamation surrounds you");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;

        }


        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(mod, "MyPlayer");
            if (player.ownedProjectileCounts[mod.ProjectileType("EyeMinion")] > 0)
            {
                modPlayer.Eye = true;
            }
            if (!modPlayer.Eye)
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