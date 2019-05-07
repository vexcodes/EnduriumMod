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
    public class EarthenCrystalCopy : ModNPC
    {
        public override void SetDefaults()
        {

            npc.damage = 80;
            npc.npcSlots = 1f;
            npc.width = 22; //324
            npc.height = 44; //216
            npc.defense = 10;
            npc.lifeMax = 250;
            npc.aiStyle = -1; //new
            npc.alpha = 255;
            aiType = -1; //new
            npc.knockBackResist = 0.2f;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            Main.npcFrameCount[npc.type] = 7;
            npc.DeathSound = SoundID.NPCDeath6;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.24f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Earth Fragment");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.damage = 80;
            npc.defense = 25;
        }
        double dist = 80;
        public override bool PreAI()
        {
            npc.rotation = npc.velocity.X * 0.01f;
            Player p = Main.player[(int)npc.ai[0]];
            if (npc.alpha >= 100)
            {
                npc.alpha -= 8;
            }
            double deg = (double)npc.ai[1];
            double rad = deg * (Math.PI / 180);
            npc.ai[1] += 1;
            npc.position.X = p.Center.X - (int)(Math.Cos(rad) * dist) - npc.width / 2;
            npc.position.Y = p.Center.Y - (int)(Math.Sin(rad) * dist) - npc.height / 2;
            return false;
        }
    }
}