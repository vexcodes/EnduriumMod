using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.ShadowStorm
{
    public class RuneGhoul : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rune Ghoul");
        }
        public override void SetDefaults()
        {

            npc.damage = 40;
            npc.npcSlots = 1f;
            npc.width = 32; //324
            npc.height = 46; //216
            npc.defense = 10;
            npc.value = 600f;
            npc.lifeMax = 240;
            npc.aiStyle = 14; //new
            npc.knockBackResist = 0f;
            npc.alpha = 90;
            Main.npcFrameCount[npc.type] = 4;
            npc.value = Item.buyPrice(0, 1, 0, 0);
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            Tile tile = Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY];
            return spawnInfo.player.ZoneOverworldHeight && !Main.dayTime && !Main.bloodMoon && !spawnInfo.playerInTown && !spawnInfo.player.ZoneTowerStardust && !spawnInfo.player.ZoneTowerSolar && !spawnInfo.player.ZoneTowerVortex && !spawnInfo.player.ZoneTowerNebula && NPC.downedBoss1 ? 0.07f : 0f;

        }
        public override void NPCLoot()
        {
            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ErodedPrism"));
            }
            if (Main.rand.Next(25) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowGauntlet"));
            }
            Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RuneofFear"), Main.rand.Next(3, 5));
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.24f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        int num1;
        public override void AI()
        {
            Player player = Main.player[npc.target];
            npc.rotation = npc.velocity.X / 30f;
            int num001;
            int num1300 = 10;
            for (int num1301 = 0; num1301 < 1; num1301 = num001 + 1)
            {
                int num1302 = Dust.NewDust(npc.position - new Vector2((float)num1300), npc.width + num1300 * 2, npc.height + num1300 * 2, 173, 0f, 0f, 100, default(Color), 1f);
                Main.dust[num1302].noGravity = true;
                Main.dust[num1302].noLight = true;
                num001 = num1301;
            }
            if (player.Center.X > npc.Center.X)
            {
                npc.spriteDirection = 1;
            }
            else
            {
                npc.spriteDirection = 2;
            }
            int num;
            num1 += 1;
            if (num1 >= 220)
            {
                npc.netUpdate = true;
                if (Main.netMode != 1)
                {
                    Main.PlaySound(SoundID.Item28, npc.position);
                    for (int num1446 = 0; num1446 < 20; num1446 = num + 1)
                    {
                        int num1447 = Dust.NewDust(npc.position, npc.width, npc.height, 173, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f, 90, default(Color), 1.5f);
                        Main.dust[num1447].noGravity = true;
                        Main.dust[num1447].fadeIn = 1f;
                        Dust dust3 = Main.dust[num1447];
                        dust3.velocity *= 4f;
                        Main.dust[num1447].noLight = true;
                        num = num1446;
                    }
                    Vector2 PlayerPosition = new Vector2(player.Center.X - npc.Center.X, player.Center.Y - npc.Center.Y);
                    PlayerPosition.Normalize();
                    npc.velocity = PlayerPosition * 9f;
                    num1 = 0;
                }
            }
            return;
        }
    }
}