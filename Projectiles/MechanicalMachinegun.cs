using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class MechanicalMachinegun : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 114;
            projectile.height = 28;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            Main.projFrames[projectile.type] = 6;
            projectile.ranged = true;
            projectile.ignoreWater = true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical Machinegun");
        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            float num = 1.57079637f;
            Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
            num = 0f;
            if (projectile.spriteDirection == -1)
            {
                num = 3.14159274f;
            }
            projectile.ai[0] += 1f;
            int num34 = 0;
            if (projectile.ai[0] >= 30f)
            {
                num34++;
            }
            if (projectile.ai[0] >= 60f)
            {
                num34++;
            }
            if (projectile.ai[0] >= 100f)
            {
                num34++;
            }
            if (projectile.ai[0] >= 160f)
            {
                num34++;
            }
            if (projectile.ai[0] >= 240f)
            {
                num34++;
            }
            int num35 = 22;
            int num36 = 4;
            projectile.ai[1] -= 1f;
            bool flag13 = false;
            int num37 = -1;
            if (projectile.ai[1] <= 0f)
            {
                projectile.ai[1] = (float)(num35 - num36 * num34);
                flag13 = true;
                int num38 = (int)projectile.ai[0] / (num35 - num36 * num34);
                if (num38 % 7 == 0)
                {
                    num37 = 0;
                }
            }
            projectile.frameCounter += 1 + num34;
            if (projectile.frameCounter >= 6)
            {
                projectile.frameCounter = 0;
                projectile.frame++;
                if (projectile.frame >= Main.projFrames[projectile.type])
                {
                    projectile.frame = 0;
                }
            }
            if (projectile.soundDelay <= 0)
            {
                projectile.soundDelay = num35 - num36 * num34;
                if (projectile.ai[0] != 1f)
                {
                    Main.PlaySound(SoundID.Item11, projectile.position);
                }
            }
            if (flag13 && Main.myPlayer == projectile.owner)
            {
                bool flag14 = player.channel && player.HasAmmo(player.inventory[player.selectedItem], true) && !player.noItems && !player.CCed;
                int num39 = 14;
                float scaleFactor9 = 14f;
                int weaponDamage = player.GetWeaponDamage(player.inventory[player.selectedItem]);
                float weaponKnockback = player.inventory[player.selectedItem].knockBack;
                if (flag14)
                {
                    player.PickAmmo(player.inventory[player.selectedItem], ref num39, ref scaleFactor9, ref flag14, ref weaponDamage, ref weaponKnockback, false);
                    weaponKnockback = player.GetWeaponKnockback(player.inventory[player.selectedItem], weaponKnockback);
                    float scaleFactor10 = player.inventory[player.selectedItem].shootSpeed * projectile.scale;
                    Vector2 vector26 = vector;
                    Vector2 value9 = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY) - vector26;
                    if (player.gravDir == -1f)
                    {
                        value9.Y = (float)(Main.screenHeight - Main.mouseY) + Main.screenPosition.Y - vector26.Y;
                    }
                    Vector2 vector27 = Vector2.Normalize(value9);
                    if (float.IsNaN(vector27.X) || float.IsNaN(vector27.Y))
                    {
                        vector27 = -Vector2.UnitY;
                    }
                    vector27 *= scaleFactor10;
                    vector27 = vector27.RotatedBy(Main.rand.NextDouble() * 0.13089969754219055 - 0.065449848771095276, default(Vector2));
                    if (vector27.X != projectile.velocity.X || vector27.Y != projectile.velocity.Y)
                    {
                        projectile.netUpdate = true;
                    }
                    projectile.velocity = vector27;
                    for (int m = 0; m < 1; m++)
                    {
                        Vector2 vector28 = Vector2.Normalize(projectile.velocity) * scaleFactor9;
                        vector28 = vector28.RotatedBy(Main.rand.NextDouble() * 0.19634954631328583 - 0.098174773156642914, default(Vector2));
                        if (float.IsNaN(vector28.X) || float.IsNaN(vector28.Y))
                        {
                            vector28 = -Vector2.UnitY;
                        }
                        Projectile.NewProjectile(vector26.X, vector26.Y, vector28.X, vector28.Y, 242, player.inventory[player.selectedItem].damage, player.inventory[player.selectedItem].knockBack, projectile.owner, 0f, 0f);
                    }
                    if (num37 == 0)
                    {
                        num39 = 616;
                        scaleFactor9 = 8f;
                        for (int n = 0; n < 1; n++)
                        {
                            Vector2 vector29 = Vector2.Normalize(projectile.velocity) * scaleFactor9;
                            vector29 = vector29.RotatedBy(Main.rand.NextDouble() * 0.39269909262657166 - 0.19634954631328583, default(Vector2));
                            if (float.IsNaN(vector29.X) || float.IsNaN(vector29.Y))
                            {
                                vector29 = -Vector2.UnitY;
                            }
                            Projectile.NewProjectile(vector26.X, vector26.Y, vector29.X, vector29.Y, 242, player.inventory[player.selectedItem].damage + 20, player.inventory[player.selectedItem].knockBack, projectile.owner, 0f, 0f);
                        }
                    }
                }
                else
                {
                    projectile.Kill();
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
            projectile.position.Y = projectile.position.Y + player.gravDir * 2f;
        }
    }
}