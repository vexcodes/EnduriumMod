using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.PrismMonolith
{
    public class PrismCrystal : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tortured Soul");
        }
				        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
        	target.AddBuff(mod.BuffType("Shiver"), 50);
        }
        public override void SetDefaults()
        {
            npc.width = 46;
            npc.height = 34;
            npc.damage = 40;
            npc.defense = 6;
            npc.lifeMax = 600;
            npc.HitSound = SoundID.NPCHit5;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = Terraria.Item.buyPrice(0, 0, 1, 0);
            npc.knockBackResist = 0f;
            npc.aiStyle = 2;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.DemonEye];
            aiType = NPCID.DemonEye;
            animationType = NPCID.DemonEye;     
        }
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneSnow && EnduriumWorld.downedPrismArcanum || NPC.downedBoss3 && spawnInfo.player.ZoneSnow ? 0.09f : 0f;
        }
				        public override void NPCLoot()
        {
										          			if (Main.rand.Next(20) == 0)
                {
                    
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OddGemstone"));
                    
                }
                Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceEnergy"), Main.rand.Next(2, 4));
            Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PrismShard"), Main.rand.Next(2, 4));
        }
    }
}