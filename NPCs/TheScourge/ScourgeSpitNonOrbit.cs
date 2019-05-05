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
    public class ScourgeSpitNonOrbit : ModNPC
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
        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            return false;
        }
        bool hasSummoned = false;
        public override void AI()
        {
            npc.dontTakeDamage = true;
            Player player = Main.player[npc.target];
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
            int num;
            if (!hasSummoned)
            {
                Vector2 PlayerPosition = new Vector2(player.Center.X + Main.rand.Next(-150, 151) - npc.Center.X, player.Center.Y + Main.rand.Next(-150, 151) - npc.Center.Y);
                PlayerPosition.Normalize();
                npc.velocity = PlayerPosition * 12f;
                npc.ai[0] = 1;
                hasSummoned = true;
                for (int num623 = 0; num623 < 15; num623++)
                {
                    int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 89, 0f, 0f, 100, default(Color), 1.6f);
                    Main.dust[num624].noGravity = true;
                    Main.dust[num624].velocity *= 4f;
                }
                for (int num624 = 0; num624 < 15; num624++)
                {
                    int num1 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("ScourgeSpit"));
                    Main.npc[num1].ai[0] = npc.whoAmI;
                }
            }
            else if (npc.ai[1] == 1f && Main.netMode != 1)
            {
                int num3 = -1;
                float num4 = 2000f;
                for (int k = 0; k < 255; k = num + 1)
                {
                    if (Main.player[k].active && !Main.player[k].dead)
                    {
                        Vector2 center = Main.player[k].Center;
                        float num5 = Vector2.Distance(center, npc.Center);
                        if ((num5 < num4 || num3 == -1) && Collision.CanHit(npc.Center, 1, 1, center, 1, 1))
                        {
                            num4 = num5;
                            num3 = k;
                        }
                    }
                    num = k;
                }
                if (num3 != -1)
                {
                    npc.ai[1] = 21f;
                    npc.ai[0] = (float)num3;
                    npc.netUpdate = true;
                }
            }
            else if (npc.ai[1] > 20f && npc.ai[1] < 200f)
            {
                npc.ai[1] += 1f;
                int num6 = (int)npc.ai[0];
                if (!Main.player[num6].active || Main.player[num6].dead)
                {
                    npc.ai[1] = 1f;
                    npc.ai[0] = 0f;
                    npc.netUpdate = true;
                }
                else
                {
                    float num7 = npc.velocity.ToRotation();
                    Vector2 vector2 = Main.player[num6].Center - npc.Center;
                    float targetAngle = vector2.ToRotation();
                    if (vector2 == Vector2.Zero)
                    {
                        targetAngle = num7;
                    }
                    float num8 = num7.AngleLerp(targetAngle, 0.008f);
                    npc.velocity = new Vector2(npc.velocity.Length(), 0f).RotatedBy((double)num8, default(Vector2));
                }
            }
            if (npc.ai[1] >= 1f && npc.ai[1] < 20f)
            {
                npc.ai[1] += 1f;
                if (npc.ai[1] == 20f)
                {
                    npc.ai[1] = 1f;
                }
            }
            if (npc.ai[1] == 0)
            {
                npc.ai[1] = 1;
            }
        }
    }
}