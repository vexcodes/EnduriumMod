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
    public class PrismRotate2 : ModNPC
    {
        public override void SetDefaults()
        {

            npc.damage = 70;
            npc.npcSlots = 1f;
            npc.width = 14; //324
            npc.height = 26; //216
            npc.defense = 20;
            npc.lifeMax = 75;
            npc.aiStyle = -1; //new
            aiType = -1; //new
            npc.knockBackResist = 0f;
            npc.alpha = 255;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prism Spell");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.damage = 80;
            npc.defense = 40;
            npc.lifeMax = 125;
        }

        float charge = 0f;
        public override bool PreAI()
        {
            npc.dontTakeDamage = true;

            if (npc.alpha >= 0)
            {
                npc.alpha -= 6;
            }
            npc.TargetClosest(true);
            Vector2 direction = Main.player[npc.target].Center - npc.Center;
            npc.rotation = direction.ToRotation();  //To make this i modified a projectile that orbits around the player, modified it and got it working.
            if (npc.ai[2] <= 100)
            {
                npc.ai[2] += 1;
            }
            double deg = (double)npc.ai[1];
            double rad = deg * (Math.PI / 180);
            double dist = npc.ai[2];
            NPC p = Main.npc[(int)npc.ai[0]];
            npc.position.X = p.Center.X - (int)(Math.Cos(rad) * dist) - npc.width / 2;
            npc.position.Y = p.Center.Y - (int)(Math.Sin(rad) * dist) - npc.height / 2;
            if (charge <= 5f)
            {
                charge += 0.08f;
            }
            if (p.life <= 0 || !p.active)
            {
                npc.active = false;
                npc.life = 0;
                npc.checkDead();
                npc.HitEffect();
            }
            npc.rotation += 0.04f;
            npc.ai[1] += charge;
            return false;
        }
    }
}