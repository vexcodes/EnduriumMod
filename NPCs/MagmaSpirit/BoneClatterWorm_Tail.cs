using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.MagmaSpirit
{
    public class BoneClatterWorm_Tail : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Magma Devourer");
        }
        public override void SetDefaults()
        {
            npc.damage = 30; //70
            npc.npcSlots = 5f;
            npc.width = 32; //324
            npc.height = 32; //216
            npc.lifeMax = 800; //250000
            npc.aiStyle = 6; //new
            Main.npcFrameCount[npc.type] = 1;
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
            if (Main.hardMode)
            {
                npc.lifeMax = 1600;
            }
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