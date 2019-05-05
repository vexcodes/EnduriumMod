using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Buffs
{

    public class EyeofTheStorm : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Storm Essence");
            Description.SetDefault("Unknown Power");
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("EyeofTheStorm")] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("EyeofTheStorm"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}