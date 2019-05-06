using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class BloodyBeam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vampire Beam");
        }
        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 26;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 200;
            projectile.alpha = 225;
            projectile.light = 0.0f;
            projectile.aiStyle = 27;
            projectile.extraUpdates = 2;
            projectile.ignoreWater = true;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D glowmask = Main.projectileTexture[projectile.type];
            int glownum = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
            int y7 = glownum * projectile.frame;
            Main.spriteBatch.Draw(glowmask, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y7, glowmask.Width, glownum)), projectile.GetAlpha(Color.White), projectile.rotation, new Vector2((float)glowmask.Width / 2f, (float)glownum / 2f), projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            if (Main.rand.Next(3) == 0)
            {
                int healAmount = (Main.rand.Next(1, 3));
                player.statLife += healAmount;
                player.HealEffect(healAmount);
            }
            float numberProjectiles = 3;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Projectile.NewProjectile((player.position.X + player.width / 2) + (Main.rand.Next(-150, 151)), (player.position.Y + player.height / 2) + (Main.rand.Next(-150, 151)), 0f, 0f, mod.ProjectileType("TrueBloodyBeam2"), (int)((double)projectile.damage * 0.5f), projectile.knockBack, projectile.owner);
            }
        }
    }
}
				