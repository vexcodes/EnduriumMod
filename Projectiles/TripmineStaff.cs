using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class TripmineStaff : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.timeLeft = 200;
            projectile.tileCollide = false;
            projectile.alpha = 90;
            projectile.penetrate = 1;
            projectile.aiStyle = 1;
            aiType = 1;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Main.PlaySound(3, (int)projectile.position.X, (int)projectile.position.Y, 1, 1f, 0f);
            int num3;
            
            if (projectile.owner == Main.myPlayer)
            {
                int num626 = 2;
                if (Main.rand.Next(10) == 0)
                {
                    num3 = num626;
                    num626 = num3 + 1;
                }
                if (Main.rand.Next(10) == 0)
                {
                    num3 = num626;
                    num626 = num3 + 1;
                }
                if (Main.rand.Next(10) == 0)
                {
                    num3 = num626;
                    num626 = num3 + 1;
                }
                for (int num627 = 0; num627 < num626; num627 = num3 + 5)
                {
                    float num628 = (float)Main.rand.Next(-35, 36) * 0.02f;
                    float num629 = (float)Main.rand.Next(-35, 36) * 0.02f;
                    num628 *= 20f;
                    num629 *= 20f;
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, num628, num629, mod.ProjectileType("TripmineExplosion"), (int)((double)projectile.damage * 0.75), (float)((int)((double)projectile.knockBack * 0.35)), Main.myPlayer, 0f, 0f);
                    num3 = num627;
                }
            }
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tripmine");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            //Redraw the projectile with the color not influenced by light
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
        public override void AI()
        {
            projectile.velocity.X *= 0.99f;
            projectile.velocity.Y *= 0.99f;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 60);

            for (int num621 = 0; num621 < 5; num621++)
            {
                int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 133, 0f, 0f, 156, default(Color), 1.2f);
                Main.dust[num622].velocity *= 3f;
            }
        }
    }
}