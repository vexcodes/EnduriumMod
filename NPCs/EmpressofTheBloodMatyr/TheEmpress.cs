using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.EmpressofTheBloodMatyr
{
    public class TheEmpress : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Bloodmist Empress");
        }
        public override void SetDefaults()
        {
            npc.aiStyle = -5;
            npc.scale = 1.0f;
            npc.lifeMax = 750000;
            npc.damage = 100;
            npc.defense = 0;
            npc.knockBackResist = 0f;
            npc.width = 138;
            npc.height = 120;
            npc.value = Item.buyPrice(0, 20, 0, 0);
            npc.npcSlots = 1f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1; //57 //20
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[24] = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/The_Gatekeepers_Hell");
            npc.netAlways = true;
            bossBag = mod.ItemType("HarpyBag2");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 800000;
            npc.damage = 110;
        }
        public int A = 0;
        public int B = 0;
        public override void AI()
        {
            Player player = Main.player[npc.target];
            { 
                  if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }
            float num = 10f;
            float num2 = 0.1f;
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

            
            int num10 = (int)npc.position.X + npc.width / 2;
            int num11 = (int)npc.position.Y + npc.height / 2;
            num10 /= 16;
            num11 /= 16;
            float num12 = 0.7f;
            }
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }
            npc.ai[2] += 1;
            if (npc.ai[0] == 0)
            {
                if (npc.ai[1] == 0)
                {
                    
                    npc.ai[1] = 1;
                }
                if (npc.ai[1] == 1)
                {
                    if (npc.ai[2] >= 35)
                    {
                        float Speed = 10f;  // projectile speed
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 4), npc.position.Y + (npc.height / 4));
                        int damage = 25;  // projectile damage
                        int type = mod.ProjectileType("BloodmistBolt");  //put your projectile
                        float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                        npc.ai[2] = 0;
                        A += 1;
                    }
                    
                    if (A >= 10)
                    {
                        npc.ai[1] = 2;
                        A = 0;
                        B += 1;
                    }
                }
                if (npc.ai[1] == 2)
                {
                    if (npc.ai[2] == 55)
                    {
                        int numberProjectiles = 4 + Main.rand.Next(2); // 4 or 5 shots
                        for (int i = 0; i < numberProjectiles; i++)
                        {
                            Vector2 vector355 = new Vector2(npc.position.X + (float)npc.width * 0.8f - 4f, npc.position.Y + (float)npc.height * 0.7f);
                            Vector2 perturbedSpeed = new Vector2(npc.velocity.X, npc.velocity.Y).RotatedByRandom(MathHelper.ToRadians(10)); // 30 degree spread.                                                                                // perturbedSpeed = perturbedSpeed * scale; 
                            Projectile.NewProjectile(vector355.X, vector355.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("BloodmistBlast"), 26, 0f, Main.myPlayer);
                            npc.ai[2] = 0;
                            A += 1;
                        }
                        if (A >= 5)
                        {
                            B += 1;
                            A = 0;
                            if (B >= 5)
                            {
                                npc.ai[1] = 3;
                            }
                            else 
                            {
                               npc.ai[1] = 1;
                            }
                        }
                    }
                } 
                if (npc.ai[1] == 3)
                {
                    if (B >= 6)
                    {
                        npc.ai[1] = 4 + (float)Main.rand.Next(0, 2);
                    }
                    else
                    {
                        npc.ai[1] = 1;
                    }
                }

                if (npc.ai[1] == 4)
                {
                    if (npc.ai[2] >= 4)
                    {
                        float Speed = 20f;  // projectile speed
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 4), npc.position.Y + (npc.height / 4));
                        int damage = 25;  // projectile damage
                        int type = mod.ProjectileType("BloodmistBolt");  //put your projectile
                        float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                        npc.ai[2] = 0;
                        A += 1;
                    }
                    if (A >= 50)
                    {
                        npc.ai[1] = 1;
                    }
                }
                if (npc.ai[1] == 5)
                {
                    if (Main.rand.Next(4) == 0) //premission from IQ, owner of copper+ to use the code a while ago
                    {
                        float BGPx = npc.Center.X + 500;
                        float BGPy = npc.Center.Y + Main.rand.Next(4000) - 4000;
                        Projectile.NewProjectile(BGPx, BGPy, -10f, 0f, mod.ProjectileType("BloodmistSpike"), 20, 0f);
                        float BGPx2 = npc.Center.X - 500;
                        float BGPy2 = npc.Center.Y + Main.rand.Next(4000) - 4000;
                        Projectile.NewProjectile(BGPx2, BGPy2, 10f, 0f, mod.ProjectileType("BloodmistSpike"), 20, 0f);
                        A += 1;
                    }
                    if (A >= 50)
                    {
                        npc.ai[1] = 1;
                    }
                }
                if (npc.ai[1] == 6)
                {
                    if (npc.ai[2] >= 4)
                    {
                        int num11 = Main.rand.Next(2, 4);
                        for (int j = 0; j < num11; j++)
                        {
                            Vector2 vector5 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                            vector5 += npc.velocity * 3f;
                            vector5.Normalize();
                            vector5 *= (float)Main.rand.Next(35, 39) * 0.1f;
                          
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vector5.X, vector5.Y, mod.ProjectileType("BloodmistRotate1"), 10, 0f, 0);
                            A += 1;
                        }
                    }
                    if (A >= 50)
                    {
                        npc.ai[1] = 1;
                    }
                }
            }
            if (npc.ai[0] == 1)
            {

            }
        }
    }
}