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

namespace EnduriumMod.NPCs.TheSwarm
{
    public class EarthenCrystal : ModNPC
    {
        public override void SetDefaults()
        {

            npc.damage = 80;
            npc.npcSlots = 1f;
            npc.width = 22; //324
            npc.height = 44; //216
            npc.defense = 10;
            npc.lifeMax = 3000;
            npc.aiStyle = -1; //new
            aiType = -1; //new
            npc.knockBackResist = 0.2f;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            Main.npcFrameCount[npc.type] = 7;
            npc.DeathSound = SoundID.NPCDeath6;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.24f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Earth Fragment");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.damage = 80;
            npc.defense = 10;
        }
        double dist = 110;
        public override bool PreAI()
        {
            Player player = Main.player[npc.target];
            npc.TargetClosest(true);
            npc.rotation = npc.velocity.X * 0.01f;
            if (npc.alpha >= 0)
            {
                npc.alpha -= 6;
            }
            NPC p = Main.npc[(int)npc.ai[0]];
            double deg = (double)npc.ai[1]; 
            double rad = deg * (Math.PI / 180);

            npc.position.X = p.Center.X - (int)(Math.Cos(rad) * dist) - npc.width / 2;
            npc.position.Y = p.Center.Y - (int)(Math.Sin(rad) * dist) - npc.height / 2;
            if (p.ai[3] == 2 || p.ai[3] == 3)
            {
                if (dist < 200)
                {
                    dist += 1;
                }
                if (dist >= 200)
                {
                    npc.ai[2] += 1;
                    if (npc.ai[2] >= 60)
                    {
                        p.ai[1] += 1;
                        npc.ai[2] = 0;
                        if (p.ai[3] == 2)
                        {
                            float Speed = 8f;  // projectile speed
                            Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                            int damage = 30;  // projectile damage
                            int type = mod.ProjectileType("PlaguePursuit");  //put your projectile
                            float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                            int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                        }
                        if (p.ai[3] == 3)
                        {
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
                            int num152 = 35;
                            int num25;
                            for (int num154 = 0; num154 < 3; num154 = num25 + 1)
                            {
                                num148 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector23.X;
                                num150 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector23.Y;
                                num151 = (float)Math.Sqrt((double)(num148 * num148 + num150 * num150));
                                num151 = 12f / num151;
                                num148 += (float)Main.rand.Next(-100, 101);
                                num150 += (float)Main.rand.Next(-100, 101);
                                num148 *= num151;
                                num150 *= num151;
                                Projectile.NewProjectile(vector23.X, vector23.Y, num148, num150, mod.ProjectileType("PlagueEnergy"), 30, 0f, Main.myPlayer, 0f, 0f);
                                num25 = num154;
                            }
                        }
                    }
                }
            }
            else
            {
                if (dist > 110)
                {
                    dist -= 1;
                }
            }
            if (p.life <= 0 || !p.active)
            {
                npc.active = false;
                npc.life = 0;
                npc.checkDead();
                npc.HitEffect();
            }
            npc.ai[1] += 1f;
            return false;
        }
    }
}