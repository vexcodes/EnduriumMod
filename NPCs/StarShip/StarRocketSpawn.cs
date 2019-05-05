using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.StarShip
{
    public class StarRocketSpawn : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Rocket");
        }
        public override void SetDefaults()
        {
            projectile.width = 44;
            projectile.height = 44;
            projectile.timeLeft = 600;
            projectile.penetrate = 1;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.tileCollide = true;
            projectile.ignoreWater = false;
            projectile.alpha = 240;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D glowmask = Main.projectileTexture[projectile.type];
            int glownum = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
            int y7 = glownum * projectile.frame;
            Main.spriteBatch.Draw(glowmask, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y7, glowmask.Width, glownum)), projectile.GetAlpha(Color.White), projectile.rotation, new Vector2((float)glowmask.Width / 2f, (float)glownum / 2f), projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            return false;
        }
        public override void AI()
        {
            int num;

            if (projectile.alpha >= 20)
            {
                projectile.alpha -= 2;
            }
            projectile.rotation += 0.06f;

            Player owner = Main.player[projectile.owner]; //Makes a player variable of owner set as the player using the projectile
            projectile.velocity.X *= 0.5f;
            projectile.velocity.Y *= 0.5f;
            projectile.ai[0] += 1;
            if (projectile.ai[0] >= 10)
            {
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 60);
                projectile.ai[0] = 1;
                projectile.ai[1] += 20f;
                float SpeedX = 12f;
                float SpeedY = 12f;
                Vector2 perturbedSpeed1 = new Vector2(SpeedX, SpeedY).RotatedBy(MathHelper.ToRadians(projectile.ai[1]));
                Vector2 vector8 = new Vector2((projectile.position.X + Main.rand.Next(-20, 21)) + (projectile.width / 2), (projectile.position.Y + Main.rand.Next(-20, 21)) + (projectile.height / 2));
                int damage = 35;  // projectile damage
                int type = mod.ProjectileType("StarRocket");  //put your projectile
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, perturbedSpeed1.X, perturbedSpeed1.Y, type, damage, 0f, Main.myPlayer);
            }
            if (projectile.ai[0] == 0)
            {
                projectile.ai[0] = 1;
                projectile.ai[1] += Main.rand.Next(-200, 200);
            }

        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item62, projectile.position);
            Vector2 vector19 = projectile.position;
            Vector2 oldVelocity = projectile.oldVelocity;
            oldVelocity.Normalize();
            vector19 += oldVelocity * 16f;
            int num3;
            for (int num355 = 0; num355 < 30; num355 = num3 + 1)
            {
                int num356 = Dust.NewDust(vector19, projectile.width, projectile.height, 156, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num356].position = (Main.dust[num356].position + projectile.Center) / 2f;
                Dust dust = Main.dust[num356];
                dust.velocity += projectile.oldVelocity * 1.4f;
                dust = Main.dust[num356];
                dust.velocity *= 0.8f;
                dust.fadeIn *= 2.8f;
                Main.dust[num356].noGravity = true;
                vector19 -= oldVelocity * 2f;
                num3 = num355;
            }
        }
    }
}