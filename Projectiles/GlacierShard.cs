using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class GlacierShard : ModProjectile
    {
		public int pleaseworkbastard = 0;
		public override void SetDefaults()
        {
            projectile.extraUpdates = 0;

            projectile.width = 14;
            projectile.height = 26;      
            projectile.aiStyle = 1; 
            projectile.friendly = true;  
			Main.projFrames[projectile.type] = 5;
            projectile.penetrate = 1; 
            projectile.ranged = true;      
        }
		public override void AI()
		{
			if (pleaseworkbastard == 0)
			{
				pleaseworkbastard += 1;
				projectile.frame = Main.rand.Next(5);
			}
		}
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Shard");
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int num621 = 0; num621 < 6; num621++)
            {
                int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 156, 0f, 0f, 100, default(Color), 0.7f);
                Main.dust[num622].velocity *= 2f;
            }
        }
	}
}
