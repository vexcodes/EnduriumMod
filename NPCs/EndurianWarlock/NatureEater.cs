using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.EndurianWarlock
{
    public class NatureEater : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Toxic Soul");
        }
        public override void SetDefaults()
        {
            npc.width = 44;
            npc.height = 22;
            npc.damage = 81;
            npc.defense = 14;
            npc.lifeMax = 500;
            npc.HitSound = SoundID.NPCHit5;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = Terraria.Item.buyPrice(0, 0, 1, 0);
            npc.knockBackResist = 0f;
            npc.aiStyle = 2;
            Main.npcFrameCount[npc.type] = 4;
            aiType = NPCID.DemonEye;
            animationType = NPCID.DemonEye;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.6f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.6f);
        }

        public override void NPCLoot()
        {
            Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkDust"), Main.rand.Next(8, 16));
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return Main.tile[(int)(spawnInfo.spawnTileX), (int)(spawnInfo.spawnTileY)].type == TileID.JungleGrass && Main.hardMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 ? 0.02f : 0f;
        }
    }
}