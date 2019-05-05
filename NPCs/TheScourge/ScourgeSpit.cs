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
    public class ScourgeSpit : ModNPC
    {
        public override void SetDefaults()
        {

            npc.damage = 120;
            npc.npcSlots = 1f;
            npc.width = 18; //324
            npc.height = 18; //216
            npc.defense = 20;
            npc.lifeMax = 75;
            npc.aiStyle = -1; //new
            aiType = -1; //new
            npc.knockBackResist = 0f;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Toxic Spit");
        }
        bool randomized = false;
        public override bool PreAI()
        {
            if (!randomized)
            {
                randomized = true;
                npc.alpha += Main.rand.Next(1, 125);
                npc.rotation += Main.rand.Next(1, 361);
                npc.scale += Main.rand.NextFloat(-0.25f, 0.4f);
                npc.ai[2] += Main.rand.NextFloat(-37f, 36f);
                npc.ai[1] += Main.rand.NextFloat(1f, 361f);
            }
            if (npc.ai[3] == 0)
            {
                npc.ai[2] += 0.5f;
                if (npc.ai[2] >= 30f)
                {
                    
                    npc.ai[3] = 1;
                }
            }
            if (npc.ai[3] == 1)
            {
                npc.ai[2] -= 2.5f;
                if (npc.ai[2] <= 10f)
                {
                    npc.ai[3] = 0;
                }
            }

            npc.dontTakeDamage = true;
            npc.TargetClosest(true);
            Vector2 direction = Main.player[npc.target].Center - npc.Center;
            npc.rotation = direction.ToRotation();  //To make this i modified a projectile that orbits around the player, modified it and got it working.

            double deg = (double)npc.ai[1];
            double rad = deg * (Math.PI / 180);
            double dist = npc.ai[2];

            NPC p = Main.npc[(int)npc.ai[0]];
            npc.position.X = p.Center.X - (int)(Math.Cos(rad) * dist) - npc.width / 2;
            npc.position.Y = p.Center.Y - (int)(Math.Sin(rad) * dist) - npc.height / 2;
            if (p.life <= 0 || !p.active)
            {
                npc.active = false;
                npc.life = 0;
                npc.checkDead();
                npc.HitEffect();
            }
            if (Main.rand.Next(4) == 0)
            {
                npc.rotation += 0.08f;
                npc.ai[1] += 1f;
            }
                npc.rotation += 0.08f;
            npc.ai[1] += 1f;
            return false;
        }
    }
}