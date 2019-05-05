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

namespace EnduriumMod.NPCs.EndurianWarlock
{
    public class PlagueSplit : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 24;
            projectile.hostile = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 14;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plague Split");
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = -oldVelocity.X;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.velocity.Y = -oldVelocity.Y;
            }
            return false;
        }
        public override void AI()
        {
            if (projectile.timeLeft == 1)
            {
                projectile.Kill();
                Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 21);
                if (projectile.hostile)
                {
                    int numProj = 3;
                    float rotation = MathHelper.ToRadians(10);
                    for (int i = 0; i < numProj + 1; i++)
                    {
                        Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numProj - 1)));
                        int numgay1 = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("PlagueStrike"), (int)((double)projectile.damage), projectile.knockBack, projectile.owner, 0f, 0f);
                        Main.projectile[numgay1].hostile = true;
                        Main.projectile[numgay1].friendly = false;
                    }
                    int numgay = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, mod.ProjectileType("PlagueStrike"), (int)((double)projectile.damage), projectile.knockBack, projectile.owner, 0f, 0f);
                    Main.projectile[numgay].hostile = true;
                    Main.projectile[numgay].friendly = false;
                }
                else if (projectile.friendly)
                {

                    int numProj = 3;
                    float rotation = MathHelper.ToRadians(10);
                    for (int i = 0; i < numProj + 1; i++)
                    {
                        Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numProj - 1)));
                        int numgay1 = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("PlagueStrike"), (int)((double)projectile.damage), projectile.knockBack, projectile.owner, 0f, 0f);
                        Main.projectile[numgay1].friendly = true;
                        Main.projectile[numgay1].hostile = false;
                        Main.projectile[numgay1].penetrate = 2;
                    }
                    int numgay = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, mod.ProjectileType("PlagueStrike"), (int)((double)projectile.damage), projectile.knockBack, projectile.owner, 0f, 0f);
                    Main.projectile[numgay].friendly = true;
                    Main.projectile[numgay].hostile = false;
                    Main.projectile[numgay].penetrate = 1;
                }
                for (int num623 = 0; num623 < 15; num623++)
                {
                    int num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 89, 0f, 0f, 100, default(Color), 1.2f);
                    Main.dust[num624].noGravity = true;
                    Main.dust[num624].velocity *= 4f;
                }
            }
            int num3;
            for (int num93 = 0; num93 < 5; num93 = num3 + 1)
            {
                float num94 = projectile.velocity.X / 3f * (float)num93;
                float num95 = projectile.velocity.Y / 3f * (float)num93;
                int num96 = 4;
                int num97 = Dust.NewDust(new Vector2(projectile.position.X + (float)num96, projectile.position.Y + (float)num96), projectile.width - num96 * 2, projectile.height - num96 * 2, 89, 0f, 0f, 100, default(Color), 0.9f);
                Main.dust[num97].noGravity = true;
                Dust dust3 = Main.dust[num97];
                dust3.velocity *= 0f;
                dust3 = Main.dust[num97];
                dust3.velocity += projectile.velocity * 0f;
                Dust dust6 = Main.dust[num97];
                dust6.position.X = dust6.position.X - num94;
                Dust dust7 = Main.dust[num97];
                dust7.position.Y = dust7.position.Y - num95;
                num3 = num93;
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D glowmask = Main.projectileTexture[projectile.type];
            int glownum = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
            int y7 = glownum * projectile.frame;
            Main.spriteBatch.Draw(glowmask, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y7, glowmask.Width, glownum)), projectile.GetAlpha(Color.White), projectile.rotation, new Vector2((float)glowmask.Width / 2f, (float)glownum / 2f), projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            return false;
        }
    }
}
