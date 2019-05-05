using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.StarInfection
{
    public class StarParasite_Tail : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Planet Parasite");
        }
        public override void SetDefaults()
        {
            npc.damage = 100; //70
            npc.npcSlots = 5f;
            npc.width = 38; //324
            npc.height = 34; //216
            npc.defense = 6;
            npc.lifeMax = 42000; //250000
            npc.aiStyle = 6; //new
            aiType = -1; //new
            npc.knockBackResist = 0f;
            npc.behindTiles = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.Item14;
            npc.netAlways = true;
            npc.dontCountMe = true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }

        public override void AI()
        {
            bool expertMode = Main.expertMode;
            if (!Main.npc[(int)npc.ai[1]].active)
            {
                npc.life = 0;
                npc.HitEffect(0, 10.0);
                npc.active = false;
            }
        }

        public override bool CheckActive()
        {
            return false;
        }

        public override bool PreNPCLoot()
        {
            return false;
        }
    }
}