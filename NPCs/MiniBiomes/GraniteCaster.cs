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

namespace EnduriumMod.NPCs.MiniBiomes
{
    public class GraniteCaster : ModNPC
    {
        public float shoot = 0f;

        public override void SetDefaults()
        {
            npc.damage = 20;
            npc.npcSlots = 5f;
            npc.width = 44;
            npc.height = 56;
            npc.defense = 10;
            npc.lifeMax = 100;
            npc.aiStyle = -1;
            npc.knockBackResist = 0.5f;
            Main.npcFrameCount[npc.type] = 1;
            for (int k = 0; k < npc.buffImmune.Length; k++)
            {
                npc.buffImmune[k] = true;
            }
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Caster");
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.15f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }

        public override void AI()
        {
            Player P = Main.player[npc.target];
            if (!P.active || P.dead)
            {
                npc.TargetClosest(false);
                P = Main.player[npc.target];
                if (!P.active || P.dead)
                {
                    npc.velocity = new Vector2(0f, -10f);
                    if (npc.timeLeft > 150)
                    {
                        npc.timeLeft = 150;
                    }
                    return;
                }
            }
            else if (npc.timeLeft > 1800)
            {
                npc.timeLeft = 1800;
            }
            if (P.Center.X > npc.Center.X)
            {
                npc.spriteDirection = 1;
            }
            else
            {
                npc.spriteDirection = 2;
            }
            bool expertMode = Main.expertMode;
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }
            if (npc.ai[2] <= 125)
            {

                float num = 4f;
                float num2 = 0.12f;
                Vector2 vector = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                float num4 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2);
                float num5 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2);
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
            }
            else
            {
                npc.velocity.X *= 0.9f;
                npc.velocity.Y *= 0.9f;
            }
            npc.ai[2] += 1;
            if (npc.ai[2] == 185)
            {
                npc.ai[2] = 0;
                int num11 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("GraniteRotation"));
                Main.npc[num11].ai[1] = 0;
                Main.npc[num11].ai[0] = npc.whoAmI;
                Main.npc[num11].netUpdate = true;
                int num12 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("GraniteRotation"));
                Main.npc[num12].ai[1] = 120;
                Main.npc[num12].ai[0] = npc.whoAmI;
                Main.npc[num12].netUpdate = true;
                int num13 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("GraniteRotation"));
                Main.npc[num13].ai[1] = 240;
                Main.npc[num13].ai[0] = npc.whoAmI;
                Main.npc[num13].netUpdate = true;
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 156, hitDirection, -1f, 0, default(Color), 1f);
            }
            if (npc.life <= 0)
            {
                for (int num621 = 0; num621 < 40; num621++)
                {
                    int num622 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 156, 0f, 0f, 100, default(Color), 2f);
                    Main.dust[num622].velocity *= 3f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[num622].scale = 0.5f;
                        Main.dust[num622].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                    }
                }
                for (int num623 = 0; num623 < 70; num623++)
                {
                    int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 156, 0f, 0f, 100, default(Color), 3f);
                    Main.dust[num624].noGravity = true;
                    Main.dust[num624].velocity *= 5f;
                    num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 156, 0f, 0f, 100, default(Color), 2f);
                    Main.dust[num624].velocity *= 2f;
                }
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            Tile tile = Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY];
            return (tile.type == 368) && !spawnInfo.playerInTown && !spawnInfo.player.ZoneTowerStardust && !spawnInfo.player.ZoneTowerSolar && !spawnInfo.player.ZoneTowerVortex && !spawnInfo.player.ZoneTowerNebula ? 0.3f : 0f;
        }
        public override void NPCLoot()
        {
            if (NPC.downedBoss1)
            {
                Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GraniteScale"), Main.rand.Next(6, 10));
            }
            Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GraniteEnergyCore"), Main.rand.Next(6, 12));
            if (NPC.downedBoss2)
            {
                if (Main.rand.Next(20) == 0)
                {
                    Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ThunderStrike"));
                }
            }
        }
    }
}