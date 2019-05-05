﻿using System;
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
    public class HollowBoomBoomBoom : ModProjectile
    {
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("Shiver"), 80);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D glowmask = Main.projectileTexture[projectile.type];
            int glownum = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
            int y7 = glownum * projectile.frame;
            Main.spriteBatch.Draw(glowmask, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y7, glowmask.Width, glownum)), projectile.GetAlpha(Color.White), projectile.rotation, new Vector2((float)glowmask.Width / 2f, (float)glownum / 2f), projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            return false;
        }
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 56;
            projectile.aiStyle = 1;
            projectile.light = 0.25f;
            projectile.friendly = false;
            projectile.tileCollide = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            projectile.alpha = 250;
            projectile.timeLeft = 2500;
            aiType = ProjectileID.Bullet;
        }
        public override void Kill(int timeLeft)
        {
            for (int num621 = 0; num621 < 12; num621++)
            {
                int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("HollowBurn"), 0f, 0f, 100, default(Color), 1.2f);
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
                int num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 156, 0f, 0f, 100, default(Color), 1.7f);
                Main.dust[num624].noGravity = true;
                Main.dust[num624].velocity *= 4f;
                num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("HollowBurn"), 0f, 0f, 100, default(Color), 1f);
                Main.dust[num624].velocity *= 2f;
                Main.dust[num624].noGravity = true;
                Main.dust[num624].fadeIn = 0.7f;
            }
        }
        public override void AI()
        {
            if (projectile.alpha >= 120)
            {
                projectile.alpha -= 4;
            }
            projectile.ai[0] += 1;

            Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedByRandom(MathHelper.ToRadians(3));
            projectile.velocity.Y = perturbedSpeed.Y;
            projectile.velocity.X = perturbedSpeed.X;
            projectile.ai[0] = 0;

            int num4324;
            int num;
            for (int num20 = 0; num20 < 1; num20 = num4324 + 1)
            {
                float num21 = projectile.velocity.X / 4f * (float)num20;
                float num22 = projectile.velocity.Y / 4f * (float)num20;
                int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("HollowBurn"), 0f, 0f, 0, default(Color), 0.28f);
                Main.dust[num23].position.X = projectile.Center.X - num21;
                Main.dust[num23].position.Y = projectile.Center.Y - num22;
                Dust dust3 = Main.dust[num23];
                dust3.velocity *= 0f;
                Main.dust[num23].scale = 0.68f;
                Main.dust[num23].velocity *= 0.28f;
                Main.dust[num23].noGravity = true;
                num4324 = num20;
            }
            if (projectile.ai[1] == 0f)
            {
                projectile.ai[1] = 1f;
                Main.PlaySound(SoundID.Item91, projectile.position);
            }



        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nova");
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }
    }
}