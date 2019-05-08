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

namespace EnduriumMod.NPCs.TheScourge
{
    public class ScourgeRune : ModNPC
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
            npc.DeathSound = SoundID.NPCDeath6;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Toxic Rune");
        }
        double dist = 360;
        public override bool PreAI()
        {
            npc.dontTakeDamage = true;
            npc.rotation = npc.velocity.X * 0.01f;
            Player p = Main.player[(int)npc.ai[0]];
            if (npc.ai[2] == 0)
            {
                if (dist > 200)
                {
                    dist -= 2;
                }
                if (dist <= 210)
                {
                    if (Main.rand.Next(60) == 0)
                    {
                        npc.ai[2] = 1;
                    }
                }
                if (npc.alpha >= 100)
                {
                    npc.alpha -= 8;
                }
                double deg = (double)npc.ai[1];
                double rad = deg * (Math.PI / 180);
                npc.ai[1] += 3;
                npc.position.X = p.Center.X - (int)(Math.Cos(rad) * dist) - npc.width / 2;
                npc.position.Y = p.Center.Y - (int)(Math.Sin(rad) * dist) - npc.height / 2;
                return false;
            }
            if (npc.ai[2] == 1)
            {
                npc.ai[2] = 2;
                npc.velocity = Vector2.Normalize(p.Center - npc.Center) * 10;
            }
            return false;
        }
    }
}