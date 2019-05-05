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
    public class PrismSpell2 : ModNPC
    {
        public override void SetDefaults()
        {

            npc.damage = 90;
            npc.npcSlots = 1f;
            npc.width = 16; //324
            npc.height = 16; //216
            npc.defense = 20;
            npc.lifeMax = 120;
            npc.aiStyle = -1; //new
            aiType = -1; //new
           npc.alpha = 255;
            npc.knockBackResist = 0f;
            npc.noGravity = true;
            npc.scale = 1.25f;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
        }
        float Speed = 12f;
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.damage = 100;
            npc.defense = 30;
            npc.lifeMax = 220;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prism Spell");
        }
        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            return false;
        }
        public override void AI()
        {
            npc.dontTakeDamage = true;
            Player player = Main.player[npc.target];
            Vector2 center = npc.Center;
            npc.ai[0]++;
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
            if (Main.player[npc.target].dead)
            {
                npc.active = false;
            }
            else
            {
                npc.timeLeft = 2;
            }
            if (npc.ai[0] == 1)
            {
                for (int num623 = 0; num623 < 15; num623++)
                {
                    int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 132, 0f, 0f, 100, default(Color), 1.6f);
                    Main.dust[num624].noGravity = true;
                    Main.dust[num624].velocity *= 4f;
                }
                Main.PlaySound(SoundID.Item62, npc.position);
                int num1 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 80, mod.NPCType("PrismRotate2"));
                Main.npc[num1].ai[1] = 90;
                Main.npc[num1].ai[0] = npc.whoAmI;
                int num2 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 80, mod.NPCType("PrismRotate2"));
                Main.npc[num2].ai[1] = 180;
                Main.npc[num2].ai[0] = npc.whoAmI;
                int num3 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 80, mod.NPCType("PrismRotate2"));
                Main.npc[num3].ai[1] = 270;
                Main.npc[num3].ai[0] = npc.whoAmI;
                int num4 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 80, mod.NPCType("PrismRotate2"));
                Main.npc[num4].ai[1] = 360;
                Main.npc[num4].ai[0] = npc.whoAmI;
                int num5 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 80, mod.NPCType("PrismRotate2"));
                Main.npc[num5].ai[1] = 45;
                Main.npc[num5].ai[0] = npc.whoAmI;
                int num6 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 80, mod.NPCType("PrismRotate2"));
                Main.npc[num6].ai[1] = 135;
                Main.npc[num6].ai[0] = npc.whoAmI;
                int num7 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 80, mod.NPCType("PrismRotate2"));
                Main.npc[num7].ai[1] = 225;
                Main.npc[num7].ai[0] = npc.whoAmI;
                int num8 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 80, mod.NPCType("PrismRotate2"));
                Main.npc[num8].ai[1] = 315;
                Main.npc[num8].ai[0] = npc.whoAmI;
            }
            npc.ai[2] += 1f;
            if (npc.ai[1] <= 12f)
            {
                npc.ai[1] = 12f;
            }
            Speed = npc.ai[1];
            if (npc.ai[1] >= 12f)
            {
                npc.ai[1] = 12f;
            }
            if (npc.ai[2] <= 20f)
            {
                Vector2 PlayerPositionno = new Vector2(player.Center.X - npc.Center.X, player.Center.Y - npc.Center.Y);
                PlayerPositionno.Normalize();
                npc.velocity = PlayerPositionno * Speed;
            }
        }
    }
}