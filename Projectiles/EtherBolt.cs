using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class EtherBolt : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 34;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            Main.projFrames[projectile.type] = 5;
            projectile.timeLeft = 300;
            projectile.alpha = 10;
        }
        public override void AI()
        {

            float num624 = 6800f;
            float num625 = 900f;
            float num626 = 1900f;
            float num627 = 160f;
            if (Main.player[projectile.owner].dead)
            {
                projectile.Kill();
            }

            float num628 = 0.2f;
            int num3;
            for (int num629 = 0; num629 < 1000; num629 = num3 + 1)
            {
                bool flag22 = true;
                if (((num629 != projectile.whoAmI && Main.projectile[num629].active && Main.projectile[num629].owner == projectile.owner) & flag22) && Math.Abs(projectile.position.X - Main.projectile[num629].position.X) + Math.Abs(projectile.position.Y - Main.projectile[num629].position.Y) < (float)projectile.width)
                {
                    if (projectile.position.X < Main.projectile[num629].position.X)
                    {
                        projectile.velocity.X = projectile.velocity.X - num628;
                    }
                    else
                    {
                        projectile.velocity.X = projectile.velocity.X + num628;
                    }
                    if (projectile.position.Y < Main.projectile[num629].position.Y)
                    {
                        projectile.velocity.Y = projectile.velocity.Y - num628;
                    }
                    else
                    {
                        projectile.velocity.Y = projectile.velocity.Y + num628;
                    }
                }
                num3 = num629;
            }

            Vector2 vector49 = projectile.position;
            bool flag24 = false;
            if (projectile.ai[0] != 1f && (projectile.type == 387 || projectile.type == 388))
            {
                projectile.tileCollide = true;
            }

            if (projectile.tileCollide && WorldGen.SolidTile(Framing.GetTileSafely((int)projectile.Center.X / 16, (int)projectile.Center.Y / 16)))
            {
                projectile.tileCollide = false;
            }
            NPC ownerMinionAttackTargetNPC3 = projectile.OwnerMinionAttackTargetNPC;
            if (ownerMinionAttackTargetNPC3 != null && ownerMinionAttackTargetNPC3.CanBeChasedBy(projectile, false))
            {
                float num636 = Vector2.Distance(ownerMinionAttackTargetNPC3.Center, projectile.Center);
                if (((Vector2.Distance(projectile.Center, vector49) > num636 && num636 < num624) || !flag24) && Collision.CanHitLine(projectile.position, projectile.width, projectile.height, ownerMinionAttackTargetNPC3.position, ownerMinionAttackTargetNPC3.width, ownerMinionAttackTargetNPC3.height))
                {
                    num624 = num636;
                    vector49 = ownerMinionAttackTargetNPC3.Center;
                    flag24 = true;
                }
            }
            if (!flag24)
            {
                for (int num637 = 0; num637 < 200; num637 = num3 + 1)
                {
                    NPC nPC2 = Main.npc[num637];
                    if (nPC2.CanBeChasedBy(projectile, false))
                    {
                        float num638 = Vector2.Distance(nPC2.Center, projectile.Center);
                        if (((Vector2.Distance(projectile.Center, vector49) > num638 && num638 < num624) || !flag24) && Collision.CanHitLine(projectile.position, projectile.width, projectile.height, nPC2.position, nPC2.width, nPC2.height))
                        {
                            num624 = num638;
                            vector49 = nPC2.Center;
                            flag24 = true;
                        }
                    }
                    num3 = num637;
                }
            }
            float num639 = num625;
            if (flag24)
            {
                num639 = num626;
            }
            Player player2 = Main.player[projectile.owner];
            if (Vector2.Distance(player2.Center, projectile.Center) > num639)
            {

                projectile.ai[0] = 1f;


                projectile.tileCollide = false;
                projectile.netUpdate = true;
            }
            if (flag24 && projectile.ai[0] == 0f)
            {
                Vector2 vector50 = vector49 - projectile.Center;
                float num640 = vector50.Length();
                vector50.Normalize();
                if (num640 > 200f)
                {
                    float scaleFactor2 = 6f;

                    scaleFactor2 = 8f;

                    vector50 *= scaleFactor2;
                    projectile.velocity = (projectile.velocity * 40f + vector50) / 41f;
                }
                else
                {
                    float num641 = 4f;
                    vector50 *= -num641;
                    projectile.velocity = (projectile.velocity * 40f + vector50) / 41f;
                }
            }
            else
            {
                bool flag25 = false;
                if (!flag25)
                {
                    flag25 = (projectile.ai[0] == 1f && (projectile.type == 387 || projectile.type == 388));
                }
                if (!flag25)
                {
                    flag25 = (projectile.ai[0] >= 9f && projectile.type == 533);
                }
                float num642 = 6f;

                if (flag25)
                {
                    num642 = 15f;
                }
                Vector2 center2 = projectile.Center;
                Vector2 vector51 = player2.Center - center2 + new Vector2(0f, -60f);
                float num643 = vector51.Length();
                if (num643 > 200f && num642 < 8f)
                {
                    num642 = 8f;
                }
                if ((num643 < num627 & flag25) && !Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
                {

                    projectile.ai[0] = 0f;


                    projectile.netUpdate = true;
                }
                if (num643 > 2000f)
                {
                    projectile.position.X = Main.player[projectile.owner].Center.X - (float)(projectile.width / 2);
                    projectile.position.Y = Main.player[projectile.owner].Center.Y - (float)(projectile.height / 2);
                    projectile.netUpdate = true;
                }
                if (num643 > 70f)
                {
                    vector51.Normalize();
                    vector51 *= num642;
                    projectile.velocity = (projectile.velocity * 40f + vector51) / 41f;
                }
                else if (projectile.velocity.X == 0f && projectile.velocity.Y == 0f)
                {
                    projectile.velocity.X = -0.15f;
                    projectile.velocity.Y = -0.05f;
                }
            }



            if (projectile.ai[1] > 0f && (projectile.type == 387 || projectile.type == 388))
            {
                projectile.ai[1] += (float)Main.rand.Next(1, 4);
            }
            if (projectile.ai[1] > 90f && projectile.type == 387)
            {
                projectile.ai[1] = 0f;
                projectile.netUpdate = true;
            }
            if (projectile.ai[1] > 40f && projectile.type == 388)
            {
                projectile.ai[1] = 0f;
                projectile.netUpdate = true;
            }
            if (projectile.ai[1] > 0f && projectile.type == 533)
            {
                projectile.ai[1] += 1f;
                int num649 = 10;
                if (projectile.ai[1] > (float)num649)
                {
                    projectile.ai[1] = 0f;
                    projectile.netUpdate = true;
                }
            }
            if (projectile.ai[0] == 0f)
            {
                if (projectile.ai[1] == 0f && flag24 && num624 < 500f)
                {
                    projectile.ai[1] += 1f;
                    if (Main.myPlayer == projectile.owner)
                    {
                        projectile.ai[0] = 2f;
                        Vector2 value14 = vector49 - projectile.Center;
                        value14.Normalize();
                        projectile.velocity = value14 * 8f;
                        projectile.netUpdate = true;
                        return;
                    }
                }
            }

            int num2323;
            for (int num20 = 0; num20 < 4; num20 = num2323 + 1)
            {
                float num21 = projectile.velocity.X / 4f * (float)num20;
                float num22 = projectile.velocity.Y / 4f * (float)num20;
                int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 156, 0f, 0f, 0, default(Color), 1.6f);
                Main.dust[num23].position.X = projectile.Center.X - num21;
                Main.dust[num23].position.Y = projectile.Center.Y - num22;
                Dust dust3 = Main.dust[num23];
                dust3.velocity *= 0f;
                Main.dust[num23].scale = 0.5f;
                num2323 = num20;
            }

        }
        public override void Kill(int timeLeft)
        {

            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
            for (int num621 = 0; num621 < 15; num621++)
            {
                int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 156, 0f, 0f, 95, default(Color), 1.2f);
                Main.dust[num622].velocity *= 2f;
                Main.dust[num622].scale *= 0.6f;
            }
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ether Parasite");
        }
    }
}
