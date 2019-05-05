using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;

namespace EnduriumMod.NPCs.KeeperofHollow
{
    public class HollowSpawn : ModProjectile
    {
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("Shiver"), 80);
        }
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 46;
            projectile.aiStyle = -1;
            projectile.light = 0.25f;
            projectile.friendly = false;
            projectile.tileCollide = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            projectile.alpha = 255;
            projectile.timeLeft = 200;
            aiType = ProjectileID.Bullet;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D glowmask = Main.projectileTexture[projectile.type];
            int glownum = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
            int y7 = glownum * projectile.frame;
            Main.spriteBatch.Draw(glowmask, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y7, glowmask.Width, glownum)), projectile.GetAlpha(Color.White), projectile.rotation, new Vector2((float)glowmask.Width / 2f, (float)glownum / 2f), projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            return false;
        }
        public override void Kill(int timeLeft)
        {
            int num414 = (int)(projectile.Center.X);
            int num415 = (int)(projectile.Center.Y);
            float Speed = 12f;
            if (Main.netMode != 1)
            {
                projectile.netUpdate = true;
                Projectile.NewProjectile((float)num414, (float)num415, Speed, -Speed, mod.ProjectileType("HollowMist"), 35, 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile((float)num414, (float)num415, -Speed, -Speed, mod.ProjectileType("HollowMist"), 35, 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile((float)num414, (float)num415, Speed, Speed, mod.ProjectileType("HollowMist"), 35, 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile((float)num414, (float)num415, -Speed, Speed, mod.ProjectileType("HollowMist"), 35, 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile((float)num414, (float)num415, 0f, -Speed, mod.ProjectileType("HollowMist"), 35, 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile((float)num414, (float)num415, 0f, Speed, mod.ProjectileType("HollowMist"), 35, 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile((float)num414, (float)num415, Speed, 0f, mod.ProjectileType("HollowMist"), 35, 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile((float)num414, (float)num415, -Speed, 0f, mod.ProjectileType("HollowMist"), 35, 0f, Main.myPlayer, 0f, 0f);
            }
            for (int num621 = 0; num621 < 12; num621++)
            {
                int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 156, 0f, 0f, 100, default(Color), 2.2f);
                Main.dust[num622].velocity *= 3f;
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[num622].scale = 0.5f;
                    Main.dust[num622].noGravity = true;
                    Main.dust[num622].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                }
            }
            for (int num623 = 0; num623 < 15; num623++)
            {
                int num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("HollowBurn"), 0f, 0f, 100, default(Color), 2.7f);
                Main.dust[num624].noGravity = true;
                Main.dust[num624].velocity *= 4f;
                num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 156, 0f, 0f, 100, default(Color), 2f);
                Main.dust[num624].velocity *= 2f;
                Main.dust[num624].noGravity = true;

            }

        }
        public override void AI()
        {
            projectile.ai[0] += 1;
            if (projectile.ai[1] == 0f)
            {
                projectile.ai[1] = 1f;
                Main.PlaySound(SoundID.Item91, projectile.position);
            }
            if (projectile.alpha >= 70)
            {
                projectile.alpha -= 4;
            }
            projectile.rotation += 0.1f;
            projectile.spriteDirection = projectile.direction;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nova Crystal");
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }
    }
}