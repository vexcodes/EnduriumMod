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
    public class Aquarius : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;
            projectile.CloneDefaults(ProjectileID.TheEyeOfCthulhu);
            projectile.width = 12;
            projectile.height = 12;
            projectile.aiStyle = 99;
            projectile.friendly = true;
            projectile.scale = 1f;
            projectile.penetrate = -1;
            projectile.melee = true;
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 10f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 380f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 16f;
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
            DisplayName.SetDefault("Aquarius");
        }
        public override void AI()
        {
            projectile.localAI[0] += 1f;
            if (projectile.localAI[0] > 16f)
            {
                projectile.localAI[0] = 0f;
                if (projectile.owner == Main.myPlayer)
                {
                    int num414 = (int)(projectile.position.X + (float)Main.rand.Next(projectile.width - 6));
                    int num415 = (int)(projectile.position.Y + (float)projectile.height + 6);
                    Projectile.NewProjectile((float)num414, (float)num415, 0f, 0f, mod.ProjectileType("SomeRainyBoi"), projectile.damage, 0f, projectile.owner, 0f, 0f);
                }
            }
        }
    }
}