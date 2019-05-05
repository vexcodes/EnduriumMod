using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Buffs
{
    public class NeoniteWazpBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Neonite Wazp");
            Description.SetDefault("'It bites'");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;

        }

        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(mod, "MyPlayer");
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("NeoniteWasp")] == 0;
            if (petProjectileNotSpawned)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("NeoniteWasp"), 0, 0f, player.whoAmI, 0f, 0f);
            }
            if (!modPlayer.NeoniteWazp)
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