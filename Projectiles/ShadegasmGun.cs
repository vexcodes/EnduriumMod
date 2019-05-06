using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class ShadegasmGun : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 64;
            projectile.friendly = true;
            projectile.penetrate = -1;
            Main.projFrames[projectile.type] = 7;
            projectile.tileCollide = false;
            projectile.ranged = true;
            projectile.ignoreWater = true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadegasm");
        }
        int shotsLeft = 0;
        float damage = 0.25f;
        public override bool CanHitPvp(Player target)
        {
            return false;
        }
        public override bool? CanHitNPC(NPC target)
        {
            return false;
        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            float num = 1.57079637f;
            Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);

            bool flag3 = player.channel && !player.noItems && !player.CCed;
            if (projectile.frame != 6)
            {
                projectile.ai[0] += 0.05f;
                projectile.ai[1] += 0.032f;
                if (flag3)
                {
                    projectile.frameCounter += (int)projectile.ai[0];
                }
                if (projectile.frameCounter >= 40)
                {
                    shotsLeft += 2;
                    projectile.frameCounter = 0;
                    projectile.frame += 1;
                }
            }
            if (projectile.frame == 6)
            {
                if (projectile.ai[0] > 0)
                {
                    Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 93); //zap sound
                    projectile.ai[0] = 0;
                }
                if (projectile.ai[0] <= 0)
                {
                    projectile.ai[0] -= 0.1f;
                }
            }

            int num16 = 0;
            Vector2 vector13 = Vector2.UnitX * 45f;
            vector13 = vector13.RotatedBy((double)(projectile.rotation - 1.57079637f), default(Vector2));
            Vector2 value6 = projectile.Center + vector13;
            if (projectile.ai[1] > 0)
            {
                for (int k = 0; k < num16 + 1; k++)
                {
                    int num18 = mod.DustType("Shadegasm");
                    float num19 = 1.1f;
                    Vector2 vector14 = value6 + ((float)Main.rand.NextDouble() * 6.28318548f).ToRotationVector2() * ((11f * projectile.ai[1]) - (float)(num16 * 2));
                    int num20 = Dust.NewDust(vector14 - Vector2.One * 8f, 16, 16, num18, projectile.velocity.X / 2f, projectile.velocity.Y / 2f, 0, default(Color), 0.6f);
                    Main.dust[num20].velocity = Vector2.Normalize(value6 - vector14) * 1.5f * (10f - (float)num16 * 2f) / 10f;
                    Main.dust[num20].noGravity = true;
                    Main.dust[num20].scale = num19;
                    Main.dust[num20].customData = player;
                }
            }
            if (Main.myPlayer == projectile.owner) //triggers for shooting
            {
                if (flag3)
                {
                    if (projectile.ai[1] >= 0.25f)
                    {
                        damage = projectile.ai[1];
                    }

                    float scaleFactor = player.inventory[player.selectedItem].shootSpeed * projectile.scale;
                    Vector2 vector3 = vector;
                    Vector2 value2 = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY) - vector3;
                    if (player.gravDir == -1f)
                    {
                        value2.Y = (float)(Main.screenHeight - Main.mouseY) + Main.screenPosition.Y - vector3.Y;
                    }
                    Vector2 vector4 = Vector2.Normalize(value2);
                    if (float.IsNaN(vector4.X) || float.IsNaN(vector4.Y))
                    {
                        vector4 = -Vector2.UnitY;
                    }
                    vector4 *= scaleFactor;
                    if (vector4.X != projectile.velocity.X || vector4.Y != projectile.velocity.Y)
                    {
                        projectile.netUpdate = true;
                    }
                    projectile.velocity = vector4;
                }
                if (!flag3)
                {
                    projectile.ai[1] -= 0.3f;
                    if (projectile.ai[1] <= -10f)
                    {
                        projectile.Kill();
                    }
                    float scaleFactor = player.inventory[player.selectedItem].shootSpeed * projectile.scale;
                    Vector2 vector3 = vector;
                    Vector2 value2 = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY) - vector3;
                    float spread1 = 0.002f;
                    float scaleFactor2 = 15f;
                    int num6 = mod.ProjectileType("Shadegasm");
                    int num7 = 6;
                    if (projectile.ai[1] <= 0f)
                    {
                        if (shotsLeft != 0)
                        {
                            shotsLeft -= 1;
                            projectile.ai[0] = 8f;
                            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 92); //charged zap sound
                            for (int j = 0; j < 1; j++)
                            {
                                vector3 = projectile.Center + new Vector2((float)Main.rand.Next(-num7, num7 + 1), (float)Main.rand.Next(-num7, num7 + 1));
                                Vector2 vector5 = Vector2.Normalize(projectile.velocity) * scaleFactor2;
                                vector5 = vector5.RotatedBy(Main.rand.NextDouble() * 0.1f - 0.1f / 2, default(Vector2));
                                if (float.IsNaN(vector5.X) || float.IsNaN(vector5.Y))
                                {
                                    vector5 = -Vector2.UnitY;
                                }
                                Projectile.NewProjectile(value6.X, value6.Y, vector5.X, vector5.Y, num6, (projectile.damage / 2) * (int)damage, projectile.knockBack, projectile.owner, 0f, damage);
                                Main.PlaySound(SoundID.Item11, projectile.position);
                            }
                        }
                    }
                }
            }
            projectile.position = player.RotatedRelativePoint(player.MountedCenter, true) - projectile.Size / 2f;
            projectile.rotation = projectile.velocity.ToRotation() + num;
            projectile.spriteDirection = projectile.direction;
            projectile.timeLeft = 2;
            player.ChangeDir(projectile.direction);
            player.heldProj = projectile.whoAmI;
            player.itemTime = 2;
            player.itemAnimation = 2;
            player.itemRotation = (float)Math.Atan2((double)(projectile.velocity.Y * (float)projectile.direction), (double)(projectile.velocity.X * (float)projectile.direction));
        }
    }
}
