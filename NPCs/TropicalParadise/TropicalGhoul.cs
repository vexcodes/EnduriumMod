using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.TropicalParadise
{
    public class TropicalGhoul : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tropical Ghoul");
        }
        public override void SetDefaults()
        {

            npc.damage = 40;
            npc.npcSlots = 1f;
            npc.width = 32; //324
            npc.height = 42; //216
            npc.defense = 10;
            npc.value = 600f;
            npc.lifeMax = 120;
            npc.aiStyle = 14; //new
            npc.knockBackResist = 0f;
            npc.alpha = 90;
            Main.npcFrameCount[npc.type] = 4;
            npc.value = Item.buyPrice(0, 1, 0, 0);
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return Main.tile[(int)(spawnInfo.spawnTileX), (int)(spawnInfo.spawnTileY)].type == mod.TileType("TropicalSoil") && NPC.downedBoss1 ? 0.3f : 0f;
        }
        public override void NPCLoot()
        {
            Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("NatureEssence"), Main.rand.Next(1, 3));
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0 && Main.netMode != 1)
            {
                for (int h = 0; h < 3; h++)
                {
                    Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TropicalCrystal_Gore1"), 1f);
                    if (Main.rand.Next(2) == 0)
                    {
                        Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TropicalCrystal_Gore2"), 1f);
                    }
                    if (Main.rand.Next(2) == 0)
                    {
                        Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TropicalCrystal_Gore3"), 1f);
                    }

                    Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TropicMud_Gore1"), 1f);
                    if (Main.rand.Next(2) == 0)
                    {
                        Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TropicMud_Gore2"), 1f);
                    }
                    if (Main.rand.Next(2) == 0)
                    {
                        Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TropicMud_Gore3"), 1f);
                    }

                }

                int num414 = (int)(npc.position.X);
                Main.PlaySound(SoundID.Item62, npc.position);
                int num415 = (int)(npc.position.Y);
                Projectile.NewProjectile((float)num414, (float)num415, 0f, 0f, mod.ProjectileType("PowerOverflow"), 45, 0f, Main.myPlayer);
                npc.netUpdate = true;
                Main.PlaySound(SoundID.Item10, npc.position);
            }
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.18f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        int num1;
        public override void AI()
        {
            Player player = Main.player[npc.target];
            npc.rotation = npc.velocity.X / 35f;
            int num001;
            int num1300 = 10;
            for (int num1301 = 0; num1301 < 1; num1301 = num001 + 1)
            {
                int num1302 = Dust.NewDust(npc.position - new Vector2((float)num1300), npc.width + num1300 * 2, npc.height + num1300 * 2, 89, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num1302].noGravity = true;
                Main.dust[num1302].noLight = true;
                num001 = num1301;
            }
            if (player.Center.X > npc.Center.X)
            {
                npc.spriteDirection = 1;
            }
            else
            {
                npc.spriteDirection = 2;
            }
            int num;
            num1 += 1;
            if (num1 >= 280)
            {
                if (Main.netMode != 1)
                {
                    Main.PlaySound(SoundID.Item28, npc.position);
                    for (int num1446 = 0; num1446 < 20; num1446 = num + 1)
                    {
                        int num1447 = Dust.NewDust(npc.position, npc.width, npc.height, 89, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f, 0, default(Color), 1.5f);
                        Main.dust[num1447].noGravity = true;
                        Main.dust[num1447].fadeIn = 1f;
                        Dust dust3 = Main.dust[num1447];
                        dust3.velocity *= 4f;
                        Main.dust[num1447].noLight = true;
                        num = num1446;
                    }
                    if (npc.life < npc.lifeMax)
                    {
                        npc.HealEffect(10, false);
                        npc.netUpdate = true;
                        npc.life += 10;
                    }
                    npc.netUpdate = true;
                    Vector2 PlayerPosition = new Vector2(player.Center.X - npc.Center.X, player.Center.Y - npc.Center.Y);
                    PlayerPosition.Normalize();
                    npc.velocity = PlayerPosition * 5f;
                    num1 = 0;
                }
            }
            return;
        }
    }
}