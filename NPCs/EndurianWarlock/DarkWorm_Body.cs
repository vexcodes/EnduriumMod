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
    public class DarkWorm_Body : ModNPC
    {
        public int spawn = 5;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Soul Devourer");
        }
        public override void SetDefaults()
        {
            npc.damage = 90; //70
            npc.npcSlots = 5f;
            npc.width = 22; //324
            npc.height = 20; //216
            npc.defense = 9999;
            npc.lifeMax = 2500; //250000
            npc.aiStyle = 6; //new
            Main.npcFrameCount[npc.type] = 1;
            aiType = -1; //new
            animationType = 10; //new
            npc.knockBackResist = 0f;
            npc.behindTiles = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit4;
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
            Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 0.2f, 0.05f, 0.2f);
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