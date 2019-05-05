using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.StarShip
{
    public class StarShippo : ModNPC
    {
        public override void SetDefaults()
        {

            npc.damage = 140;
            npc.npcSlots = 1f;
            npc.width = 156; //324
            npc.height = 156; //216
            npc.defense = 25;
            npc.lifeMax = 400000;
            npc.knockBackResist = 0f;
            npc.aiStyle = -1; //new
            aiType = -1; //new
            npc.value = Item.buyPrice(0, 20, 0, 0);
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath4;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Celestial_Intervention");
            bossBag = mod.ItemType("StarTreasureBag");
        }
        public virtual bool CheckDead(NPC npc)
        {
            return false;
        }
        public override void NPCLoot()
        {
            if (!Main.expertMode)
            {

                int itemChoice = Main.rand.Next(8);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StarShard"), Main.rand.Next(15, 25));
                if (itemChoice == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("1"));
                }
                else if (itemChoice == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("2"));
                }
                else if (itemChoice == 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("3"));
                }
                else if (itemChoice == 3)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("4"));
                }
                else if (itemChoice == 4)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("5"));
                }
                else if (itemChoice == 5)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("6"));
                }
                else if (itemChoice == 6)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("7"));
                }
                else if (itemChoice == 7)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("8"));
                }
                if (Main.rand.Next(15) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CoreofInfusion"));
                }
            }
            else
            {
                npc.DropBossBags();
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 14);

                for (int num621 = 0; num621 < 12; num621++)
                {
                    int num622 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, mod.DustType("StarFlame"), 0f, 0f, 100, default(Color), 2.2f);
                    Main.dust[num622].velocity *= 3f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[num622].scale = 0.5f;
                        Main.dust[num622].noGravity = true;
                    }
                }

            }
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.damage = 120;
            npc.defense = 50;
            npc.lifeMax = (int)(npc.lifeMax * bossLifeScale);
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Fortress");
        }
        float rotationPlus = 0f;

        int dustpos1 = 180;
        int dustpos2 = 0;

        double dist = 112;


        bool Phase2 = false;
        bool Phase3 = false;
        bool Phase4 = false;

        float rotationBase = 0.02f;
        float movementACCX = 0.12f;
        float movementACCY = 0.23f;
        float movementCAPX = 11f;
        float movementCAPY = 14f;

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = Main.npcTexture[npc.type];
            var effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(texture, npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame, drawColor, npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
            Texture2D glowmask = mod.GetTexture("NPCs/StarShip/StarShippo_Glowmask");
            spriteBatch.Draw(glowmask, npc.Center - Main.screenPosition, npc.frame, npc.GetAlpha(Color.White), npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
            return false;
        }
        public override void AI()
        {

            //phase changing
            bool StarRocks = NPC.AnyNPCs(mod.NPCType("StarRock2"));
            if (StarRocks || npc.ai[3] == 100)
            {
                npc.dontTakeDamage = true;
            }
            else
            {
                npc.dontTakeDamage = false;
            }
            if (!Phase2)
            {
                if ((double)npc.life < (double)npc.lifeMax * 0.70)
                {

                    int num32 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("StarRock2"));
                    Main.npc[num32].ai[1] = 0;
                    Main.npc[num32].ai[0] = npc.whoAmI;
                    int num33 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("StarRock2"));
                    Main.npc[num33].ai[1] = 45;
                    Main.npc[num33].ai[0] = npc.whoAmI;
                    int num34 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("StarRock2"));
                    Main.npc[num34].ai[1] = 90;
                    Main.npc[num34].ai[0] = npc.whoAmI;
                    int num35 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("StarRock2"));
                    Main.npc[num35].ai[1] = 135;
                    Main.npc[num35].ai[0] = npc.whoAmI;
                    int num36 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("StarRock2"));
                    Main.npc[num36].ai[1] = 180;
                    Main.npc[num36].ai[0] = npc.whoAmI;
                    int num37 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("StarRock2"));
                    Main.npc[num37].ai[1] = 225;
                    Main.npc[num37].ai[0] = npc.whoAmI;
                    int num38 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("StarRock2"));
                    Main.npc[num38].ai[1] = 270;
                    Main.npc[num38].ai[0] = npc.whoAmI;
                    int num39 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("StarRock2"));
                    Main.npc[num39].ai[1] = 315;
                    Main.npc[num39].ai[0] = npc.whoAmI;
                    Phase2 = true;
                    npc.ai[3] = 5;
                    npc.ai[0] = 0;
                    npc.ai[1] = 0;
                    npc.ai[2] = 0;
                }
            }
            if (!Phase3)
            {
                if ((double)npc.life < (double)npc.lifeMax * 0.45)
                {
                    Phase3 = true;

                }
            }
            if (!Phase4)
            {
                if ((double)npc.life < (double)npc.lifeMax * 0.15)
                {
                    npc.ai[3] = 100;
                    Phase4 = true;
                }
            }
            if (npc.ai[3] == 100) //overcharge
            {
                npc.velocity.X *= 0.1f;
                npc.velocity.Y *= 0.1f;
                npc.ai[0] += 0.01f;
                npc.ai[1] += npc.ai[0];
                npc.ai[2] += 1;
                if (npc.ai[1] >= 50f)
                {
                    npc.ai[1] = 0f;
                    int data = Projectile.NewProjectile(npc.position.X + Main.rand.Next(-500, 501), npc.position.Y + Main.rand.Next(-500, 501), 0f, 0f, mod.ProjectileType("StarOvercharge"), 0, 0f, Main.myPlayer, 0f, 0f);
                    Main.projectile[data].ai[0] = npc.Center.X;
                    Main.projectile[data].ai[1] = npc.Center.Y;
                    npc.netUpdate = true;
                }
                if (npc.ai[2] >= 800)
                {
                    npc.ai[1] = 0;
                    npc.ai[3] = 15;
                    npc.ai[0] = 0;
                    npc.ai[2] = 0;
                }
            }

            //player choosing
            Player P = Main.player[npc.target];
            if (!P.active || P.dead)
            {
                npc.TargetClosest(false);
                P = Main.player[npc.target];
                if (!P.active || P.dead)
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
            if (P.Center.X > npc.Center.X)
            {
                npc.spriteDirection = 1;
            }
            else
            {
                npc.spriteDirection = -1;
            }
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }
            //rotation
            rotationPlus = (npc.velocity.X + npc.velocity.Y) * 0.005f;
            if (P.Center.X > npc.Center.X)
            {
                npc.rotation += (rotationBase + rotationPlus);
            }
            else
            {
                npc.rotation -= ((rotationBase) - rotationPlus);
            }
            bool expertMode = Main.expertMode;
            //movement
            if (npc.ai[3] <= 5)
            {
                float num794 = 10f;
                if (expertMode)
                {
                    num794 = 12f;
                }
                if (Phase2)
                {
                    num794 = 16f;
                }
                Vector2 vector102 = new Vector2(npc.Center.X, npc.Center.Y);
                float num791 = Main.player[npc.target].Center.X - vector102.X;
                float num792 = Main.player[npc.target].Center.Y - vector102.Y;
                float num793 = (float)Math.Sqrt((double)(num791 * num791 + num792 * num792));
                num793 = num794 / num793;
                num791 *= num793;
                num792 *= num793;
                npc.velocity.X = (npc.velocity.X * 100f + num791) / 101f;
                npc.velocity.Y = (npc.velocity.Y * 100f + num792) / 101f;
            }
            if (npc.ai[3] >= 6)
            {
                if (Phase3)
                {
                    movementCAPY = 17f;
                    movementCAPX = 14f;
                }
                if (Phase4)
                {
                    movementCAPY = 21f;
                    movementCAPX = 17f;
                }
                if (npc.velocity.Y >= movementCAPY)
                {
                    npc.velocity.Y = movementCAPY;
                }
                if (npc.velocity.Y <= -movementCAPY)
                {
                    npc.velocity.Y = -movementCAPY;
                }
                if (npc.velocity.X >= movementCAPX)
                {
                    npc.velocity.X = movementCAPX;
                }
                if (npc.velocity.X <= -movementCAPX)
                {
                    npc.velocity.X = -movementCAPX;
                }
                if (npc.position.Y > P.position.Y + 50f)
                {
                    npc.velocity.Y = npc.velocity.Y -= movementACCY;
                }
                else if (npc.position.Y < P.position.Y - 50f)
                {
                    npc.velocity.Y = npc.velocity.Y += movementACCY;
                }
                if (npc.position.X + (float)(npc.width / 2) > (P.position.X + (float)(P.width / 2)) + 50f)
                {
                    npc.velocity.X = npc.velocity.X -= movementACCX;
                }
                if (npc.position.X + (float)(npc.width / 2) < (P.position.X + (float)(P.width / 2)) - 50f)
                {
                    npc.velocity.X = npc.velocity.X += movementACCX;
                }
            }
            if (npc.ai[3] == 0)
            {
                npc.ai[0] += 1;
                if (npc.ai[1] <= 4)
                {
                    npc.ai[0] += 1;
                }
                if (npc.ai[0] >= 70)
                {
                    npc.ai[1] += 1;
                    if (npc.ai[1] >= 5)
                    {
                        int num11 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("GraniteRotation"));
                        Main.npc[num11].ai[1] = 0;
                        Main.npc[num11].ai[0] = npc.whoAmI;
                        Main.npc[num11].netUpdate = true;
                        int num12 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("GraniteRotation"));
                        Main.npc[num12].ai[1] = 120;
                        Main.npc[num12].ai[0] = npc.whoAmI;
                        Main.npc[num12].netUpdate = true;
                        int num13 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("GraniteRotation"));
                        Main.npc[num13].ai[1] = 240;
                        Main.npc[num13].ai[0] = npc.whoAmI;
                        Main.npc[num13].netUpdate = true;
                        Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 93); //zap sound
                        npc.ai[2] += 1;
                    }
                    if (npc.ai[1] <= 4)
                    {
                        float Speed = 12f;
                        Vector2 vector8 = new Vector2((npc.position.X + Main.rand.Next(-20, 21)) + (npc.width / 2), (npc.position.Y + Main.rand.Next(-20, 21)) + (npc.height / 2));
                        int damage = 30;  // projectile damage
                        int type = mod.ProjectileType("SpikeShot");  //put your projectile
                        float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                    }
                    if (npc.ai[2] == 8)
                    {
                        npc.ai[3] = 1;
                    }
                    if (npc.ai[1] == 8)
                    {
                        npc.ai[1] = 0;
                    }
                    if (npc.ai[2] == 18)
                    {
                        npc.ai[3] = 2;
                        npc.ai[2] = 0;
                        npc.ai[1] = 0;
                    }
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 93); //zap sound
                    npc.ai[0] = 0;
                }
            }
            if (npc.ai[3] == 1 || npc.ai[3] == 2)
            {
                if (dist >= 4)
                {
                    double deg1 = (double)dustpos1;
                    double deg2 = (double)dustpos2;
                    double rad1 = deg1 * (Math.PI / 180);
                    double rad2 = deg2 * (Math.PI / 180);
                    int a = Dust.NewDust(npc.Center, npc.width, npc.height, 156, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                    Main.dust[a].noGravity = true;
                    Main.dust[a].velocity *= 0f;
                    Main.dust[a].scale *= 1.1f;
                    Main.dust[a].position.X = npc.Center.X - (int)(Math.Cos(rad1) * dist);
                    Main.dust[a].position.Y = npc.Center.Y - (int)(Math.Sin(rad1) * dist);

                    int b = Dust.NewDust(npc.Center, npc.width, npc.height, 156, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                    Main.dust[b].noGravity = true;
                    Main.dust[b].velocity *= 0f;
                    Main.dust[b].scale *= 1.1f;
                    Main.dust[b].position.X = npc.Center.X - (int)(Math.Cos(rad2) * dist);
                    Main.dust[b].position.Y = npc.Center.Y - (int)(Math.Sin(rad2) * dist);

                    dustpos1 += 8;
                    dustpos2 += 8;
                }

                if (npc.ai[0] >= 220f) //after 60 ticks since fireing the 5th projectile the dust starts to go closer towards the middle
                {
                    dustpos1 += 8;
                    dustpos2 += 8;
                    if (dist >= 4)
                    {
                        dist -= 2;
                    }
                }
                if (dist <= 8)
                {
                    if (npc.ai[3] == 1)
                    {
                        float Speed = 14f;  // projectile speed
                        if (Main.expertMode)
                        {
                            Speed += 2f;
                        }
                        if (Phase2)
                        {
                            Speed += 2f;
                        }
                        if (Phase3)
                        {
                            Speed += 2f;
                        }
                        if (Phase4)
                        {
                            Speed += 4f;
                        }
                        Vector2 vector8 = new Vector2(npc.Center.X, npc.Center.Y);
                        int damage = 35;  // projectile damage
                        int type = mod.ProjectileType("ChargedBeam");  //put your projectile
                        float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);

                        npc.netUpdate = true;
                    }
                    if (npc.ai[3] == 2)
                    {
                        Vector2 vector8 = new Vector2(npc.Center.X, npc.Center.Y);
                        int damage = 35;  // projectile damage
                        int type = mod.ProjectileType("StarRock1");  //put your projectile
                        int num11 = Projectile.NewProjectile(vector8.X, vector8.Y, 0f, 0f, type, damage, 0f, Main.myPlayer);
                        Main.projectile[num11].localAI[0] = 0;
                        Main.projectile[num11].ai[0] = npc.Center.X;
                        Main.projectile[num11].ai[1] = npc.Center.Y;
                        Main.projectile[num11].netUpdate = true;
                        int num12 = Projectile.NewProjectile(vector8.X, vector8.Y, 0f, 0f, type, damage, 0f, Main.myPlayer);
                        Main.projectile[num12].localAI[0] = 180;
                        if (Main.rand.Next(2) == 0)
                        {
                            Main.projectile[num12].localAI[0] = 270;
                            Main.projectile[num11].localAI[0] = 90;
                        }
                        Main.projectile[num12].ai[0] = npc.Center.X;
                        Main.projectile[num12].ai[1] = npc.Center.Y;
                        Main.projectile[num12].netUpdate = true;
                    }
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 92); //charged zap sound
                    dist = 112;
                    dustpos1 = 0;
                    dustpos2 = 180;
                    npc.ai[3] = 0;
                    npc.ai[0] = 0;

                }
            }
            if (npc.ai[3] == 1)
            {
                npc.ai[1] = 0;
                npc.ai[2] = 10;
                npc.ai[0] += 1;
            }
            if (npc.ai[3] == 2)
            {
                npc.ai[0] += 1;
            }
            if (npc.ai[3] == 3)
            {
                npc.ai[0] += 1;
                if (npc.ai[0] >= 50)
                {
                    npc.ai[0] = 0;
                    npc.ai[1] += 1;
                    int num11 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("GraniteRotation"));
                    Main.npc[num11].ai[1] = 0;
                    Main.npc[num11].ai[0] = npc.whoAmI;
                    Main.npc[num11].netUpdate = true;
                    int num12 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("GraniteRotation"));
                    Main.npc[num12].ai[1] = 72;
                    Main.npc[num12].ai[0] = npc.whoAmI;
                    Main.npc[num12].netUpdate = true;
                    int num13 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("GraniteRotation"));
                    Main.npc[num13].ai[1] = 144;
                    Main.npc[num13].ai[0] = npc.whoAmI;
                    Main.npc[num13].netUpdate = true;
                    int num14 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("GraniteRotation"));
                    Main.npc[num14].ai[1] = 216;
                    Main.npc[num14].ai[0] = npc.whoAmI;
                    Main.npc[num14].netUpdate = true;
                    int num15 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("GraniteRotation"));
                    Main.npc[num15].ai[1] = 288;
                    Main.npc[num15].ai[0] = npc.whoAmI;
                    Main.npc[num15].netUpdate = true;
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 93); //zap sound
                }
            }
            if (npc.ai[3] == 4)
            {
                npc.ai[0] += 1;
                if (npc.ai[0] == 40)
                {
                    int num11 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("GraniteRotation"));
                    Main.npc[num11].ai[1] = 0;
                    Main.npc[num11].ai[0] = npc.whoAmI;
                    Main.npc[num11].netUpdate = true;
                    int num12 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("GraniteRotation"));
                    Main.npc[num12].ai[1] = 72;
                    Main.npc[num12].ai[0] = npc.whoAmI;
                    Main.npc[num12].netUpdate = true;
                    int num13 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("GraniteRotation"));
                    Main.npc[num13].ai[1] = 144;
                    Main.npc[num13].ai[0] = npc.whoAmI;
                    Main.npc[num13].netUpdate = true;
                    int num14 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("GraniteRotation"));
                    Main.npc[num14].ai[1] = 216;
                    Main.npc[num14].ai[0] = npc.whoAmI;
                    Main.npc[num14].netUpdate = true;
                    int num15 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("GraniteRotation"));
                    Main.npc[num15].ai[1] = 288;
                    Main.npc[num15].ai[0] = npc.whoAmI;
                    Main.npc[num15].netUpdate = true;
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 93); //zap sound
                }
                if (npc.ai[0] == 80)
                {
                    float Speed = 12f;
                    Vector2 vector8 = new Vector2((npc.position.X + Main.rand.Next(-20, 21)) + (npc.width / 2), (npc.position.Y + Main.rand.Next(-20, 21)) + (npc.height / 2));
                    int damage = 30;  // projectile damage
                    int type = mod.ProjectileType("SpikeShot");  //put your projectile
                    float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                    npc.ai[0] = 0;
                }
                npc.ai[1] += 1;
                if (npc.ai[1] >= 400)
                {
                    npc.ai[1] = 0;
                    npc.ai[3] = 5;
                }
                if (!StarRocks)
                {
                    npc.ai[3] = 6;
                    npc.ai[1] = 0;
                    npc.ai[2] = 0;
                    npc.ai[0] = 0;
                }

            }
            if (npc.ai[3] == 5)
            {
                npc.velocity.X *= 0.5f;
                npc.velocity.Y *= 0.5f;
                npc.ai[0] += 1;
                npc.ai[1] += 1;
                if (npc.ai[0] >= 10)
                {
                    npc.ai[0] = 0;
                    npc.ai[2] += 20f;
                    float SpeedX = 12f;
                    float SpeedY = 12f;
                    Vector2 perturbedSpeed1 = new Vector2(SpeedX, SpeedY).RotatedBy(MathHelper.ToRadians(npc.ai[2]));
                    Vector2 vector8 = new Vector2((npc.position.X + Main.rand.Next(-20, 21)) + (npc.width / 2), (npc.position.Y + Main.rand.Next(-20, 21)) + (npc.height / 2));
                    int damage = 35;  // projectile damage
                    int type = mod.ProjectileType("StarRocket");  //put your projectile
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, perturbedSpeed1.X, perturbedSpeed1.Y, type, damage, 0f, Main.myPlayer);
                }
                if (npc.ai[1] >= 360)
                {
                    npc.ai[1] = 0;
                    npc.ai[2] += 120f;
                    npc.ai[3] = 4;
                }
            }
            if (npc.ai[3] == 6)
            {
                npc.ai[0] += 1;

                if (npc.ai[0] >= 55)
                {
                    npc.ai[1] += 1;
                    npc.ai[0] = 0;
                    Vector2 vector78 = new Vector2(npc.position.X + (float)(npc.width / 2) + (float)(Main.rand.Next(20) * npc.direction), npc.position.Y + (float)npc.height * 0.8f);
                    Vector2 vector79 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                    float num600 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector79.X;
                    float num601 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector79.Y;
                    float num602 = (float)Math.Sqrt((double)(num600 * num600 + num601 * num601));
                    bool flag39 = false;
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 93);
                    if (Main.netMode != 1)
                    {
                        float num603 = 18f;
                        if (Main.expertMode)
                        {
                            num603 += 3f;
                        }
                        float num604 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector78.X + (float)Main.rand.Next(-80, 81);
                        float num605 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector78.Y + (float)Main.rand.Next(-40, 41);
                        float num606 = (float)Math.Sqrt((double)(num604 * num604 + num605 * num605));
                        num606 = num603 / num606;
                        num604 *= num606;
                        num605 *= num606;
                        int num607 = 38;
                        int num608 = mod.ProjectileType("SpikeShot");
                        int num609 = Projectile.NewProjectile(vector78.X, vector78.Y, num604, num605, num608, num607, 0f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num609].timeLeft = 300;
                    }
                }
                if (npc.ai[1] >= 10)
                {
                    npc.ai[1] = 0;
                    npc.ai[0] = 0;
                    if (Main.rand.Next(2) == 0)
                    {
                        npc.ai[3] = 7;
                    }
                    else
                    {
                        npc.ai[3] = 8;
                    }
                }
            }
            if (npc.ai[3] == 7)
            {
                npc.ai[0] += 1;
                npc.ai[1] += 1;
                if (npc.ai[1] == 80)
                {
                    int num25;
                    for (int num154 = 0; num154 < 12; num154 = num25 + 1)
                    {
                        npc.ai[2] += 30;
                        Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 60);
                        float SpeedX = 12f;
                        float SpeedY = 12f;
                        Vector2 perturbedSpeed1 = new Vector2(SpeedX, SpeedY).RotatedBy(MathHelper.ToRadians(npc.ai[2]));
                        Vector2 vector8 = new Vector2((npc.position.X) + (npc.width / 2), (npc.position.Y) + (npc.height / 2));
                        int damage = 35;  // projectile damage
                        int type = mod.ProjectileType("StarRocket");  //put your projectile
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, perturbedSpeed1.X, perturbedSpeed1.Y, type, damage, 0f, Main.myPlayer);
                        num25 = num154;
                    }
                }
                if (npc.ai[1] == 40)
                {
                    float Speed = 12f;
                    Vector2 PlayerPosition = new Vector2(P.Center.X - npc.Center.X, P.Center.Y - npc.Center.Y);
                    PlayerPosition.Normalize();
                    npc.velocity = PlayerPosition * Speed;
                }
                if (npc.ai[0] >= 400)
                {
                    npc.ai[3] = 9;
                }
            }
            if (npc.ai[3] == 8)
            {
                npc.ai[3] = 9;
                if (npc.ai[1] >= 400)
                {
                    npc.ai[3] = 9;
                }
            }
            if (npc.ai[3] == 9)
            {
                npc.velocity.X *= 0.5f;
                npc.velocity.Y *= 0.5f;
                npc.ai[0] += 1;
                npc.ai[1] += 1;
                if (npc.ai[0] >= 80)
                {
                    npc.ai[0] = 0;
                    npc.ai[1] = 0;
                    npc.ai[2] = 0;
                    npc.ai[3] = 6;
                    Vector2 vector8 = new Vector2((npc.position.X + Main.rand.Next(-20, 21)) + (npc.width / 2), (npc.position.Y + Main.rand.Next(-20, 21)) + (npc.height / 2));
                    int damage = 35;  // projectile damage
                    int type = mod.ProjectileType("StarRocketSpawn");  //put your projectile
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, 0f, 0f, type, damage, 0f, Main.myPlayer);
                }
            }
        }
    }
}
//https://www.youtube.com/watch?v=b_eyzPf54j4 pass this shit to ricefield