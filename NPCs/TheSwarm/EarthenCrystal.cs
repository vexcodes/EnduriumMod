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
    public class EarthenCrystal : ModNPC
    {
        public override void SetDefaults()
        {

            npc.damage = 80;
            npc.npcSlots = 1f;
            npc.width = 22; //324
            npc.height = 44; //216
            npc.defense = 10;
            npc.lifeMax = 3000;
            npc.aiStyle = -1; //new
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
            npc.defense = 10;
        }
        float charge = 0f;
        public override bool PreAI()
        {
            npc.rotation = npc.velocity.X * 0.01f;
            if (npc.alpha >= 0)
            {
                npc.alpha -= 6;
            }
            if (charge <= 3f)
            {
                charge += 0.04f;
            }
            npc.TargetClosest(true);
            if (npc.ai[2] <= 110)
            {
                npc.ai[2] += 1;
            }
            double deg = (double)npc.ai[1];
            double rad = deg * (Math.PI / 180);
            double dist = npc.ai[2];
            NPC p = Main.npc[(int)npc.ai[0]];

            float num = 10f;
            float num2 = 0.6f;
            Vector2 vector = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
            double num4 = p.Center.X - (int)(Math.Cos(rad) * dist) - npc.width / 2;
            double num5 = p.Center.Y - (int)(Math.Sin(rad) * dist) - npc.height / 2;
            num4 = (float)((int)(num4 / 8f) * 8);
            num5 = (float)((int)(num5 / 8f) * 8);
            vector.X = (float)((int)(vector.X / 8f) * 8);
            vector.Y = (float)((int)(vector.Y / 8f) * 8);
            num4 -= vector.X;
            num5 -= vector.Y;
            float num6 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
            float num7 = num6;
            bool flag = false;
            if (num6 > 600f)
            {
                flag = true;
            }
            if (num6 == 0f)
            {
                num4 = npc.velocity.X;
                num5 = npc.velocity.Y;
            }
            else
            {
                num6 = num / num6;
                num4 *= num6;
                num5 *= num6;
            }
            if (Main.player[npc.target].dead)
            {
                num4 = (float)npc.direction * num / 2f;
                num5 = -num / 2f;
            }
            if (npc.velocity.X < num4)
            {
                npc.velocity.X = npc.velocity.X + num2;
            }
            else if (npc.velocity.X > num4)
            {
                npc.velocity.X = npc.velocity.X - num2;
            }
            if (npc.velocity.Y < num5)
            {
                npc.velocity.Y = npc.velocity.Y + num2;
            }
            else if (npc.velocity.Y > num5)
            {
                npc.velocity.Y = npc.velocity.Y - num2;
            }
            if (p.life <= 0 || !p.active)
            {
                npc.active = false;
                npc.life = 0;
                npc.checkDead();
                npc.HitEffect();
            }
            npc.ai[1] += charge;
            return false;
        }
    }
}