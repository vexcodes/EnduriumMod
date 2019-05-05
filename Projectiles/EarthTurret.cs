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

namespace EnduriumMod.Projectiles
{
    public class EarthTurret : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Earth Turret");
        }
        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.friendly = true;
            projectile.height = 32;
            projectile.width = 22;
            projectile.alpha = 0;
            projectile.penetrate = -1;
            projectile.timeLeft *= 5;
            projectile.tileCollide = false;
            projectile.minion = true;
        }
        public override void AI()
        {

            //Making player variable "p" set as the projectile's owner
            Player player = Main.player[projectile.owner];
            int[] array = new int[20];
            int num428 = 0;
            float num429 = 300f;
            //Factors for calculations
            double deg = (double)projectile.ai[1]; //The degrees, you can multiply projectile.ai[1] to make it orbit faster, may be choppy depending on the value
            double rad = deg * (Math.PI / 180); //Convert degrees to radians
            double dist = 50; //Distance away from the player

            /*Position the player based on where the player is, the Sin/Cos of the angle times the /
            /distance for the desired distance away from the player minus the projectile's width   /
            /and height divided by two so the center of the projectile is at the right place.     */
            projectile.position.X = player.Center.X - (int)(Math.Cos(rad) * dist) - projectile.width / 2;
            projectile.position.Y = player.Center.Y - (int)(Math.Sin(rad) * dist) - projectile.height / 2;

            //Increase the counter/angle in degrees by 1 point, you can change the rate here too, but the orbit may look choppy depending on the value
            projectile.ai[1] += 2f;
            bool flag64 = projectile.type == mod.ProjectileType("EarthTurret");
            MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(mod, "MyPlayer");

            if (player.dead)
            {
                modPlayer.EarthTurret = false;
            }
            if (modPlayer.EarthTurret)
            {
                projectile.timeLeft = 2;
            }
            if (!modPlayer.BiologicalCrit)
            {
                projectile.Kill();
            }



            int num3 = projectile.frameCounter;


            int num433 = 0;
            float num434 = 300f;
            bool flag14 = false;
            for (int num435 = 0; num435 < 200; num435 = num3 + 1)
            {
                if (Main.npc[num435].CanBeChasedBy(projectile, false))
                {
                    float num436 = Main.npc[num435].position.X + (float)(Main.npc[num435].width / 2);
                    float num437 = Main.npc[num435].position.Y + (float)(Main.npc[num435].height / 2);
                    float num438 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num436) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num437);
                    if (num438 < num434 && Collision.CanHit(projectile.Center, 1, 1, Main.npc[num435].Center, 1, 1))
                    {
                        if (num433 < 20)
                        {
                            array[num433] = num435;
                            num3 = num433;
                            num433 = num3 + 1;
                        }
                        flag14 = true;
                    }
                }
                num3 = num435;
            }

            if (flag14)
            {
                int num439 = Main.rand.Next(num433);
                num439 = array[num439];
                float num440 = Main.npc[num439].position.X + (float)(Main.npc[num439].width / 2);
                float num441 = Main.npc[num439].position.Y + (float)(Main.npc[num439].height / 2);
                projectile.localAI[0] += 1f;
                if (projectile.localAI[0] > 50f)
                {
                    projectile.localAI[0] = 0f;
                    float num442 = 18f;
                    Vector2 vector32 = new Vector2(projectile.position.X + (float)projectile.width, projectile.position.Y + (float)projectile.height);
                    vector32 += projectile.velocity * 4f;
                    float num443 = num440 - vector32.X;
                    float num444 = num441 - vector32.Y;
                    float num445 = (float)Math.Sqrt((double)(num443 * num443 + num444 * num444));
                    num445 = num442 / num445;
                    num443 *= num445;
                    num444 *= num445;
                    int num666 = 30;
                    int num307 = mod.ProjectileType("StoneFossilFriendly");
                    Projectile.NewProjectile(vector32.X, vector32.Y, num443, num444, num307, num666, projectile.knockBack, projectile.owner, 0f, 0f);
                    return;
                }

            }
        }
    }
}
	