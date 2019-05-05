using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.TheScourge
{
    public class TheScourge : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Scourge");
        }
        public override void SetDefaults()
        {
            npc.lifeMax = 100000;
            npc.width = 82;
            npc.height = 116;
            npc.damage = 60;
            npc.defense = 0;
            npc.HitSound = SoundID.NPCHit1;
            Main.npcFrameCount[npc.type] = 6;
            npc.DeathSound = SoundID.NPCDeath30;
            npc.knockBackResist = 0f;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Fury_of_the_Jungle");
            npc.noGravity = true;
            bossBag = mod.ItemType("JungleBag");
            npc.noTileCollide = true;
            npc.aiStyle = -1; //new
            aiType = -1; //new
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.5f * bossLifeScale);
            npc.damage = 75;
        }

        public override void FindFrame(int frameHeight)
        {
            if (npc.ai[3] == 0 || npc.ai[3] == 4)
            {
                npc.frame.Y = 0 * frameHeight;
            }
            if (npc.ai[3] == 1)
            {
                npc.frame.Y = 4 * frameHeight;
            }
            if (npc.ai[3] == 2)
            {
                npc.frame.Y = 5 * frameHeight;
            }
            if (npc.ai[3] == 3)
            {
                npc.frame.Y = 6 * frameHeight;
            }
        }

        public override void AI()
        {
            Player player = Main.player[npc.target];
            if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                player = Main.player[npc.target];
                if (!player.active || player.dead)
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
            if (npc.ai[3] == 0)
            {
                float movementACCX = 0.12f;
                float movementACCY = 0.23f;
                float movementCAPX = 11f;
                float movementCAPY = 14f;

                if (npc.velocity.Y >= movementCAPY)
                {
                    npc.velocity.Y = movementCAPY;
                }
                if (npc.velocity.Y <= -movementCAPY)
                {
                    npc.velocity.Y = -movementCAPY;
                }
                if (npc.velocity.X >= movementCAPX)
                {
                    npc.velocity.X = movementCAPX;
                }
                if (npc.velocity.X <= -movementCAPX)
                {
                    npc.velocity.X = -movementCAPX;
                }
                if (npc.position.Y > player.position.Y + 50f)
                {
                    npc.velocity.Y = npc.velocity.Y -= movementACCY;
                }
                else if (npc.position.Y < player.position.Y - 50f)
                {
                    npc.velocity.Y = npc.velocity.Y += movementACCY;
                }
                if (npc.position.X + (float)(npc.width / 2) > (player.position.X + (float)(player.width / 2)) + 50f)
                {
                    npc.velocity.X = npc.velocity.X -= movementACCX;
                }
                if (npc.position.X + (float)(npc.width / 2) < (player.position.X + (float)(player.width / 2)) - 50f)
                {
                    npc.velocity.X = npc.velocity.X += movementACCX;
                }


                npc.ai[0] += 1f;
                if (npc.ai[0] >= 280)
                {
                    npc.velocity *= 0.9f;
                }

                if (npc.ai[0] >= 300)
                {
                    npc.ai[0] = 0f;
                    npc.ai[3] = 1 + Main.rand.Next(0, 2);
                }

            }
            if (npc.ai[3] >= 1 && npc.ai[3] <= 3) //1-3 depending on these he launches a different amount of projectiles at a time
            {
                npc.ai[0] += 1f;
                npc.ai[1] += 1f;
                if (npc.ai[0] >= 60) //shoot projectile
                {
                    npc.ai[0] = 0;
                    for (int k = 0; k < npc.ai[3]; k++)
                    {
                        NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2) + npc.velocity.X), (int)(npc.position.Y - 60 + (float)(npc.height / 2) + npc.velocity.Y), mod.NPCType("ScourgeSpitNonOrbit"), npc.damage, 0f, 1f, 0f, 0f, 255);
                    }
                }
                if (npc.ai[1] >= 260)
                {
                    npc.ai[3] = 4;
                    npc.ai[1] = 0;
                    npc.ai[0] = 0;
                    npc.ai[2] = 0;
                }
            }

            if (npc.ai[3] == 10)
            {
                npc.velocity *= 0.9f;
                npc.ai[0] += 1f;
                if (npc.ai[0] >= 60)
                {
                    npc.ai[0] = 0f;
                    npc.ai[3] = 2;

                    for (int k = 0; k < 20; k++)
                    {
                        Dust.NewDust(npc.position, npc.width, npc.height, 3, 1f, 1f, 0, default(Color), 1f);
                        Dust.NewDust(npc.position, npc.width, npc.height, 24, 1f, 1f, 0, default(Color), 1f);
                    }
                    for (int g = 0; g < 5; g++)
                    {
                        Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheScourgeCloak_1"), 1f);
                        Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheScourgeCloak_2"), 1f);
                    }
                }
            }
            if (npc.ai[3] == 11)
            {
                if (npc.ai[1] >= 30)
                {
                    if (npc.ai[0] <= 0.02f)
                    {
                        npc.ai[0] += 0.00006666666f;
                    }
                }
                npc.ai[2] += npc.ai[0] / 5;
                if (npc.ai[1] >= 1)
                {
                    npc.ai[1] += 1f;
                }
                if (npc.ai[1] >= 620)
                {
                    npc.ai[3] = 3;
                    npc.ai[1] = 0;
                    npc.ai[0] = 0;
                    npc.ai[2] = 0;
                }
                if (npc.ai[1] == 0)
                {
                    npc.ai[1] = 1;
                    for (int num624 = 0; num624 < 15; num624++) //todo, basically make it so instead of doing the random code in ScourgeVine, do it here and then spawn 2 projectiles, one will basically act like a preview of where the vine will appear.
                    {
                        float RandomNum = Main.rand.NextFloat(1f, 361f);

                        int preview = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, mod.ProjectileType("ScourgeVinePreview"), npc.damage, 3f, Main.myPlayer, npc.whoAmI);
                        int vine = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, mod.ProjectileType("ScourgeVine"), npc.damage, 3f, Main.myPlayer, npc.whoAmI);
                        Main.projectile[preview].ai[1] = RandomNum;
                        Main.projectile[vine].ai[1] = RandomNum;
                    }
                }
            }
            if (npc.ai[3] == 12)
            {
                npc.ai[0] += 1f;
                if (npc.ai[0] >= 30)
                {
                    npc.ai[0] = 0f;
                    npc.ai[3] = 0;
                    for (int k = 0; k < 20; k++)
                    {
                        Dust.NewDust(npc.position, npc.width, npc.height, 3, 1f, 1f, 0, default(Color), 1f);
                        Dust.NewDust(npc.position, npc.width, npc.height, 24, 1f, 1f, 0, default(Color), 1f);
                    }
                }
            }
        }

        public override void NPCLoot()
        {
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TropicTooth"), Main.rand.Next(15, 25));
                int choice = Main.rand.Next(2);
                if (Main.rand.Next(3) == 0)
                {
                    if (choice == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("JungleHatchet"));
                    }

                    if (choice == 1)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RazorShot"));
                    }
                }
                if (Main.rand.Next(4) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SapSpray"));
                }
                if (Main.rand.Next(4) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ThornBlade"));
                }
                if (Main.rand.Next(4) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TheScourge"));
                }
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int k = 0; k < 10; k++)
            {
                int dust1 = Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("Plaugue"), hitDirection, -1f, 0, default(Color), 1f);
                Main.dust[dust1].noGravity = true;
            }
        }
    }
}