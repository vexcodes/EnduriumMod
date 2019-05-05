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

namespace EnduriumMod.NPCs.PrismMonolith
{
    public class ColdBlast : ModNPC
    {
        public override void SetDefaults()
        {

            npc.damage = 55;
            npc.npcSlots = 1f;
            npc.width = 92; //324
            npc.height = 102; //216
            npc.defense = 10;
            npc.lifeMax = 25;
            npc.aiStyle = -1; //new
            aiType = -1; //new
            npc.knockBackResist = 0f;
            npc.alpha = 25;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cold Bomb");
        }
        float rotationR = 0f;
        float scaleR = 0f;
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.16f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        public override bool PreAI()
        {
            if (npc.ai[0] == 0)
            {
                rotationR += Main.rand.NextFloat(0.01f, 0.08f);
                scaleR += Main.rand.NextFloat(0.01f, 0.03f);
                npc.ai[0] = 1;
            }
            npc.rotation += rotationR;
            npc.dontTakeDamage = true;
            if (npc.ai[3] >= 20)
            {
                if (npc.alpha <= 255)
                {
                    npc.alpha += 4;
                }
            }
            if (npc.ai[3] <= 15)
            {
                npc.scale += scaleR;
            }
            else
            {
                if (npc.scale >= 0.25f + scaleR)
                {
                    npc.scale -= scaleR;
                }
            }
            npc.ai[3] += 1;
            if (npc.ai[3] >= 120 || npc.alpha == 225)
            {
                npc.active = false;
                npc.life = 0;
                npc.checkDead();
                npc.HitEffect();
            }
            return false; 
        }
    }
}