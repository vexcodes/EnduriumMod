using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class Shadegasm : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadegasm");
        }
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.aiStyle = 1;
            projectile.penetrate = 1;
            projectile.timeLeft /= 2;
            projectile.ranged = true;
        }

        public override void AI()
        {
            projectile.velocity.X *= 1.04f;
            projectile.velocity.Y *= 1.04f;

            projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;
            float num94 = projectile.velocity.X / 3f;
            float num95 = projectile.velocity.Y / 3f;
            int num96 = 4;
            int num97 = Dust.NewDust(new Vector2(projectile.position.X + (float)num96, projectile.position.Y + (float)num96), projectile.width - num96 * 2, projectile.height - num96 * 2, mod.DustType("Shadegasm"), 0f, 0f, 0, default(Color), 1f);
            Main.dust[num97].noGravity = true;
            Dust dust3 = Main.dust[num97];
            dust3.velocity *= 0.1f;
            dust3 = Main.dust[num97];
            dust3.velocity += projectile.velocity * 0.1f;
            Dust dust6 = Main.dust[num97];
            dust6.position.X = dust6.position.X - num94;
            Dust dust7 = Main.dust[num97];
            dust7.position.Y = dust7.position.Y - num95;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //If collide with tile, reduce the penetrate.
            //So the projectile can reflect at most 5 times
            projectile.penetrate--;
            projectile.velocity.Y += 2f;
            if (projectile.penetrate <= 0)
            {
                projectile.Kill();
            }
            else
            {
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
                Main.PlaySound(SoundID.Item10, projectile.position);
            }
            return false;
        }
    }
}