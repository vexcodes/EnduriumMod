using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class ElderBullet : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 50;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 1;
            projectile.aiStyle = 1;
            aiType = 1;
            Main.projFrames[projectile.type] = 6;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elder Bullet");
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int num11 = Main.rand.Next(1, 3);
            for (int j = 0; j < num11; j++)
            {
                Vector2 vector = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                vector += projectile.velocity * 3f;
                vector.Normalize();
                vector *= (float)Main.rand.Next(35, 39) * 0.1f;
                int num12 = (int)((double)projectile.damage * 0.5);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector.X, vector.Y, mod.ProjectileType("ElderEnergyB"), num12, projectile.knockBack * 0.2f, projectile.owner, 0f, 0f);
            }
            target.AddBuff(mod.BuffType("ReaperNature"), 100);
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10, projectile.position);
        }
        public override void AI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > 3)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 2)
            {
                projectile.frame = 0;
            }
        }
    }
}
	
