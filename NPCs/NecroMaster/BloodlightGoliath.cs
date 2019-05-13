using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.NecroMaster
{
    public class BloodlightGoliath : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloodlight Goliath");
        }
        public override void SetDefaults()
        {
            npc.damage = 40;
            npc.npcSlots = 1f;
            npc.width = 72; //324
            npc.height = 62; //216
            npc.defense = 10;
            npc.value = 600f;
            npc.lifeMax = 500;
            npc.knockBackResist = 0f;
            Main.npcFrameCount[npc.type] = 4;
            npc.value = Item.buyPrice(0, 4, 0, 0);
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = Main.npcTexture[npc.type];
            var effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(texture, npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame, drawColor, npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
            Texture2D glowmask = mod.GetTexture("NPCs/NecroMaster/BloodlightGoliath_Glow");
            spriteBatch.Draw(glowmask, npc.Center - Main.screenPosition, npc.frame, npc.GetAlpha(Color.White), npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
            return false;
        }
        public override void NPCLoot()
        {
            if (Main.expertMode)
            {
                int choice = Main.rand.Next(4);
                if (choice == 0)
                {
                    Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TheGoliath"));
                }

                if (choice == 1)
                {
                    Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Contagion"));
                }

                if (choice == 2)
                {
                    Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PlagueHeart"));
                }

                if (choice == 3)
                {
                    Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FleshCrown"));
                }
                Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BloodDust"), Main.rand.Next(18, 26));

            }
            Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BloodDust"), Main.rand.Next(6, 26));
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return Main.bloodMoon && !NPC.AnyNPCs(mod.NPCType("BloodlightGoliath")) ? 0.013f : 0f;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.5f * bossLifeScale);
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.16f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
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
                npc.spriteDirection = -1;
            }
            bool expertMode = Main.expertMode;
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }
            if (num1 == 0)
            {
                num2 += 1;
                num3 += 1;
                npc.aiStyle = 22;
                if (num3 >= 75)
                {
                    num3 = 0;
                    float Speed = 5f;  // projectile speed
                    if (Main.rand.Next(2) == 0 && Main.netMode != 1)
                    {
                        Vector2 vector8 = new Vector2(npc.Center.X, npc.Center.Y);
                        int damage = 14;  // projectile damage
                        int type = mod.ProjectileType("BloodRedBolt");  //put your projectile
                        float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                        npc.netUpdate = true;
                    }
                    else if (Main.netMode != 1)
                    {
                        Vector2 vector8 = new Vector2(npc.Center.X, npc.Center.Y + npc.height / 2);
                        int damage = 14;  // projectile damage
                        int type = mod.ProjectileType("BloodYellowBolt");  //put your projectile
                        float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                        npc.netUpdate = true;
                    }
                    Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 21);
                }
                if (num2 >= 400)
                {
                    npc.ai[0] = 0;
                    npc.ai[1] = 0;
                    npc.ai[2] = 0;
                    npc.ai[3] = 0;
                    num1 = 1;
                    num2 = 0;
                    num3 = 0;
                }
            }
            if (num1 == 1)
            {


                if (npc.alpha > 0)
                {
                    npc.alpha -= 30;
                    if (npc.alpha < 0)
                    {
                        npc.alpha = 0;
                    }
                }
                npc.noGravity = true;
                npc.noTileCollide = true;
                npc.knockBackResist = 0f;
                int num;
                if (npc.ai[0] == 0f)
                {
                    npc.TargetClosest(true);
                    npc.ai[0] = 1f;
                    npc.ai[1] = (float)npc.direction;
                }
                else if (npc.ai[0] == 1f)
                {
                    npc.TargetClosest(true);
                    float num1289 = 0.65f;
                    float num1290 = 9f;
                    float num1291 = 6.5f;
                    float num1292 = 560f;
                    float num1293 = 4f;
                    npc.velocity.X = npc.velocity.X + npc.ai[1] * num1289;
                    if (npc.velocity.X > num1290)
                    {
                        npc.velocity.X = num1290;
                    }
                    if (npc.velocity.X < -num1290)
                    {
                        npc.velocity.X = -num1290;
                    }
                    float num0004 = Main.player[npc.target].Center.Y - 400;
                    float num1294 = num0004 - npc.Center.Y;
                    if (Math.Abs(num1294) > num1291)
                    {
                        num1293 = 15f;
                    }
                    if (num1294 > num1291)
                    {
                        num1294 = num1291;
                    }
                    else if (num1294 < -num1291)
                    {
                        num1294 = -num1291;
                    }
                    npc.velocity.Y = (npc.velocity.Y * (num1293 - 1f) + num1294) / num1293;
                    if ((npc.ai[1] > 0f && Main.player[npc.target].Center.X - npc.Center.X < -num1292) || (npc.ai[1] < 0f && Main.player[npc.target].Center.X - npc.Center.X > num1292))
                    {
                        npc.ai[0] = 2f;
                        npc.ai[1] = 0f;
                        if (npc.Center.Y + 20f > Main.player[npc.target].Center.Y - 150)
                        {
                            npc.ai[1] = -1f;
                        }
                        else
                        {
                            npc.ai[1] = 1f;
                        }
                    }
                }
                else if (npc.ai[0] == 2f)
                {
                    float num1295 = 0.4f;
                    float scaleFactor13 = 0.55f;
                    float num1296 = 4.5f;
                    npc.velocity.Y = npc.velocity.Y + npc.ai[1] * num1295;
                    if (npc.velocity.Length() > num1296)
                    {
                        npc.velocity *= scaleFactor13;
                    }
                    if (npc.velocity.X > -1f && npc.velocity.X < 1f)
                    {
                        npc.TargetClosest(true);
                        npc.ai[0] = 3f;
                        npc.ai[1] = (float)npc.direction;
                    }
                }
                else if (npc.ai[0] == 3f)
                {
                    float num1297 = 0.8f;
                    float num1298 = 0.65f;
                    float num1299 = 8f;
                    float scaleFactor14 = 0.75f;
                    npc.velocity.X = npc.velocity.X + npc.ai[1] * num1297;
                    if (npc.Center.Y > Main.player[npc.target].Center.Y - 130)
                    {
                        npc.velocity.Y = npc.velocity.Y - num1298;
                    }
                    else
                    {
                        npc.velocity.Y = npc.velocity.Y + num1298;
                    }
                    if (npc.velocity.Length() > num1299)
                    {
                        npc.velocity *= scaleFactor14;
                    }
                    if (npc.velocity.Y > -1f && npc.velocity.Y < 1f)
                    {
                        npc.TargetClosest(true);
                        npc.ai[0] = 0f;
                        npc.ai[2] += 1;
                        npc.ai[1] = (float)npc.direction;
                    }
                }
                num2 += 1;
                num3 += 1;
                npc.aiStyle = -1;
                if (num2 >= 120)
                {
                    npc.ai[0] = 0;
                    npc.ai[1] = 0;
                    npc.ai[2] = 0;
                    npc.ai[3] = 0;
                    num1 = 0;
                    num2 = 0;
                    num3 = 0;
                }
                if (num3 >= 55)
                {
                    Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 21);
                    npc.netUpdate = true;
                    Vector2 vector23 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                    float num147 = 12f;
                    float num148 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector23.X;
                    float num149 = Math.Abs(num148) * 0.1f;
                    float num150 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector23.Y - num149;
                    float num151 = (float)Math.Sqrt((double)(num148 * num148 + num150 * num150));
                    npc.netUpdate = true;
                    num151 = num147 / num151;
                    num148 *= num151;
                    num150 *= num151;
                    int num152 = 6;
                    int num25;
                    int faggot = mod.ProjectileType("BloodYellowBolt");

                    for (int num154 = 0; num154 < 4; num154 = num25 + 1)
                    {
                        if (Main.rand.Next(2) == 0 && Main.netMode != 1)
                        {
                            faggot = mod.ProjectileType("BloodRedBolt");
                        }
                        num148 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector23.X;
                        num150 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector23.Y;
                        num151 = (float)Math.Sqrt((double)(num148 * num148 + num150 * num150));
                        num151 = 12f / num151;
                        num148 += (float)Main.rand.Next(-100, 101);
                        num150 += (float)Main.rand.Next(-100, 101);
                        num148 *= num151;
                        num150 *= num151;
                        Projectile.NewProjectile(vector23.X, vector23.Y, num148, num150, faggot, num152, 0f, Main.myPlayer, 0f, 0f);
                        num25 = num154;
                    }
                    num3 = 0;
                }
            }
        }
                public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn a gore
            {
                EnduriumWorld.downedPhantasmShaman = true;   //so the message and the ore spawn does not proc(show) when you kill EoC/npc again
            }
        }
    }
}