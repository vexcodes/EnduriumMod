	using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.CrescentMage
{
    public class CrescentMage : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Necrotic Mage");
        }
        public override void SetDefaults()
        {
            npc.CloneDefaults(NPCID.DarkCaster);
            npc.damage = 100;
            npc.lifeMax = 1000;
            npc.value = Terraria.Item.buyPrice(0, 0, 50, 0);
            animationType = NPCID.DarkCaster;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.DarkCaster];
            npc.aiStyle = -1; //new
            aiType = -1; //ne
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return EnduriumWorld.downedPhantasmShaman && Main.hardMode && Main.bloodMoon ? 0.1f : 0f;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.5f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.5f);
        }
        public override void AI()
        {
            npc.TargetClosest(true);
            npc.velocity.X = npc.velocity.X * 0.93f;
            if ((double)npc.velocity.X > -0.1 && (double)npc.velocity.X < 0.1)
            {
                npc.velocity.X = 0f;
            }
            if (npc.ai[0] == 0f)
            {
                npc.ai[0] = 500f;
            }
            if (npc.ai[2] != 0f && npc.ai[3] != 0f)
            {
                if (npc.type == 172)
                {
                    npc.alpha = 255;
                }
                Main.PlaySound(SoundID.Item8, npc.position);
                int num;
                for (int num68 = 0; num68 < 50; num68 = num + 1)
                {
                    int num76 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 242, 0f, 0f, 100, default(Color), 2.5f);
                    Dust dust3 = Main.dust[num76];
                    dust3.velocity *= 3f;
                    Main.dust[num76].noGravity = true;

                    num = num68;
                }
                npc.position.X = npc.ai[2] * 16f - (float)(npc.width / 2) + 8f;
                npc.position.Y = npc.ai[3] * 16f - (float)npc.height;
                npc.velocity.X = 0f;
                npc.velocity.Y = 0f;
                npc.ai[2] = 0f;
                npc.ai[3] = 0f;
                Main.PlaySound(SoundID.Item8, npc.position);
                for (int num77 = 0; num77 < 50; num77 = num + 1)
                {
                    int num85 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 242, 0f, 0f, 100, default(Color), 2.5f);
                    Dust dust3 = Main.dust[num85];
                    dust3.velocity *= 3f;
                    Main.dust[num85].noGravity = true;

                    num = num77;
                }
            }
            npc.ai[0] += 1f;
            if (npc.ai[0] == 100f || npc.ai[0] == 200f || npc.ai[0] == 300f)
            {
                npc.ai[1] = 30f;
                npc.netUpdate = true;
            }
            if (npc.ai[0] >= 650f && Main.netMode != 1)
            {
                npc.ai[0] = 1f;
                int num86 = (int)Main.player[npc.target].position.X / 16;
                int num87 = (int)Main.player[npc.target].position.Y / 16;
                int num88 = (int)npc.position.X / 16;
                int num89 = (int)npc.position.Y / 16;
                int num90 = 20;
                int num91 = 0;
                bool flag4 = false;
                if (Math.Abs(npc.position.X - Main.player[npc.target].position.X) + Math.Abs(npc.position.Y - Main.player[npc.target].position.Y) > 2000f)
                {
                    num91 = 100;
                    flag4 = true;
                }
                while (!flag4 && num91 < 100)
                {
                    int num = num91;
                    num91 = num + 1;
                    int num92 = Main.rand.Next(num86 - num90, num86 + num90);
                    int num93 = Main.rand.Next(num87 - num90, num87 + num90);
                    for (int num94 = num93; num94 < num87 + num90; num94 = num + 1)
                    {
                        if ((num94 < num87 - 4 || num94 > num87 + 4 || num92 < num86 - 4 || num92 > num86 + 4) && (num94 < num89 - 1 || num94 > num89 + 1 || num92 < num88 - 1 || num92 > num88 + 1) && Main.tile[num92, num94].nactive())
                        {
                            bool flag5 = true;
                            if (Main.tile[num92, num94 - 1].lava())
                            {
                                flag5 = false;
                            }
                            if (flag5 && Main.tileSolid[(int)Main.tile[num92, num94].type] && !Collision.SolidTiles(num92 - 1, num92 + 1, num94 - 4, num94 - 1))
                            {
                                npc.ai[1] = 20f;
                                npc.ai[2] = (float)num92;
                                npc.ai[3] = (float)num94;
                                flag4 = true;
                                break;
                            }
                        }
                        num = num94;
                    }
                }
                npc.netUpdate = true;
            }
            if (npc.ai[1] > 0f)
            {
                npc.ai[1] -= 1f;
                if (npc.ai[1] % 30f == 0f && npc.ai[1] / 30f < 5f)
                {
                    Main.PlaySound(SoundID.Item8, npc.position);
                    if (Main.netMode != 1)
                    {
                        Point point = npc.Center.ToTileCoordinates();
                        Point point2 = Main.player[npc.target].Center.ToTileCoordinates();
                        Vector2 vector12 = Main.player[npc.target].Center - npc.Center;
                        int num95 = 6;
                        int num96 = 6;
                        int num97 = 0;
                        int num98 = 2;
                        int num99 = 0;
                        bool flag6 = false;
                        if (vector12.Length() > 2000f)
                        {
                            flag6 = true;
                        }
                        while (!flag6)
                        {
                            if (num99 >= 50)
                            {
                                break;
                            }
                            int num = num99;
                            num99 = num + 1;
                            int num100 = Main.rand.Next(point2.X - num95, point2.X + num95 + 1);
                            int num101 = Main.rand.Next(point2.Y - num95, point2.Y + num95 + 1);
                            if ((num101 < point2.Y - num97 || num101 > point2.Y + num97 || num100 < point2.X - num97 || num100 > point2.X + num97) && (num101 < point.Y - num96 || num101 > point.Y + num96 || num100 < point.X - num96 || num100 > point.X + num96) && !Main.tile[num100, num101].nactive())
                            {
                                bool flag7 = true;
                                if (flag7 && Main.tile[num100, num101].lava())
                                {
                                    flag7 = false;
                                }
                                if (flag7 && Collision.SolidTiles(num100 - num98, num100 + num98, num101 - num98, num101 + num98))
                                {
                                    flag7 = false;
                                }
                                if (flag7)
                                {
                                    Projectile.NewProjectile((float)(num100 * 16 + 8), (float)(num101 * 16 + 8), 0f, 0f, mod.ProjectileType("NecroticBomb"), 20, 1f, Main.myPlayer, (float)npc.target, 1f);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 242, hitDirection, -1f, 0, default(Color), 1f);
            }
            if (npc.life <= 0)
            {
                for (int num621 = 0; num621 < 40; num621++)
                {
                    int num622 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 242, 0f, 0f, 100, default(Color), 1.4f);
                    Main.dust[num622].velocity *= 3f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[num622].scale = 0.5f;
                        Main.dust[num622].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                    }
                }
                for (int num623 = 0; num623 < 70; num623++)
                {
                    int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 242, 0f, 0f, 100, default(Color), 2.1f);
                    Main.dust[num624].noGravity = true;
                    Main.dust[num624].velocity *= 5f;
                }
            }
        }
        public override void NPCLoot()
        {
            if (Main.expertMode)
            {
                Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowRemnants"), Main.rand.Next(5, 10));

            }
            else
            {
                Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowRemnants"), Main.rand.Next(3, 8));
            }
        }
    }
}
						
						