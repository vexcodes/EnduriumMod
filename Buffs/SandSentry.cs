using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Buffs
{
    public class SandSentry : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("A cluster of sand");
            Description.SetDefault("It's only dirt and sand, don't expect much");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;

        }


        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(mod, "MyPlayer");
            if (player.ownedProjectileCounts[mod.ProjectileType("SandSpirit")] > 0)
            {
                modPlayer.SandSentry = true;
            }
            if (!modPlayer.SandSentry)
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