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

namespace EnduriumMod.NPCs.StarInfection
{
    public class StarHive : ModNPC
    {
        public override void SetDefaults()
        {

            npc.damage = 90;
            npc.npcSlots = 1f;
            npc.width = 46; //324
            npc.height = 66; //216
            npc.defense = 10;
            npc.value = 60000f;
            npc.lifeMax = 3400;
            npc.aiStyle = -1; //new
            aiType = -1; //new
            npc.knockBackResist = 0f;
            Main.npcFrameCount[npc.type] = 5;
            npc.value = Item.buyPrice(0, 20, 0, 0);
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.damage = 100;
            npc.defense = 16;
            npc.lifeMax = 5600;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.24f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Hive");
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.GetModPlayer<MyPlayer>(mod).ZonePlanet ? 0.5f : 0f;
        }
        public override void NPCLoot()
        {
            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StarShard"));
            }
        }
        public override void AI()
        {
            {
                bool flag19 = false;
                bool flag20 = npc.type == 330 && !Main.pumpkinMoon;

                if (npc.justHit)
                {
                    npc.ai[2] = 0f;
                }
                if (!flag20)
                {
                    if (npc.ai[2] >= 0f)
                    {
                        int num283 = 16;
                        bool flag21 = false;
                        bool flag22 = false;
                        if (npc.position.X > npc.ai[0] - (float)num283 && npc.position.X < npc.ai[0] + (float)num283)
                        {
                            flag21 = true;
                        }
                        else if ((npc.velocity.X < 0f && npc.direction > 0) || (npc.velocity.X > 0f && npc.direction < 0))
                        {
                            flag21 = true;
                        }
                        num283 += 24;
                        if (npc.position.Y > npc.ai[1] - (float)num283 && npc.position.Y < npc.ai[1] + (float)num283)
                        {
                            flag22 = true;
                        }
                        if (flag21 & flag22)
                        {
                            npc.ai[2] += 1f;
                            if (npc.ai[2] >= 30f && num283 == 16)
                            {
                                flag19 = true;
                            }
                            if (npc.ai[2] >= 60f)
                            {
                                npc.ai[2] = -200f;
                                npc.direction *= -1;
                                npc.velocity.X = npc.velocity.X * -1f;
                                npc.collideX = false;
                            }
                        }
                        else
                        {
                            npc.ai[0] = npc.position.X;
                            npc.ai[1] = npc.position.Y;
                            npc.ai[2] = 0f;
                        }
                        npc.TargetClosest(true);
                    }

                    else
                    {

                        npc.ai[2] += 1f;

                        if (Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) > npc.position.X + (float)(npc.width / 2))
                        {
                            npc.direction = -1;
                        }
                        else
                        {
                            npc.direction = 1;
                        }
                    }
                }
                int num284 = (int)((npc.position.X + (float)(npc.width / 2)) / 16f) + npc.direction * 2;
                int num285 = (int)((npc.position.Y + (float)npc.height) / 16f);
                bool flag23 = true;
                bool flag24 = false;
                int num286 = 3;



                npc.alpha = 30;
                if (Main.rand.Next(3) == 0)
                {
                    int num294 = Dust.NewDust(npc.position, npc.width, npc.height, 156, 0f, 0f, 200, default(Color), 1f);
                    Dust dust3 = Main.dust[num294];
                    dust3.velocity *= 0.3f;
                    Main.dust[num294].noGravity = true;
                }
                float num295 = 5f;
                Vector2 vector34 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                float num296 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector34.X;
                float num297 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector34.Y;
                float num298 = (float)Math.Sqrt((double)(num296 * num296 + num297 * num297));
                num298 = num295 / num298;
                num296 *= num298;
                num297 *= num298;
                if (num296 > 0f)
                {
                    npc.direction = 1;
                }
                else
                {
                    npc.direction = -1;
                }
                npc.spriteDirection = npc.direction;
                if (Main.netMode != 1 && npc.ai[3] == 16f)
                {
                    int num299 = 15;
                    int num300 = mod.ProjectileType("StarBurst2");
                    Projectile.NewProjectile(vector34.X, vector34.Y, num296, num297, num300, num299, 0f, Main.myPlayer, 0f, 0f);
                }
                num286 = 10;
                if (npc.ai[3] > 0f)
                {
                    npc.ai[3] += 1f;
                    if (npc.ai[3] >= 34f)
                    {
                        npc.ai[3] = 0f;
                    }
                }
                if (Main.netMode != 1 && npc.ai[3] == 0f)
                {
                    npc.localAI[1] += 1f;
                    if (npc.localAI[1] > 120f && Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
                    {
                        npc.localAI[1] = 0f;
                        npc.ai[3] = 1f;
                        npc.netUpdate = true;
                    }
                }



                int num;
                for (int num309 = num285; num309 < num285 + num286; num309 = num + 1)
                {
                    if (Main.tile[num284, num309] == null)
                    {
                        Main.tile[num284, num309] = new Tile();
                    }
                    if ((Main.tile[num284, num309].nactive() && Main.tileSolid[(int)Main.tile[num284, num309].type]) || Main.tile[num284, num309].liquid > 0)
                    {
                        if (num309 <= num285 + 1)
                        {
                            flag24 = true;
                        }
                        flag23 = false;
                        break;
                    }
                    num = num309;
                }
                if (Main.player[npc.target].npcTypeNoAggro[npc.type])
                {
                    bool flag25 = false;
                    for (int num310 = num285; num310 < num285 + num286 - 2; num310 = num + 1)
                    {
                        if (Main.tile[num284, num310] == null)
                        {
                            Main.tile[num284, num310] = new Tile();
                        }
                        if ((Main.tile[num284, num310].nactive() && Main.tileSolid[(int)Main.tile[num284, num310].type]) || Main.tile[num284, num310].liquid > 0)
                        {
                            flag25 = true;
                            break;
                        }
                        num = num310;
                    }
                    npc.directionY = (!flag25).ToDirectionInt();
                }

                for (int num311 = num285 - 3; num311 < num285; num311 = num + 1)
                {
                    if (Main.tile[num284, num311] == null)
                    {
                        Main.tile[num284, num311] = new Tile();
                    }
                    if ((Main.tile[num284, num311].nactive() && Main.tileSolid[(int)Main.tile[num284, num311].type]) || Main.tile[num284, num311].liquid > 0)
                    {
                        flag24 = false;
                        flag19 = true;
                        break;
                    }
                    num = num311;
                }

                if (flag19)
                {
                    flag24 = false;
                    flag23 = true;

                }
                if (flag23)
                {

                    npc.velocity.Y = npc.velocity.Y + 0.2f;
                    if (npc.velocity.Y > 2f)
                    {
                        npc.velocity.Y = 2f;
                    }


                }
                else
                {

                    if ((npc.directionY < 0 && npc.velocity.Y > 0f) | flag24)
                    {
                        npc.velocity.Y = npc.velocity.Y - 0.2f;
                    }


                    if (npc.velocity.Y < -4f)
                    {
                        npc.velocity.Y = -4f;
                    }
                }

                if (npc.collideX)
                {
                    npc.velocity.X = npc.oldVelocity.X * -0.4f;
                    if (npc.direction == -1 && npc.velocity.X > 0f && npc.velocity.X < 1f)
                    {
                        npc.velocity.X = 1f;
                    }
                    if (npc.direction == 1 && npc.velocity.X < 0f && npc.velocity.X > -1f)
                    {
                        npc.velocity.X = -1f;
                    }
                }
                if (npc.collideY)
                {
                    npc.velocity.Y = npc.oldVelocity.Y * -0.25f;
                    if (npc.velocity.Y > 0f && npc.velocity.Y < 1f)
                    {
                        npc.velocity.Y = 1f;
                    }
                    if (npc.velocity.Y < 0f && npc.velocity.Y > -1f)
                    {
                        npc.velocity.Y = -1f;
                    }
                }
                float num312 = 2f;

                if (npc.direction == -1 && npc.velocity.X > -num312)
                {
                    npc.velocity.X = npc.velocity.X - 0.1f;
                    if (npc.velocity.X > num312)
                    {
                        npc.velocity.X = npc.velocity.X - 0.1f;
                    }
                    else if (npc.velocity.X > 0f)
                    {
                        npc.velocity.X = npc.velocity.X + 0.05f;
                    }
                    if (npc.velocity.X < -num312)
                    {
                        npc.velocity.X = -num312;
                    }
                }
                else if (npc.direction == 1 && npc.velocity.X < num312)
                {
                    npc.velocity.X = npc.velocity.X + 0.1f;
                    if (npc.velocity.X < -num312)
                    {
                        npc.velocity.X = npc.velocity.X + 0.1f;
                    }
                    else if (npc.velocity.X < 0f)
                    {
                        npc.velocity.X = npc.velocity.X - 0.05f;
                    }
                    if (npc.velocity.X > num312)
                    {
                        npc.velocity.X = num312;
                    }
                }


                num312 = 1.5f;

                if (npc.directionY == -1 && npc.velocity.Y > -num312)
                {
                    npc.velocity.Y = npc.velocity.Y - 0.04f;
                    if (npc.velocity.Y > num312)
                    {
                        npc.velocity.Y = npc.velocity.Y - 0.05f;
                    }
                    else if (npc.velocity.Y > 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y + 0.03f;
                    }
                    if (npc.velocity.Y < -num312)
                    {
                        npc.velocity.Y = -num312;
                    }
                }
                else if (npc.directionY == 1 && npc.velocity.Y < num312)
                {
                    npc.velocity.Y = npc.velocity.Y + 0.04f;
                    if (npc.velocity.Y < -num312)
                    {
                        npc.velocity.Y = npc.velocity.Y + 0.05f;
                    }
                    else if (npc.velocity.Y < 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y - 0.03f;
                    }
                    if (npc.velocity.Y > num312)
                    {
                        npc.velocity.Y = num312;
                    }
                }
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 14);
                int num3;
                int num4;
                for (int num624 = 0; num624 < 50; num624 = num3 + 1)
                {
                    int num625 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 156, 0f, 0f, 0, default(Color), 2f);
                    Dust dust = Main.dust[num625];
                    dust.velocity *= 2.5f;
                    dust = Main.dust[num625];
                    dust.scale *= 0.9f;
                    Main.dust[num625].noGravity = true;
                    num3 = num624;
                }
                int num11 = Main.rand.Next(4, 8);
                for (int j = 0; j < num11; j++)
                {
                    Vector2 vector5 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                    vector5 += npc.velocity * 3f;
                    vector5.Normalize();
                    vector5 *= (float)Main.rand.Next(35, 39) * 0.1f;

                    int dab = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vector5.X, vector5.Y, mod.ProjectileType("StarBlast2"), 40, 0f, 0);
                    Main.projectile[dab].hostile = true;
                    Main.projectile[dab].friendly = false;
                }
            }
        }
    }
}