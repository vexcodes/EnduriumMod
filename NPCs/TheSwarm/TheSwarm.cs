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

namespace EnduriumMod.NPCs.TheSwarm
{
    public class TheSwarm : ModNPC
    {
        public override void SetDefaults()
        {

            npc.damage = 90;
            npc.npcSlots = 0.5f;
            npc.width = 62; //324
            npc.height = 180; //216
            npc.defense = 20;
            npc.boss = true;
            npc.lifeMax = 20000;
            npc.aiStyle = -1; //new
            aiType = -1; //new
            npc.knockBackResist = 0f;
            Main.npcFrameCount[npc.type] = 14;
            npc.value = Item.buyPrice(0, 20, 0, 0);
            npc.noGravity = true;
            npc.scale = 1.25f;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            bossBag = mod.ItemType("BiologicalBag");
            npc.DeathSound = SoundID.NPCDeath6;
            music = MusicID.Boss4;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.damage = 100;
            npc.defense = 30;
            npc.lifeMax = 30000;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.2f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        public override void NPCLoot()
        {

            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BioScale"), Main.rand.Next(15, 25));
                int choice = Main.rand.Next(2);
                if (Main.rand.Next(3) == 0)
                {
                    if (choice == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EarthBuster"));
                    }

                    if (choice == 1)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EarthMagnum"));
                    }
                }
                if (Main.rand.Next(4) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BiologicalMarine"));
                }
                if (Main.rand.Next(4) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SporeCleaver"));
                }
                if (Main.rand.Next(4) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ThePlague"));
                }
            }
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Earth Elemental");
        }
        public override void AI()
        {
            Player player = Main.player[npc.target];
            bool IsInBiome = player.ZoneJungle;

            bool MinionsDead = NPC.AnyNPCs(mod.NPCType("EarthenCrystal"));

            bool PlayerThings = NPC.AnyNPCs(mod.NPCType("EarthenCrystalCopy"));

            bool Phase2 = (double)npc.life <= (double)npc.lifeMax * 0.9;
            bool Phase3 = (double)npc.life <= (double)npc.lifeMax * 0.75;
            bool Phase4 = (double)npc.life <= (double)npc.lifeMax * 0.5;
            bool Phase5 = (double)npc.life <= (double)npc.lifeMax * 0.25;
            bool Phase6 = (double)npc.life <= (double)npc.lifeMax * 0.1;

            npc.TargetClosest(true);
            if (Main.player[npc.target].dead)
            {
                npc.active = false;
            }
            else
            {
                npc.timeLeft = 2;
            }

            npc.noGravity = true;
            npc.TargetClosest(true);
            float num697 = 4f;
            float num698 = 0.25f;
            Vector2 vector90 = new Vector2(npc.Center.X, npc.Center.Y);
            float num699 = Main.player[npc.target].Center.X - vector90.X;
            float num700 = Main.player[npc.target].Center.Y - vector90.Y;
            float num701 = (float)Math.Sqrt((double)(num699 * num699 + num700 * num700));
            if (npc.ai[0] >= 280)
            {
                if (npc.ai[3] != 2 && npc.ai[3] != 3)
                {
                    if (num701 < 20f)
                    {
                        if (Main.netMode != 1)
                        {
                            num699 = npc.velocity.X;
                            num700 = npc.velocity.Y;
                        }
                    }
                    else
                    {
                        if (Main.netMode != 1)
                        {
                            num701 = num697 / num701;
                            num699 *= num701;
                            num700 *= num701;
                        }
                    }
                    if (npc.velocity.X < num699)
                    {
                        if (Main.netMode != 1)
                        {
                            npc.netUpdate = true;
                            npc.velocity.X = npc.velocity.X + num698;
                            if (npc.velocity.X < 0f && num699 > 0f)
                            {
                                npc.velocity.X = npc.velocity.X + num698 * 2f;
                            }
                        }
                    }
                    else if (npc.velocity.X > num699)
                    {
                        if (Main.netMode != 1)
                        {
                            npc.netUpdate = true;
                            npc.velocity.X = npc.velocity.X - num698;
                            if (npc.velocity.X > 0f && num699 < 0f)
                            {
                                npc.velocity.X = npc.velocity.X - num698 * 2f;
                            }
                        }
                    }
                    if (npc.velocity.Y < num700)
                    {
                        if (Main.netMode != 1)
                        {
                            npc.netUpdate = true;
                            npc.velocity.Y = npc.velocity.Y + num698;
                            if (npc.velocity.Y < 0f && num700 > 0f)
                            {
                                npc.velocity.Y = npc.velocity.Y + num698 * 2f;
                            }
                        }
                    }
                    else if (npc.velocity.Y > num700)
                    {
                        if (Main.netMode != 1)
                        {
                            npc.netUpdate = true;
                            npc.velocity.Y = npc.velocity.Y - num698;
                            if (npc.velocity.Y > 0f && num700 < 0f)
                            {
                                npc.velocity.Y = npc.velocity.Y - num698 * 2f;
                            }
                        }
                    }
                }
            }
            else
            {
                npc.velocity *= 0.94f;
            }
            npc.ai[0]++;
            if (Phase2)
            {
                if (npc.ai[0] >= 280)
                {
                    npc.ai[0] += 0.4f;
                }
            }
            if (Phase3)
            {
                if (npc.ai[0] >= 280)
                {
                    npc.ai[0] += 0.4f;
                }
            }
            if (Phase4)
            {
                if (npc.ai[0] >= 280)
                {
                    npc.ai[0] += 0.4f;
                }
            }
            if (Phase5)
            {
                if (npc.ai[0] >= 280)
                {
                    npc.ai[0] += 0.4f;
                }
                if (Main.expertMode)
                {
                    if (!MinionsDead)
                    {
                        npc.dontTakeDamage = false;
                    }
                    if (MinionsDead)
                    {
                        npc.dontTakeDamage = true;
                        npc.localAI[1] = 1;
                    }
                    else if (npc.localAI[1] == 0)
                    {
                        npc.ai[0] = 0;
                        npc.localAI[1] = 1;
                    }
                }
            }
            if (Phase6)
            {
                if (npc.ai[0] >= 280)
                {
                    npc.ai[0] += 0.4f;
                }
            }
            
            if (Main.expertMode)
            {
                if (Main.netMode != 1)
                {
                    if (npc.ai[0] == 1)
                    {
                        int num1 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 80, mod.NPCType("EarthenCrystal"));
                        Main.npc[num1].ai[0] = npc.whoAmI;
                        Main.npc[num1].netUpdate = true;
                    }
                    if (npc.ai[0] == 91)
                    {
                        int num2 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 80, mod.NPCType("EarthenCrystal"));
                        Main.npc[num2].ai[0] = npc.whoAmI;
                        Main.npc[num2].netUpdate = true;
                    }
                    if (npc.ai[0] == 181)
                    {
                        int num3 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 80, mod.NPCType("EarthenCrystal"));
                        Main.npc[num3].ai[0] = npc.whoAmI;
                        Main.npc[num3].netUpdate = true;
                    }
                    if (npc.ai[0] == 271)
                    {
                        int num4 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 80, mod.NPCType("EarthenCrystal"));
                        Main.npc[num4].ai[0] = npc.whoAmI;
                        Main.npc[num4].netUpdate = true;
                    }
                }
            }
            npc.noGravity = true;
            npc.TargetClosest(true);
            if (Main.netMode != 1)
            {
                if (npc.localAI[3] > 0f)
                {
                    npc.localAI[3] -= 1f;
                }
                if (npc.justHit && npc.localAI[3] <= 0f && Main.rand.Next(5) == 0)
                {
                    npc.localAI[3] = 32f;
                    int num44 = Main.rand.Next(3, 6);
                    int[] array = new int[num44];
                    int num45 = 0;
                    int num25;
                    for (int num46 = 0; num46 < 255; num46 = num25 + 1)
                    {
                        if (Main.player[num46].active && !Main.player[num46].dead && Collision.CanHitLine(npc.position, npc.width, npc.height, Main.player[num46].position, Main.player[num46].width, Main.player[num46].height))
                        {
                            array[num45] = num46;
                            num25 = num45;
                            num45 = num25 + 1;
                            if (num45 == num44)
                            {
                                break;
                            }
                        }
                        num25 = num46;
                    }
                    if (num45 > 1)
                    {
                        for (int num47 = 0; num47 < 100; num47 = num25 + 1)
                        {
                            int num48 = Main.rand.Next(num45);
                            int num49;
                            for (num49 = num48; num49 == num48; num49 = Main.rand.Next(num45))
                            {
                            }
                            int num50 = array[num48];
                            array[num48] = array[num49];
                            array[num49] = num50;
                            num25 = num47;
                        }
                    }
                    Vector2 vector12 = new Vector2(-1f, -1f);
                    for (int num51 = 0; num51 < num45; num51 = num25 + 1)
                    {
                        Vector2 value5 = Main.npc[array[num51]].Center - npc.Center;
                        value5.Normalize();
                        vector12 += value5;
                        num25 = num51;
                    }
                    vector12.Normalize();
                    for (int num52 = 0; num52 < num44; num52 = num25 + 1)
                    {
                        float scaleFactor4 = (float)Main.rand.Next(8, 13);
                        Vector2 vector13 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                        vector13.Normalize();
                        if (num45 > 0)
                        {
                            vector13 += vector12;
                            vector13.Normalize();
                        }
                        vector13 *= scaleFactor4;
                        if (num45 > 0)
                        {
                            num25 = num45;
                            num45 = num25 - 1;
                            vector13 = Main.player[array[num45]].Center - npc.Center;
                            vector13.Normalize();
                            vector13 *= scaleFactor4;
                        }
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vector13.X, vector13.Y, mod.ProjectileType("PlagueEnergy"), (int)((double)npc.damage * 0.15), 1f, 255, 0f, 0f);
                        num25 = num52;
                    }
                }
            }
            if (npc.ai[3] == 0 || npc.ai[3] == 1)
            {
                if (npc.ai[0] == 320 && !MinionsDead)
                {
                    if (Main.netMode != 1)
                    {
                        if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].head))
                        {
                            npc.netUpdate = true;
                            float Speed = 5f;  // projectile speed
                            Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                            int damage = 30;  // projectile damage
                            int type = mod.ProjectileType("StoneFossil");  //put your projectile
                            float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                            int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                        }
                    }
                }
            }
            if (npc.ai[3] == 0)
            {
                if (npc.ai[0] >= 360)
                {
                    if (Main.netMode != 1)
                    {
                        if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].head))
                        {
                            npc.netUpdate = true;
                            float Speed = 8f;  // projectile speed
                            Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                            int damage = 30;  // projectile damage
                            int type = mod.ProjectileType("PlagueEnergy");  //put your projectile
                            float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                            int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                        }
                    }
                    npc.ai[1] += 1;
                    npc.ai[0] = 300;
                }
                if (npc.ai[1] >= 4)
                {
                    npc.ai[0] = 280;
                    npc.ai[1] = 0;
                    if (npc.ai[2] != 2)
                    {
                        npc.ai[3] = 1;
                    }
                    else
                    {
                        npc.ai[3] = 4;
                    }
                }
            }
            if (npc.ai[3] == 1)
            {
                if (npc.ai[0] >= 360)
                {
                    if (Main.netMode != 1)
                    {
                        if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].head))
                        {
                            npc.netUpdate = true;
                            float Speed = 8f;  // projectile speed
                            Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                            int damage = 30;  // projectile damage
                            int type = mod.ProjectileType("StoneFossil");  //put your projectile
                            float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                            int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                        }
                    }
                    npc.ai[1] += 1;
                    npc.ai[0] = 300;
                }
                if (npc.ai[1] >= 4)
                {
                    npc.ai[0] = 280;
                    npc.ai[1] = 0;
                    if (npc.ai[2] == 0)
                    {
                        npc.ai[3] = 2;
                    }
                    else
                    {
                        npc.ai[3] = 3;
                    }
                }
            }
            if (npc.ai[3] == 2)
            {
                npc.velocity *= 0.9f;
                if (!MinionsDead)
                {
                    if (Main.netMode != 1)
                    {
                        if (npc.ai[0] == 360)
                        {
                            npc.netUpdate = true;
                            Vector2 vector23 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                            float num147 = 12f;
                            float num148 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector23.X;
                            float num149 = Math.Abs(num148) * 0.1f;
                            float num150 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector23.Y - num149;
                            float num151 = (float)Math.Sqrt((double)(num148 * num148 + num150 * num150));
                            npc.netUpdate = true;
                            num151 = num147 / num151;
                            num148 *= num151;
                            num150 *= num151;
                            int num152 = 35;
                            int num25;
                            for (int num154 = 0; num154 < 5; num154 = num25 + 1)
                            {
                                num148 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector23.X;
                                num150 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector23.Y;
                                num151 = (float)Math.Sqrt((double)(num148 * num148 + num150 * num150));
                                num151 = 12f / num151;
                                num148 += (float)Main.rand.Next(-100, 101);
                                num150 += (float)Main.rand.Next(-100, 101);
                                num148 *= num151;
                                num150 *= num151;
                                Projectile.NewProjectile(vector23.X, vector23.Y, num148, num150, mod.ProjectileType("PlagueEnergy"), 30, 0f, Main.myPlayer, 0f, 0f);
                                num25 = num154;
                            }
                        }
                    }
                    if (npc.ai[0] >= 380)
                    {
                        npc.ai[1] = 1;
                    }
                }
                if (npc.ai[1] >= 1)
                {
                    npc.ai[0] = 280;
                    npc.ai[3] = 0;
                    npc.ai[1] = 0;
                    npc.ai[2] += 1;
                }
            }
            if (npc.ai[3] == 3)
            {
                npc.velocity *= 0.9f;
                if (!MinionsDead)
                {
                    if (npc.ai[0] == 360)
                    {
                        npc.netUpdate = true;
                        Vector2 vector23 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                        float num147 = 12f;
                        float num148 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector23.X;
                        float num149 = Math.Abs(num148) * 0.1f;
                        float num150 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector23.Y - num149;
                        float num151 = (float)Math.Sqrt((double)(num148 * num148 + num150 * num150));
                        npc.netUpdate = true;
                        num151 = num147 / num151;
                        num148 *= num151;
                        num150 *= num151;
                        int num152 = 35;
                        int num25;
                        for (int num154 = 0; num154 < 5; num154 = num25 + 1)
                        {
                            num148 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector23.X;
                            num150 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector23.Y;
                            num151 = (float)Math.Sqrt((double)(num148 * num148 + num150 * num150));
                            num151 = 12f / num151;
                            num148 += (float)Main.rand.Next(-100, 101);
                            num150 += (float)Main.rand.Next(-100, 101);
                            num148 *= num151;
                            num150 *= num151;
                            Projectile.NewProjectile(vector23.X, vector23.Y, num148, num150, mod.ProjectileType("PlagueEnergy"), 30, 0f, Main.myPlayer, 0f, 0f);
                            num25 = num154;
                        }
                    }
                    if (npc.ai[0] >= 380)
                    {
                        npc.ai[1] = 1;
                    }
                }
                if (npc.ai[1] >= 1)
                {
                    npc.ai[0] = 280;
                    npc.ai[3] = 0;
                    npc.ai[2] += 1;
                    npc.ai[1] = 0;
                }
            }
            if (npc.ai[3] == 4)
            {
                npc.ai[0] += 1;
                if (npc.ai[0] >= 500)
                {
                    if (!PlayerThings)
                    {
                        int num1 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 80, mod.NPCType("EarthenCrystalCopy"));
                        Main.npc[num1].ai[0] = player.whoAmI;
                        Main.npc[num1].ai[1] = 90;
                        int num2 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 80, mod.NPCType("EarthenCrystalCopy"));
                        Main.npc[num2].ai[0] = player.whoAmI;
                        Main.npc[num2].ai[1] = 180;
                        int num3 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 80, mod.NPCType("EarthenCrystalCopy"));
                        Main.npc[num3].ai[0] = player.whoAmI;
                        Main.npc[num3].ai[1] = 270;
                        int num4 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 80, mod.NPCType("EarthenCrystalCopy"));
                        Main.npc[num4].ai[0] = player.whoAmI;
                        Main.npc[num4].ai[1] = 360;
                    }
                    npc.ai[0] = 300;
                    npc.ai[3] = 0;
                    npc.ai[2] = 0;
                    npc.ai[1] = 0;
                }
            }
        }
    }
}
						