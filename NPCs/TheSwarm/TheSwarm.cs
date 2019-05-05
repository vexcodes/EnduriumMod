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
            npc.npcSlots = 1f;
            npc.width = 62; //324
            npc.height = 170; //216
            npc.defense = 20;
            npc.boss = true;
            npc.lifeMax = 20000;
            npc.aiStyle = -1; //new
            aiType = -1; //new
            npc.knockBackResist = 0f;
            Main.npcFrameCount[npc.type] = 12;
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
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn a gore
            {
                if (!EnduriumWorld.downedBio)
                {
                    EnduriumWorld.downedBio = true;
                }
            }
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.17f;
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
            npc.TargetClosest(true);
            Vector2 center = npc.Center;
            npc.ai[0]++;
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
            if (Main.player[npc.target].dead)
            {
                npc.active = false;
            }
            else
            {
                npc.timeLeft = 2;
            }
            npc.noGravity = true;
            if (npc.ai[3] == 0)
            {
                for (int num623 = 0; num623 < 15; num623++)
                {
                    int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 182, 0f, 0f, 20, default(Color), 1.2f);
                    Main.dust[num624].noGravity = true;
                    Main.dust[num624].velocity *= 1f;
                }
                Main.PlaySound(SoundID.Item62, npc.position); //summons 3 orbiting orbs around itself
                int num11 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("EarthenCrystal"));
                Main.npc[num11].ai[1] = 0;
                Main.npc[num11].ai[0] = npc.whoAmI;
                int num12 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("EarthenCrystal"));
                Main.npc[num12].ai[1] = 90;
                Main.npc[num12].ai[0] = npc.whoAmI;
                int num13 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("EarthenCrystal"));
                Main.npc[num13].ai[1] = 180;
                Main.npc[num13].ai[0] = npc.whoAmI;
                int num14 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("EarthenCrystal"));
                Main.npc[num14].ai[1] = 270;
                Main.npc[num14].ai[0] = npc.whoAmI;
                npc.netUpdate = true;

                npc.ai[3] = 1;
            }
        }
    }
}
						