using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class ElderArrow : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 3;
            projectile.aiStyle = 1;
            aiType = 1;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elder Arrow");
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10, projectile.position);
        }
        public override void AI()
        {

            projectile.localAI[0] += 1f;
            if (projectile.localAI[0] > 3f)
            {
                projectile.localAI[0] = 0f;
                if (projectile.owner == Main.myPlayer)
                {
                    int num414 = (int)(projectile.position.X + (float)Main.rand.Next(projectile.width));
                    int num415 = (int)(projectile.position.Y + (float)projectile.height);
                    Projectile.NewProjectile((float)num414, (float)num415, 0f, 0f, mod.ProjectileType("ElderEnergy"), projectile.damage - 30, 0f, projectile.owner, 0f, 0f);
                }
            }

        }
    }
}