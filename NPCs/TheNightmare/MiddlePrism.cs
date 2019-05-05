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

namespace EnduriumMod.NPCs.TheNightmare
{
    public class MiddlePrism : ModNPC
    {
        public override void SetDefaults()
        {

            npc.damage = 70;
            npc.npcSlots = 1f;
            npc.width = 14; //324
            npc.height = 26; //216
            npc.defense = 20;
            npc.lifeMax = 75;
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
            DisplayName.SetDefault("Middle Prism");
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn a gore
            {
                int num3;
                for (int num731 = 0; num731 < 12; num731 = num3 + 1)
                {
                    int num732 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 5, 0f, 0f, 100, default(Color), 2.5f);
                    Main.dust[num732].noGravity = true;
                    Dust dust = Main.dust[num732];
                    dust.velocity *= 5f;
                    num732 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 5, 0f, 0f, 100, default(Color), 1.5f);
                    dust = Main.dust[num732];
                    dust.velocity *= 2.5f;
                    num3 = num731;
                }
            }
        }
        public override bool PreAI()
        {
            if (npc.ai[0] == 0)
            {
                npc.ai[0] = 1;
                int num1 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("TopPrism")); //RED
                Main.npc[num1].ai[1] = 0;
                Main.npc[num1].ai[0] = npc.whoAmI;
                int num2 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("BottomRightPrism")); //BLUE
                Main.npc[num2].ai[1] = 120;
                Main.npc[num2].ai[0] = npc.whoAmI;
                int num3 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("BottomLeftPrism")); //GREEN
                Main.npc[num3].ai[1] = 240;
                Main.npc[num3].ai[0] = npc.whoAmI;
            }
            if (npc.ai[0] == 1)
            {
                int choice2 = Main.rand.Next(3);
                if (choice2 == 0)
                {
                    npc.ai[0] = 2;
                }
                if (choice2 == 1)
                {
                    npc.ai[0] = 3;
                }
                if (choice2 == 2)
                {
                    npc.ai[0] = 4;
                }
            }
            bool Top = NPC.AnyNPCs(mod.NPCType("TopPrism"));
            bool Right = NPC.AnyNPCs(mod.NPCType("BottomRightPrism"));
            bool Left = NPC.AnyNPCs(mod.NPCType("BottomLeftPrism"));
            int num003;
            float Speed = 18f;
            if (npc.ai[0] == 2) //top
            {
                if (!Top) //isnt a trap
                {
                    npc.active = false;
                    npc.life = 0;
                    npc.checkDead();
                    npc.HitEffect();
                    int num3;
                    for (int num731 = 0; num731 < 12; num731 = num3 + 1)
                    {
                        int num732 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 5, 0f, 0f, 100, default(Color), 2.5f);
                        Main.dust[num732].noGravity = true;
                        Dust dust = Main.dust[num732];
                        dust.velocity *= 5f;
                        num732 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 5, 0f, 0f, 100, default(Color), 1.5f);
                        dust = Main.dust[num732];
                        dust.velocity *= 2.5f;
                        num3 = num731;
                    }
                    return false;
                }
                if (!Left || !Right) //wrong
                {
                    npc.ai[0] = 5;
                }
                NPC p = Main.npc[NPC.FindFirstNPC(mod.NPCType("TopPrism"))];
                Vector2 PrismPosition = new Vector2(p.Center.X - npc.Center.X, p.Center.Y - npc.Center.Y);
                PrismPosition.Normalize();
                if (p.life >= 0 || !p.active)
                {
                    for (int num93 = 0; num93 < 2; num93 = num003 + 1)
                    {
                        int a = Dust.NewDust(npc.position, npc.width, npc.height, 182, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                        Main.dust[a].noGravity = true;
                        Main.dust[a].velocity = PrismPosition * Speed;
                        Main.dust[a].position = npc.Center;
                        Main.dust[a].scale *= 1f;
                        num003 = num93;
                    }
                }
            }
            if (npc.ai[0] == 3) //right
            {
                if (!Right) //pours milk after cereal
                {
                    npc.active = false;
                    npc.life = 0;
                    npc.checkDead();
                    npc.HitEffect();
                    int num3;
                    for (int num731 = 0; num731 < 12; num731 = num3 + 1)
                    {
                        int num732 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 5, 0f, 0f, 100, default(Color), 2.5f);
                        Main.dust[num732].noGravity = true;
                        Dust dust = Main.dust[num732];
                        dust.velocity *= 5f;
                        num732 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 5, 0f, 0f, 100, default(Color), 1.5f);
                        dust = Main.dust[num732];
                        dust.velocity *= 2.5f;
                        num3 = num731;
                    }
                    return false;
                }
                if (!Left || !Top) //wrong
                {
                    npc.ai[0] = 5;
                }
                NPC p = Main.npc[NPC.FindFirstNPC(mod.NPCType("BottomRightPrism"))];
                Vector2 PrismPosition = new Vector2(p.Center.X - npc.Center.X, p.Center.Y - npc.Center.Y);
                PrismPosition.Normalize();
                if (p.life >= 0 || p.active)
                {
                    for (int num93 = 0; num93 < 2; num93 = num003 + 1)
                    {
                        int a = Dust.NewDust(npc.position, npc.width, npc.height, 156, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                        Main.dust[a].noGravity = true;
                        Main.dust[a].velocity = PrismPosition * Speed;
                        Main.dust[a].position = npc.Center;
                        Main.dust[a].scale *= 1f;
                        num003 = num93;
                    }
                }
            }
            if (npc.ai[0] == 4) //left
            {
                if (!Left) // epic games
                {
                    npc.active = false;
                    npc.life = 0;
                    npc.checkDead();
                    npc.HitEffect();
                    int num3;
                    for (int num731 = 0; num731 < 12; num731 = num3 + 1)
                    {
                        int num732 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 5, 0f, 0f, 100, default(Color), 2.5f);
                        Main.dust[num732].noGravity = true;
                        Dust dust = Main.dust[num732];
                        dust.velocity *= 5f;
                        num732 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 5, 0f, 0f, 100, default(Color), 1.5f);
                        dust = Main.dust[num732];
                        dust.velocity *= 2.5f;
                        num3 = num731;
                    }
                    return false;
                }
                if (!Top || !Right) //wrong
                {
                    npc.ai[0] = 5;
                }
                NPC p = Main.npc[NPC.FindFirstNPC(mod.NPCType("BottomLeftPrism"))];
                Vector2 PrismPosition = new Vector2(p.Center.X - npc.Center.X, p.Center.Y - npc.Center.Y);
                PrismPosition.Normalize();

                if (p.life >= 0 || p.active)
                {
                    for (int num93 = 0; num93 < 2; num93 = num003 + 1)
                    {
                        int a = Dust.NewDust(npc.position, npc.width, npc.height, 89, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                        Main.dust[a].noGravity = true;
                        Main.dust[a].velocity = PrismPosition * Speed;
                        Main.dust[a].position = npc.Center;
                        Main.dust[a].scale *= 1f;
                        num003 = num93;
                    }
                }
            }
            if (npc.ai[0] == 5) //bad effect
            {
                npc.ai[1] += 1;
                if (npc.ai[1] >= 50)
                {
                    int num11 = Main.rand.Next(4, 5);
                    for (int j = 0; j < num11; j++)
                    {
                        Vector2 vector5 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                        vector5 += npc.velocity * 3f;
                        vector5.Normalize();
                        vector5 *= (float)Main.rand.Next(35, 39) * 0.1f;

                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vector5.X, vector5.Y, mod.ProjectileType("PlaguePursuit"), 30, 0f, 0);
                        npc.ai[1] = 0;
                    }
                    int num3;
                    for (int num731 = 0; num731 < 4; num731 = num3 + 1)
                    {
                        int num732 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 5, 0f, 0f, 100, default(Color), 2.5f);
                        Main.dust[num732].noGravity = true;
                        Dust dust = Main.dust[num732];
                        dust.velocity *= 5f;
                        num732 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 5, 0f, 0f, 100, default(Color), 1.5f);
                        dust = Main.dust[num732];
                        dust.velocity *= 2.5f;
                        num3 = num731;
                    }
                    npc.ai[1] = 0;
                    npc.ai[2] += 1;
                }
            }
            if (npc.ai[2] == 4)
            {
                npc.active = false;
                npc.life = 0;
                npc.checkDead();
                npc.HitEffect();
                int num3;
                for (int num731 = 0; num731 < 4; num731 = num3 + 1)
                {
                    int num732 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 5, 0f, 0f, 100, default(Color), 2.5f);
                    Main.dust[num732].noGravity = true;
                    Dust dust = Main.dust[num732];
                    dust.velocity *= 5f;
                    num732 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 5, 0f, 0f, 100, default(Color), 1.5f);
                    dust = Main.dust[num732];
                    dust.velocity *= 2.5f;
                    num3 = num731;
                }
            }
            npc.dontTakeDamage = true;
            return false;
        }
    }
}