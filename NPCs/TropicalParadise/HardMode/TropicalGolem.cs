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

namespace EnduriumMod.NPCs.TropicalParadise.HardMode
{
    public class TropicalGolem : ModNPC
    {
        public override void SetDefaults()
        {

            npc.damage = 90;
            npc.npcSlots = 5f;
            npc.width = 214; //324
            npc.height = 270; //216
            npc.defense = 10;
            npc.lifeMax = 8000;
            npc.aiStyle = 14;
            aiType = NPCID.CaveBat;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.value = Item.buyPrice(0, 5, 0, 0);
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath6;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tropical Golem");
            Main.npcFrameCount[npc.type] = 7;
        }
        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TropicalFragment"), Main.rand.Next(2, 4));
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return Main.tile[(int)(spawnInfo.spawnTileX), (int)(spawnInfo.spawnTileY)].type == TileID.JungleGrass && Main.hardMode ? 0.009f : 0f;
        }
        public override void AI()
        {
            Player player = Main.player[npc.target];
            if (player.Center.X > npc.Center.X)
            {
                npc.spriteDirection = 1;
            }
            else
            {
                npc.spriteDirection = 2;
            }

            if (Main.netMode != 1)
            {
                npc.ai[0] += 1;
                if (npc.ai[0] >= 225)
                {
                    Vector2 vector23 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                    float num147 = 11f;
                    float num148 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector23.X;
                    float num149 = Math.Abs(num148) * 0.1f;
                    float num150 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector23.Y - num149;
                    float num151 = (float)Math.Sqrt((double)(num148 * num148 + num150 * num150));
                    npc.netUpdate = true;
                    num151 = num147 / num151;
                    num148 *= num151;
                    num150 *= num151;
                    int num152 = 35;
                    int num153 = 82;
                    npc.ai[0] = 0;
                    int num25;
                    for (int num154 = 0; num154 < 4; num154 = num25 + 1)
                    {
                        num148 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector23.X;
                        num150 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector23.Y;
                        num151 = (float)Math.Sqrt((double)(num148 * num148 + num150 * num150));
                        num151 = 12f / num151;
                        num148 += (float)Main.rand.Next(-40, 41);
                        num150 += (float)Main.rand.Next(-40, 41);
                        num148 *= num151;
                        num150 *= num151;
                        Projectile.NewProjectile(vector23.X, vector23.Y, num148, num150, mod.ProjectileType("StoneFeather"), num152, 0f, Main.myPlayer, 0f, 0f);
                        num25 = num154;
                    }
                }
            }
            return;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.07f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
    }
}