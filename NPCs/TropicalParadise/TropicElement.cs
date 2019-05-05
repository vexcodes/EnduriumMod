using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.TropicalParadise
{
    public class TropicElement : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tropic Element");
        }
        public override void SetDefaults()
        {
            npc.width = 46;
            npc.height = 24;
            npc.damage = 25;
            npc.defense = 10;
            npc.aiStyle = -1;
            npc.lifeMax = 80;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 60f;
            npc.knockBackResist = 0.3f;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.6f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.6f);
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.32f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        public override void AI()
        {
            Player player = Main.player[npc.target];
            if (player.Center.X > npc.Center.X)
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
            Vector2 vector102 = new Vector2(npc.Center.X, npc.Center.Y);
            float num791 = Main.player[npc.target].Center.X - vector102.X;
            float num792 = Main.player[npc.target].Center.Y - vector102.Y;
            float num793 = (float)Math.Sqrt((double)(num791 * num791 + num792 * num792));
            float num794 = 4f;
            num793 = num794 / num793;
            num791 *= num793;
            num792 *= num793;
            npc.velocity.X = (npc.velocity.X * 100f + num791) / 101f;
            npc.velocity.Y = (npc.velocity.Y * 100f + num792) / 101f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 44, hitDirection, -1f, 0, default(Color), 1f);
            }
            if (npc.life <= 0)
            {
                for (int h = 0; h < 3; h++)
                {
                    Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TropicalCrystal_Gore1"), 1f);
                    if (Main.rand.Next(2) == 0)
                    {
                        Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TropicalCrystal_Gore2"), 1f);
                    }
                    if (Main.rand.Next(2) == 0)
                    {
                        Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TropicalCrystal_Gore3"), 1f);
                    }

                    Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TropicMud_Gore1"), 1f);
                    if (Main.rand.Next(2) == 0)
                    {
                        Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TropicMud_Gore2"), 1f);
                    }
                    if (Main.rand.Next(2) == 0)
                    {
                        Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TropicMud_Gore3"), 1f);
                    }

                }
                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 44, hitDirection, -1f, 0, default(Color), 1f);
                }
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return Main.tile[(int)(spawnInfo.spawnTileX), (int)(spawnInfo.spawnTileY)].type == mod.TileType("TropicalSoil") ? 0.5f : 0f;
        }
        public override void NPCLoot()
        {
            Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("NatureEssence"), Main.rand.Next(1, 3));
        }
    }
}