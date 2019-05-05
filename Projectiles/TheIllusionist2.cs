using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System.IO;

namespace EnduriumMod.Projectiles
{
    public class TheIllusionist2 : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;
            projectile.CloneDefaults(ProjectileID.TheEyeOfCthulhu);
            projectile.width = 22;
            projectile.height = 22;
            projectile.aiStyle = 99;
            projectile.friendly = true;
            projectile.scale = 0.75f;
            projectile.penetrate = 10;
            projectile.melee = true;
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 19f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 240f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 17f;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 9;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Illusionist");
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("GraniteShatter"), 360);
            for (int num621 = 0; num621 < 2; num621++)
            {
                int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 156, 0f, 0f, 95, default(Color), 1f);
                Main.dust[num622].velocity *= 2f;
                Main.dust[num622].noGravity = true;
            }
        }
    }
}