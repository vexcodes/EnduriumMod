using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Buffs
{
    public class GraniteMinionBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Granite Cutter");
            Description.SetDefault("The sharp granite saw will fight for you.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;

        }


        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(mod, "MyPlayer");
            if (player.ownedProjectileCounts[mod.ProjectileType("GraniteCutter")] > 0)
            {
                modPlayer.GraniteMinionBuff = true;
            }
            if (!modPlayer.GraniteMinionBuff)
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