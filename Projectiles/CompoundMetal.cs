using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class CompoundMetal : ModProjectile
    {
		public int pleaseworkbastard = 0;
		public override void SetDefaults()
        {
            projectile.extraUpdates = 0;

            projectile.width = 18;
            projectile.height = 18;      
            projectile.aiStyle = 99; 
            projectile.friendly = true;  
			Main.projFrames[projectile.type] = 8;
            projectile.penetrate = 5; 
            projectile.melee = true;      
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 12.5f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 300f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 20f;
        }
		public override void AI()
		{
			
			if (pleaseworkbastard == 0)
			{
				pleaseworkbastard += 1;
				projectile.frame = Main.rand.Next(8);
			}
		}
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Metal Compound");
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int num621 = 0; num621 < 15; num621++)
            {
                int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 89, 0f, 0f, 95, default(Color), 1f);
                Main.dust[num622].velocity *= 2f;
            }
        }
		public class CompoundMetal1 : ModProjectile
		{
			public int pleaseworkbastard = 0;
			public override void SetDefaults()
			{
				projectile.extraUpdates = 0;

				projectile.width = 18;
				projectile.height = 18;
				projectile.aiStyle = 99;
				projectile.friendly = true;
				Main.projFrames[projectile.type] = 8;
				projectile.penetrate = 5;
				projectile.melee = true;
				ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 5.5f;
				ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 340f;
				ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 16f;
			}
			public override void AI()
			{

				if (pleaseworkbastard == 0)
				{
					pleaseworkbastard += 1;
					projectile.frame = Main.rand.Next(8);
				}
			}
			public override void SetStaticDefaults()
			{
				DisplayName.SetDefault("Metal Compound");
			}
			public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
			{
				for (int num621 = 0; num621 < 15; num621++)
				{
					int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 89, 0f, 0f, 95, default(Color), 1f);
					Main.dust[num622].velocity *= 2f;
				}
			}
		}
		public class CompoundMetal2 : ModProjectile
		{
			public int pleaseworkbastard = 0;
			public override void SetDefaults()
			{
				projectile.extraUpdates = 0;

				projectile.width = 18;
				projectile.height = 18;
				projectile.aiStyle = 99;
				projectile.friendly = true;
				Main.projFrames[projectile.type] = 8;
				projectile.penetrate = 5;
				projectile.melee = true;
				ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 8.5f;
				ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 380f;
				ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 12f;
			}
			public override void AI()
			{

				if (pleaseworkbastard == 0)
				{
					pleaseworkbastard += 1;
					projectile.frame = Main.rand.Next(8);
				}
			}
			public override void SetStaticDefaults()
			{
				DisplayName.SetDefault("Metal Compound");
			}
			public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
			{
				for (int num621 = 0; num621 < 15; num621++)
				{
					int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 89, 0f, 0f, 95, default(Color), 1f);
					Main.dust[num622].velocity *= 2f;
				}
			}
		}
	}
}
