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
    public class ColdBomb : ModNPC
    {
        public override void SetDefaults()
        {

            npc.damage = 120;
            npc.npcSlots = 1f;
            npc.width = 16; //324
            npc.height = 26; //216
            npc.defense = 10;
            npc.lifeMax = 25;
            npc.aiStyle = -1; //new
            aiType = -1; //new
            npc.knockBackResist = 0f;
            npc.alpha = 255;
            npc.noGravity = true;
            Main.npcFrameCount[npc.type] = 4;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cold Bomb");
        }
        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            return false;
        }
        float charge = 0f;
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.16f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        public override bool PreAI()
        {
            npc.dontTakeDamage = true;
            if (npc.alpha >= 0)
            {
                npc.alpha -= 6;
            }
            npc.ai[3] += 1;
            if (npc.ai[3] >= 360)
            {
                npc.active = false;
                npc.life = 0;
                npc.checkDead();
                npc.HitEffect();
                int num1 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y + 28, mod.NPCType("ColdBlast"));
                for (int num623 = 0; num623 < 5; num623++)
                {
                    int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 132, 0f, 0f, 100, default(Color), 1.6f);
                    Main.dust[num624].noGravity = true;
                    Main.dust[num624].velocity *= 4f;
                }
                Main.PlaySound(SoundID.Item62, npc.position);
            }
            npc.TargetClosest(true);
            Vector2 vector102 = new Vector2(npc.Center.X, npc.Center.Y);
            float num791 = Main.player[npc.target].Center.X - vector102.X;
            float num792 = Main.player[npc.target].Center.Y - vector102.Y;
            float num793 = (float)Math.Sqrt((double)(num791 * num791 + num792 * num792));
            float num794 = 20f;
            num793 = num794 / num793;
            num791 *= num793;
            num792 *= num793;
            npc.velocity.X = (npc.velocity.X * 100f + num791) / 101f;
            npc.velocity.Y = (npc.velocity.Y * 100f + num792) / 101f;   
            return false;
        }
    }
}