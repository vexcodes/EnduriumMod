using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Buffs
{

    public class EarthTurret : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Earth Essence");
            Description.SetDefault("Earth Power");
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("EarthTurret")] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("EarthTurret"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}