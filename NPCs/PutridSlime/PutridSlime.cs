using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.PutridSlime
{
    public class PutridSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Putrid Slime");
        }
		public override void SetDefaults()
		{
			npc.width = 32;
			npc.height = 22;
			npc.damage = 12;
			npc.defense = 6;
			npc.lifeMax = 40;
			npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.3f;
			npc.aiStyle = 1;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BlueSlime];
            aiType = NPCID.BlueSlime;
            animationType = NPCID.BlueSlime;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.6f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.6f);
        }


		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
			NPC.NewNPC((int)npc.position.X, (int)npc.position.Y + 5, mod.NPCType("PutridSlimeSmall"));
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y - 5, mod.NPCType("PutridSlimeSmall"));
			}
		}
		        public override void NPCLoot()
        {
            if (Main.rand.Next(3) == 0)
            {
                Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Gel, Main.rand.Next(1, 3));
            }
            if (Main.rand.Next(3) == 0)
            {
                Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Gel, Main.rand.Next(1, 3));
            }
            if (Main.rand.Next(3) == 0)
            {
                Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Gel, Main.rand.Next(1, 2));
            }
            if (Main.rand.Next(3) == 0)
            {
                Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Gel, Main.rand.Next(1, 2));
            }
            if (Main.rand.Next(3) == 0)
            {
                Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Gel);
            }
            if (Main.rand.Next(3) == 0)
            {
                Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Gel);
            }
            if (Main.rand.Next(4) == 0)
            {
                Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Gel);
            }
            Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PutridGel"), Main.rand.Next(1, 3));
             Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PutridSpore"), Main.rand.Next(1, 3));
     
		}
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.Cavern.Chance * 0.09f;
		}
    }
}