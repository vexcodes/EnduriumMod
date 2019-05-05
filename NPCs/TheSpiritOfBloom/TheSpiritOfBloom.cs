using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.TheSpiritOfBloom
{
    [AutoloadBossHead]
    public class TheSpiritOfBloom : ModNPC
    {
        public static int SpawnTimer = 0;
        public static int LaserTimer = 0;
        public static int BigLaserTimer = 0;
        public static int HeSummonsMinionsItsUnfairOMG = 0;
        public static int NEEDLES = 0;
        public static int FirstStand = 3500;
        public int FirstStandOnce = 0;
        public static int LastStand = 1500;
        public int LastStandOnce = 0;
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = Main.npcTexture[npc.type];
            var effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(texture, npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame, drawColor, npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
            Texture2D glowmask = mod.GetTexture("NPCs/TheSpiritOfBloom/TheSpiritOfBloom_Glowmask");
            spriteBatch.Draw(glowmask, npc.Center - Main.screenPosition, npc.frame, npc.GetAlpha(Color.White), npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
            return false;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Tyrant of Bloom");
        }
        public override void SetDefaults()
        {
            npc.lifeMax = 6800;
            npc.width = 250;
            npc.height = 198;
            npc.damage = 38;
            npc.boss = true;
            npc.defense = 4;

            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath30;
            npc.knockBackResist = 0f;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Force_of_Nature");
            npc.noGravity = true;
            bossBag = mod.ItemType("BloomingTreasureBag");
            npc.noTileCollide = true;
            npc.aiStyle = -1; //new
            aiType = -1; //new
        }
        public override void NPCLoot()
        {
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {
                int itemChoice = Main.rand.Next(8);
                if (itemChoice == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TheBowOfBloom"));
                }
                else if (itemChoice == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SpiritSpear"));
                }
                else if (itemChoice == 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SpiritFlameStaff"));
                }
                else if (itemChoice == 3)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TheStaffOfBloom"));
                }
                else if (itemChoice == 4)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BlessedBlade"));
                }
                else if (itemChoice == 5)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BlessedHatchet"));
                }
                else if (itemChoice == 6)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BloomingEmblem"));
                }
                else if (itemChoice == 7)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SpiritBuckshot"));
                }
            }
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.7f * bossLifeScale);
            npc.damage = 44;
            npc.defense = 8;
        }
        float AI2 = 0;
        public float Times = 0f;
        public override void AI()
        {
            Player player = Main.player[npc.target];
            if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                player = Main.player[npc.target];
                if (!player.active || player.dead)
                {
                    npc.velocity = new Vector2(0f, -10f);
                    if (npc.timeLeft > 150)
                    {
                        npc.timeLeft = 150;
                    }
                    return;
                }
            }
            else if (npc.timeLeft > 1800)
            {
                npc.timeLeft = 1800;
            }
            bool expertMode = Main.expertMode;
            npc.TargetClosest(true);

            npc.defense = npc.defDefense;
            int num155 = 0;
            npc.damage = npc.defDamage;

            
            float num167 = 0.08f;
            float num168 = 2.2f;
            float num169 = 0.06f;
            float num170 = 9f;
            if (Main.expertMode)
            {
                num167 = 0.16f;
                num168 = 2.6f;
                num169 = 0.06f;
                num170 = 12f;
            }
            if (npc.ai[3] == 0)
            {
                if (npc.position.Y > Main.player[npc.target].position.Y - 325f)
                {
                    if (npc.velocity.Y > 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y * 0.9996f;
                    }
                    npc.velocity.Y = npc.velocity.Y - num167;
                    if (npc.velocity.Y > num168)
                    {
                        npc.velocity.Y = num168;
                    }
                }
                else if (npc.position.Y < Main.player[npc.target].position.Y - 325f)
                {
                    if (npc.velocity.Y < 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y * 0.9996f;
                    }
                    npc.velocity.Y = npc.velocity.Y + num167;
                    if (npc.velocity.Y < -num168)
                    {
                        npc.velocity.Y = -num168;
                    }
                }
                if (npc.position.X + (float)(npc.width / 2) > Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2))
                {
                    if (npc.velocity.X > 0f)
                    {
                        npc.velocity.X = npc.velocity.X * 0.9996f;
                    }
                    npc.velocity.X = npc.velocity.X - num169;
                    if (npc.velocity.X > num170)
                    {
                        npc.velocity.X = num170;
                    }
                }
                if (npc.position.X + (float)(npc.width / 2) < Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2))
                {
                    if (npc.velocity.X < 0f)
                    {
                        npc.velocity.X = npc.velocity.X * 0.9996f;
                    }
                    npc.velocity.X = npc.velocity.X + num169;
                    if (npc.velocity.X < -num170)
                    {
                        npc.velocity.X = -num170;
                    }
                }
            }
            if (npc.ai[3] == 5)
            {
                
                if (npc.ai[0] >= 100)
                {
                    float num862 = 0.15f;
                    float num863 = 7f;
                    if ((double)npc.life < (double)npc.lifeMax * 0.75)
                    {
                        num862 = 0.17f;
                        num863 = 8f;
                    }
                    if ((double)npc.life < (double)npc.lifeMax * 0.5)
                    {
                        num862 = 0.2f;
                        num863 = 9f;
                    }
                    if ((double)npc.life < (double)npc.lifeMax * 0.25)
                    {
                        num862 = 0.25f;
                        num863 = 10f;
                    }
                    num862 -= 0.05f;
                    num863 -= 1f;
                    if (npc.Center.X < Main.player[npc.target].Center.X)
                    {
                        npc.velocity.X = npc.velocity.X + num862;
                        if (npc.velocity.X < 0f)
                        {
                            npc.velocity.X = npc.velocity.X * 0.98f;
                        }
                    }
                    if (npc.Center.X > Main.player[npc.target].Center.X)
                    {
                        npc.velocity.X = npc.velocity.X - num862;
                        if (npc.velocity.X > 0f)
                        {
                            npc.velocity.X = npc.velocity.X * 0.98f;
                        }
                    }
                    if (npc.velocity.X > num863 || npc.velocity.X < -num863)
                    {
                        npc.velocity.X = npc.velocity.X * 0.95f;
                    }
                    float num864 = Main.player[npc.target].position.Y - (npc.position.Y + (float)npc.height);
                    if (num864 < 180f)
                    {
                        npc.velocity.Y = npc.velocity.Y - 0.1f;
                    }
                    if (num864 > 200f)
                    {
                        npc.velocity.Y = npc.velocity.Y + 0.1f;
                    }
                    if (npc.velocity.Y > 6f)
                    {
                        npc.velocity.Y = 6f;
                    }
                    if (npc.velocity.Y < -6f)
                    {
                        npc.velocity.Y = -6f;
                    }
                }
                npc.rotation = npc.velocity.X * 0.01f;
            }
            else
            {
                npc.rotation = npc.velocity.X / 30f;
            }
            if (npc.ai[3] == 2 && Main.netMode != 1)
            {
                if (AI2 == 0f)
                {

                    if (npc.Center.X < Main.player[npc.target].Center.X && Main.netMode != 1)
                    {
                        AI2 = 1f;
                    }
                    else
                    {
                        AI2 = -1f;
                    }
                }

                int num852 = 320;
                float num853 = Math.Abs(npc.Center.X - Main.player[npc.target].Center.X);
                if (npc.Center.X < Main.player[npc.target].Center.X && AI2 < 0f && num853 > (float)num852 && Main.netMode != 1)
                {
                    AI2 = 0f;
                }
                if (npc.Center.X > Main.player[npc.target].Center.X && AI2 > 0f && num853 > (float)num852 && Main.netMode != 1)
                {
                    AI2 = 0f;
                }
                float num854 = 0.35f;
                float num855 = 9f;
                npc.velocity.X = npc.velocity.X + AI2 * num854;
                if (npc.velocity.X > num855 && Main.netMode != 1)
                {
                    npc.velocity.X = num855;
                    npc.netUpdate = true;
                }
                if (npc.velocity.X < -num855 && Main.netMode != 1)
                {
                    npc.velocity.X = -num855;
                    npc.netUpdate = true;
                }
                float num856 = Main.player[npc.target].position.Y - 110 - (npc.position.Y + (float)npc.height);
                if (num856 < 80f && Main.netMode != 1)
                {
                    npc.velocity.Y = npc.velocity.Y - 0.2f;
                    npc.netUpdate = true;
                }
                if (num856 > 140f && Main.netMode != 1)
                {
                    npc.velocity.Y = npc.velocity.Y + 0.2f;
                    npc.netUpdate = true;
                }
                if (npc.velocity.Y > 6f && Main.netMode != 1)
                {
                    npc.velocity.Y = 6f;
                    npc.netUpdate = true;
                }
                if (npc.velocity.Y < -6f && Main.netMode != 1)
                {
                    npc.velocity.Y = -6f;
                    npc.netUpdate = true;
                }

            }
            if (npc.ai[3] == 4)
            {

                if (npc.alpha > 0)
                {
                    npc.alpha -= 30;
                    if (npc.alpha < 0)
                    {
                        npc.alpha = 0;
                    }
                }
                npc.noGravity = true;
                npc.noTileCollide = true;
                npc.knockBackResist = 0f;
                int num;
                if (npc.ai[0] == 0f)
                {
                    npc.TargetClosest(true);
                    npc.ai[0] = 1f;
                    npc.ai[1] = (float)npc.direction;
                }
                else if (npc.ai[0] == 1f)
                {
                    npc.TargetClosest(true);
                    float num1289 = 0.95f;
                    float num1290 = 17f;
                    float num1291 = 9.5f;
                    float num1292 = 760f;
                    float num1293 = 9f;
                    npc.velocity.X = npc.velocity.X + npc.ai[1] * num1289;
                    if (npc.velocity.X > num1290)
                    {
                        npc.velocity.X = num1290;
                    }
                    if (npc.velocity.X < -num1290)
                    {
                        npc.velocity.X = -num1290;
                    }
                    float num0004 = Main.player[npc.target].Center.Y - 400;
                    float num1294 = num0004 - npc.Center.Y;
                    if (Math.Abs(num1294) > num1291)
                    {
                        num1293 = 15f;
                    }
                    if (num1294 > num1291)
                    {
                        num1294 = num1291;
                    }
                    else if (num1294 < -num1291)
                    {
                        num1294 = -num1291;
                    }
                    npc.velocity.Y = (npc.velocity.Y * (num1293 - 1f) + num1294) / num1293;
                    if ((npc.ai[1] > 0f && Main.player[npc.target].Center.X - npc.Center.X < -num1292) || (npc.ai[1] < 0f && Main.player[npc.target].Center.X - npc.Center.X > num1292))
                    {
                        npc.ai[0] = 2f;
                        npc.ai[1] = 0f;
                        if (npc.Center.Y + 20f > Main.player[npc.target].Center.Y - 400)
                        {
                            npc.ai[1] = -1f;
                        }
                        else
                        {
                            npc.ai[1] = 1f;
                        }
                    }
                }
                else if (npc.ai[0] == 2f)
                {
                    float num1295 = 0.7f;
                    float scaleFactor13 = 0.95f;
                    float num1296 = 9.5f;
                    npc.velocity.Y = npc.velocity.Y + npc.ai[1] * num1295;
                    if (npc.velocity.Length() > num1296)
                    {
                        npc.velocity *= scaleFactor13;
                    }
                    if (npc.velocity.X > -1f && npc.velocity.X < 1f)
                    {
                        npc.TargetClosest(true);
                        npc.ai[0] = 3f;
                        npc.ai[1] = (float)npc.direction;
                    }
                }
                else if (npc.ai[0] == 3f)
                {
                    float num1297 = 1.8f;
                    float num1298 = 0.65f;
                    float num1299 = 11f;
                    float scaleFactor14 = 0.95f;
                    npc.velocity.X = npc.velocity.X + npc.ai[1] * num1297;
                    if (npc.Center.Y > Main.player[npc.target].Center.Y - 230)
                    {
                        npc.velocity.Y = npc.velocity.Y - num1298;
                    }
                    else
                    {
                        npc.velocity.Y = npc.velocity.Y + num1298;
                    }
                    if (npc.velocity.Length() > num1299)
                    {
                        npc.velocity *= scaleFactor14;
                    }
                    if (npc.velocity.Y > -1f && npc.velocity.Y < 1f)
                    {
                        npc.TargetClosest(true);
                        npc.ai[0] = 0f;
                        npc.ai[2] += 1;
                        npc.ai[1] = (float)npc.direction;
                    }
                }
                if (npc.ai[2] >= 2)
                {
                    npc.ai[3] = 10;
                    npc.ai[2] = 0;
                    npc.ai[1] = 0;
                    npc.ai[0] = 0;
                    Times = 0f;
                }
                int num1300 = 10;
                for (int num1301 = 0; num1301 < 1; num1301 = num + 1)
                {
                    int num1302 = Dust.NewDust(npc.position - new Vector2((float)num1300), npc.width + num1300 * 2, npc.height + num1300 * 2, 89, 0f, 0f, 100, default(Color), 2f);
                    Main.dust[num1302].noGravity = true;
                    Main.dust[num1302].noLight = true;
                    num = num1301;
                }
            }
            if (npc.ai[3] == 10)
            {
                npc.ai[0] += 1f;
                npc.velocity.X *= 0.95f;
                npc.velocity.Y *= 0.95f;
                if (npc.ai[0] >= 80)
                {
                    npc.ai[0] = 0;
                    if ((double)npc.life < (double)npc.lifeMax * 0.5)
                    {
                        if (Main.rand.Next(2) == 0)
                        {
                            npc.ai[3] = 5;
                        }
                        else
                        {
                            if (Main.rand.Next(2) == 0)
                            {
                                npc.ai[3] = 0;
                            }
                            else
                            {
                                npc.ai[3] = 2;
                            }
                        }
                    }
                    else
                    {
                        if (Main.rand.Next(2) == 0)
                        {
                            npc.ai[3] = 0;
                        }
                        else
                        {
                            npc.ai[3] = 2;
                        }
                    }
                }
            }
            if (npc.ai[3] == 0)
            {
                npc.ai[0] += 1f;
                npc.ai[2] += 1f;
                if (npc.ai[0] >= 55 && Main.netMode != 1) // small leaf
                {
                    npc.ai[0] = 0;
                    Main.PlaySound(SoundID.Item17, npc.position);
                    float Speed = 12f;  // projectile speed
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 4), npc.position.Y + (npc.height / 4));
                    int damage = 20;  // projectile damage
                    int type = mod.ProjectileType("MiniLeaf");  //put your projectile
                    float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                    npc.netUpdate = true;
                }
                int num3 = 160;
                if (Main.expertMode)
                {
                    num3 = 130;
                    npc.ai[0] += 0.1f;
                    npc.ai[2] += 0.15f;
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.9)
                {
                    npc.ai[0] += 0.2f;
                    npc.ai[2] += 0.15f;
                    if (Main.expertMode)
                    {
                        num3 = 120;
                    }
                    else
                    {
                        num3 = 150;
                    }
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.8)
                {
                    npc.ai[0] += 0.2f;
                    npc.ai[2] += 0.15f;
                    if (Main.expertMode)
                    {
                        num3 = 110;
                    }
                    else
                    {
                        num3 = 143;
                    }
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.7)
                {
                    npc.ai[0] += 0.2f;
                    npc.ai[2] += 0.15f;
                    if (Main.expertMode)
                    {
                        num3 = 100;
                    }
                    else
                    {
                        num3 = 130;
                    }
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.6)
                {
                    npc.ai[0] += 0.1f;
                    npc.ai[2] += 0.15f;
                    if (Main.expertMode)
                    {
                        num3 = 90;
                    }
                    else
                    {
                        num3 = 120;
                    }
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.5)
                {
                    npc.ai[0] += 0.1f;
                    npc.ai[2] += 0.15f;
                    if (Main.expertMode)
                    {
                        num3 = 80;
                    }
                    else
                    {
                        num3 = 110;
                    }
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.4)
                {
                    npc.ai[0] += 0.1f;
                    npc.ai[2] += 0.15f;
                    if (Main.expertMode)
                    {
                        num3 = 75;
                    }
                    else
                    {
                        num3 = 100;
                    }
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.3)
                {
                    npc.ai[0] += 0.1f;
                    npc.ai[2] += 0.15f;
                    if (Main.expertMode)
                    {
                        num3 = 65;
                    }
                    else
                    {
                        num3 = 90;
                    }
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.2)
                {
                    npc.ai[0] += 0.1f;
                    npc.ai[2] += 0.15f;
                    if (Main.expertMode)
                    {
                        num3 = 45;
                    }
                    else
                    {
                        num3 = 80;
                    }
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.1)
                {
                    npc.ai[0] += 0.1f;
                    npc.ai[2] += 0.15f;
                    if (Main.expertMode)
                    {
                        num3 = 35;
                    }
                    else
                    {
                        num3 = 65;
                    }
                }
                if (Main.rand.Next(num3) == 0)
                {
                    Vector2 vector78 = new Vector2(npc.position.X + (float)(npc.width / 2) + (float)(Main.rand.Next(20) * npc.direction), npc.position.Y + (float)npc.height * 0.8f);
                    Vector2 vector79 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                    float num600 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector79.X;
                    float num601 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - 300f - vector79.Y;
                    float num602 = (float)Math.Sqrt((double)(num600 * num600 + num601 * num601));
                    bool flag39 = false;
                    Main.PlaySound(SoundID.Item17, npc.position);
                    if (Main.netMode != 1)
                    {
                        float num603 = 6f;
                        if (Main.expertMode)
                        {
                            num603 += 2f;
                        }
                        if (Main.expertMode && (double)npc.life < (double)npc.lifeMax * 0.25)
                        {
                            num603 += 3f;
                        }
                        float num604 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector78.X + (float)Main.rand.Next(-80, 81);
                        float num605 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector78.Y + (float)Main.rand.Next(-40, 41);
                        float num606 = (float)Math.Sqrt((double)(num604 * num604 + num605 * num605));
                        num606 = num603 / num606;
                        num604 *= num606;
                        num605 *= num606;
                        int num607 = 28;
                        int num608 = mod.ProjectileType("MiniLeaf");
                        int num609 = Projectile.NewProjectile(vector78.X, vector78.Y, num604, num605, num608, num607, 0f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num609].timeLeft = 300;
                    }

                    npc.netUpdate = true;
                }
                if (npc.ai[2] >= 425 && Main.netMode != 1) // falcon leaf
                {
                    npc.ai[2] = 0;
                    npc.netUpdate = true;
                    float Speed = 14f;  // projectile speed
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 4), npc.position.Y + (npc.height / 4));
                    int damage = 16;  // projectile damage
                    int type = mod.ProjectileType("FalconLeaf");  //put your projectile
                    float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                    npc.ai[1] += 1;
                }
                if (npc.ai[1] >= 2)
                {
                    npc.ai[0] = 0;
                    npc.ai[1] = 0;
                    npc.ai[2] = 0;
                    if (Main.rand.Next(5) == 0)
                    {
                        npc.ai[3] = 4;
                    }
                    else
                    {
                        npc.ai[3] = 1;
                    }
                }
            }
            if (npc.ai[3] == 1)
            {
                npc.ai[0] += 0.003f;
                if (npc.ai[0] >= 0.3f)
                {
                    npc.ai[0] = 0.3f;
                    npc.ai[1] += 1f;
                }
                npc.velocity.X *= 0.9f;
                if (npc.velocity.Y <= 0.8f)
                {
                    npc.velocity.Y += npc.ai[0];
                }
                if (npc.velocity.Y >= 0.8f)
                {
                    npc.velocity.Y -= npc.ai[0];
                }
                if (npc.ai[1] == 60f)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("BloomStrike"), (int)((double)npc.damage * 0.75f), 0f, Main.myPlayer);
                }
                if (npc.ai[1] == 90f)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("BloomStrike"), (int)((double)npc.damage * 0.75f), 0f, Main.myPlayer);
                }
                if (npc.ai[1] >= 120f)
                {
                    npc.ai[1] = 0f;
                    npc.ai[0] = 0f;
                    npc.ai[3] = 2;
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("BloomStrike"), (int)((double)npc.damage * 0.75f), 0f, Main.myPlayer);

                }
            }
            if (npc.ai[3] == 2)
            {
                npc.ai[0] += 1f;
                npc.ai[2] += 1f;
                if (npc.ai[0] >= 125 && Main.netMode != 1) // small leaf
                {
                    npc.ai[0] = 0;
                    float Speed = 11f;  // projectile speed
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 4), npc.position.Y + (npc.height / 4));
                    int damage = 21;  // projectile damage
                    int type = mod.ProjectileType("Leaf");  //put your projectile
                    float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                    npc.netUpdate = true;
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.9)
                {
                    npc.ai[0] += 0.2f;
                    npc.ai[2] += 0.15f;
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.8)
                {
                    npc.ai[0] += 0.2f;
                    npc.ai[2] += 0.15f;
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.7)
                {
                    npc.ai[0] += 0.2f;
                    npc.ai[2] += 0.15f;
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.6)
                {
                    npc.ai[0] += 0.2f;
                    npc.ai[2] += 0.15f;
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.5)
                {
                    npc.ai[0] += 0.2f;
                    npc.ai[2] += 0.15f;
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.4)
                {
                    npc.ai[0] += 0.2f;
                    npc.ai[2] += 0.15f;
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.3)
                {
                    npc.ai[0] += 0.2f;
                    npc.ai[2] += 0.15f;
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.2)
                {
                    npc.ai[0] += 0.2f;
                    npc.ai[2] += 0.15f;
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.1)
                {
                    npc.ai[0] += 0.2f;
                    npc.ai[2] += 0.15f;
                }
                if (npc.ai[2] >= 425 && Main.netMode != 1) // falcon leaf
                {
                    npc.ai[2] = 0;
                    npc.netUpdate = true;
                    float Speed = 14f;  // projectile speed
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 4), npc.position.Y + (npc.height / 4));
                    int damage = 16;  // projectile damage
                    int type = mod.ProjectileType("FalconLeaf");  //put your projectile
                    float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                    npc.ai[1] += 1;
                }
                if (npc.ai[1] >= 2)
                {
                    npc.ai[0] = 0;
                    npc.ai[1] = 0;
                    npc.ai[2] = 0;
                    if (Main.rand.Next(5) == 0)
                    {
                        npc.ai[3] = 4;
                    }
                    else
                    {
                        npc.ai[3] = 3;
                    }
                }
            }
            if (npc.ai[3] == 3)
            {
                if (npc.ai[2] == 1)
                {
                    int num11 = Main.rand.Next(2, 3);
                    for (int j = 0; j < num11; j++)
                    {
                        Vector2 vector5 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                        vector5 += npc.velocity * 3f;
                        vector5.Normalize();
                        vector5 *= (float)Main.rand.Next(35, 39) * 0.1f;

                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vector5.X, vector5.Y, mod.ProjectileType("LeafBurst"), 30, 0f, 0);

                    }
                    npc.ai[2] = 0;
                }
                npc.ai[0] += 0.003f;
                if (npc.ai[0] >= 0.3f)
                {
                    npc.ai[0] = 0.3f;
                    npc.ai[1] += 1f;
                }
                npc.velocity.X *= 0.9f;
                if (npc.velocity.Y <= 0.8f)
                {
                    npc.velocity.Y += npc.ai[0];
                }
                if (npc.velocity.Y >= 0.8f)
                {
                    npc.velocity.Y = 0.8f;
                }
                if (npc.ai[1] == 60f)
                {
                    npc.ai[2] = 1;
                }
                if (npc.ai[1] == 90f)
                {
                    npc.ai[2] = 1;
                }
                if (npc.ai[1] == 120f)
                {
                    npc.ai[2] = 1;
                }
                if (npc.ai[1] >= 150f)
                {
                    npc.ai[1] = 0f;
                    npc.ai[0] = 0f;
                    if ((double)npc.life < (double)npc.lifeMax * 0.5)
                    {
                        npc.ai[3] = 5;
                    }
                    else
                    {
                        npc.ai[3] = 0;
                    }
                }
            }
            if (npc.ai[3] == 4)
            {
                Times += 1f;
                if ((double)npc.life < (double)npc.lifeMax * 0.9)
                {
                    Times += 0.025f;
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.8)
                {
                    Times += 0.025f;
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.7)
                {
                    Times += 0.025f;
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.6)
                {
                    Times += 0.025f;
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.5)
                {
                    Times += 0.025f;
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.4)
                {
                    Times += 0.05f;
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.3)
                {
                    Times += 0.05f;
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.2)
                {
                    Times += 0.05f;
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.1)
                {
                    Times += 0.05f;
                }
                if (Times > 12f)
                {
                    if (Main.netMode != 1)
                    {
                        Times = 0f;
                        npc.netUpdate = true;
                        float Speed = 14f;  // projectile speed
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 4), npc.position.Y + (npc.height / 4));
                        int damage = 22;  // projectile damage
                        int type = mod.ProjectileType("BloomingEnergy");  //put your projectile
                        float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, 0f, 12f, type, damage, 0f, Main.myPlayer);
                        npc.netUpdate = true;
                    }
                    return;
                }
            }
            if (npc.ai[3] != 4 && npc.ai[3] != 5)
            {
                Times = 0f;
            }
            if (npc.ai[3] == 5)
            {
                if (Times == 0f)
                {
                    Times = 1f;
                    player.AddBuff(mod.BuffType("Slimy"), 870);
                }
                npc.ai[0] += 1;
                if (npc.ai[0] <= 100)
                {
                    npc.velocity.X *= 0.95f;
                    npc.velocity.Y *= 0.95f;
                }
                    if (npc.ai[0] == 170)
                {
                    int num3;
                    int num4;
                    int num11 = Main.rand.Next(5, 8);
                    for (int j = 0; j < num11; j++)
                    {
                        Vector2 vector5 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                        vector5 += npc.velocity * 3f;
                        vector5.Normalize();
                        vector5 *= (float)Main.rand.Next(35, 39) * 0.1f;

                        int dab = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vector5.X, vector5.Y, mod.ProjectileType("Egg"), 0, 0f, 0);
                        Main.projectile[dab].timeLeft = 280;
                    }
                }
                if (npc.ai[0] == 230)
                {
                    int num3;
                    int num4;
                    int num11 = Main.rand.Next(5, 8);
                    for (int j = 0; j < num11; j++)
                    {
                        Vector2 vector5 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                        vector5 += npc.velocity * 3f;
                        vector5.Normalize();
                        vector5 *= (float)Main.rand.Next(35, 39) * 0.1f;

                        int dab = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vector5.X, vector5.Y, mod.ProjectileType("Egg"), 0, 0f, 0);
                        Main.projectile[dab].timeLeft = 220;
                    }
                }
                if (npc.ai[0] == 290)
                {
                    npc.ai[2] += 1;
                    npc.ai[0] = 0;
                    int num3;
                    int num4;
                    int num11 = Main.rand.Next(5, 8);
                    for (int j = 0; j < num11; j++)
                    {
                        Vector2 vector5 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                        vector5 += npc.velocity * 3f;
                        vector5.Normalize();
                        vector5 *= (float)Main.rand.Next(35, 39) * 0.1f;

                        int dab = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vector5.X, vector5.Y, mod.ProjectileType("Egg"), 0, 0f, 0);
                        Main.projectile[dab].timeLeft = 160;
                    }
                }
                if (npc.ai[2] == 3)
                {
                    
                    npc.ai[1] += 1;
                    
                    if (npc.ai[1] >= 80)
                    {
                        npc.ai[2] = 0;
                        npc.ai[0] = 0;
                        npc.ai[1] = 0;
                        npc.ai[3] = 0;
                        if (Main.rand.Next(5) == 0)
                        {
                            npc.ai[3] = 4;
                        }
                        else
                        {
                            npc.ai[3] = 0;
                        }
                    }
                }
            }
        }



        public override void HitEffect(int hitDirection, double damage)
        {
            for (int k = 0; k < 10; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 3, hitDirection, -1f, 0, default(Color), 1f);
            }
            if (npc.life <= 0)
            {
                for (int num621 = 0; num621 < 40; num621++)
                {
                    int num622 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 89, 0f, 0f, 100, default(Color), 2f);
                    Main.dust[num622].velocity *= 3f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[num622].scale = 0.5f;
                        Main.dust[num622].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                    }
                }
                for (int num623 = 0; num623 < 60; num623++)
                {
                    int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 61, 0f, 0f, 100, default(Color), 3f);
                    Main.dust[num624].noGravity = true;
                    Main.dust[num624].velocity *= 15f;
                    num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 89, 0f, 0f, 100, default(Color), 2f);
                    Main.dust[num624].velocity *= 2f;
                }
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheSpiritOfBloom_Gore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheSpiritOfBloom_Gore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheSpiritOfBloom_Gore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheSpiritOfBloom_Gore2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheSpiritOfBloom_Gore3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheSpiritOfBloom_Gore3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheSpiritOfBloom_Gore3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheSpiritOfBloom_Gore3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheSpiritOfBloom_Gore3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheSpiritOfBloom_Gore3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheSpiritOfBloom_Gore4"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheSpiritOfBloom_Gore4"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheSpiritOfBloom_Gore4"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheSpiritOfBloom_Gore4"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheSpiritOfBloom_Gore4"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheSpiritOfBloom_Gore4"), 1f);
            }
        }
    }
}