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

namespace EnduriumMod.NPCs.EndurianWarlock
{
    public class EndurianSpirit : ModNPC
    {
        public override void SetDefaults()
        {

            npc.damage = 65;
            npc.npcSlots = 5f;
            npc.width = 84; //324
            npc.height = 106; //216
            npc.defense = 10;
            npc.lifeMax = 10000;
            npc.aiStyle = -1; //new
            aiType = -1; //new
            npc.knockBackResist = 0f;
            Main.npcFrameCount[npc.type] = 7;
            npc.value = Item.buyPrice(0, 16, 0, 0);
            npc.alpha = 10;
            npc.buffImmune[39] = true;
            npc.buffImmune[24] = true;
            npc.buffImmune[20] = true;
            npc.boss = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit19;
            npc.DeathSound = SoundID.NPCDeath45;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Overflowing_Power");
            bossBag = mod.ItemType("EndurianBag");
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.15f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = Main.npcTexture[npc.type];
            var effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(texture, npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame, drawColor, npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
            Texture2D glowmask = mod.GetTexture("NPCs/EndurianWarlock/EndurianWarlock_Glowmask");
            spriteBatch.Draw(glowmask, npc.Center - Main.screenPosition, npc.frame, npc.GetAlpha(Color.White), npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
            return false;
        }
        float AI2 = 0;
        float nutty = 20;
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn a gore
            {
                if (!EnduriumWorld.downedEndurianWarlock)
                {
                    EnduriumWorld.downedEndurianWarlock = true;
                }
            }
            for (int num623 = 0; num623 < 10; num623++)
            {
                int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 89, 0f, 0f, 100, default(Color), 1f);
                Main.dust[num624].noGravity = true;
                Main.dust[num624].velocity *= 4f;
            }
            if (npc.life <= 0)
            {
                for (int num623 = 0; num623 < 200; num623++)
                {
                    int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 89, 0f, 0f, 100, default(Color), 2f);
                    Main.dust[num624].noGravity = true;
                    Main.dust[num624].velocity *= 4f;
                }
            }
        }
        public override void NPCLoot()
        {
            npc.DropBossBags();
        }
        public override void AI()
        {
            Player player = Main.player[npc.target];
            int damage = 34;
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }
            if (npc.ai[3] <= 4)
            {
                if (player.Center.X > npc.Center.X)
                {
                    npc.spriteDirection = 1;
                }
                else
                {
                    npc.spriteDirection = -1;
                }
            }
            else
            {
                npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) + 0.785f;
            }
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
            if (Main.dayTime || Main.player[npc.target].dead)
            {
                npc.ai[3] = 20;
                npc.velocity.X = 0f;
                npc.velocity.Y += 2f;
            }
            npc.rotation = npc.velocity.X * 0.1f;
            if (!Main.player[npc.target].dead)
            {

                if (npc.ai[3] == 0 || npc.ai[3] == 3)
                {
                    float num = 10f;
                    float num2 = 0.5f;
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
                    if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
                    {

                    }
                }

                if (npc.ai[3] == 2 && Main.netMode != 1)
                {

                    if (AI2 == 0f)
                    {

                        if (npc.Center.X < Main.player[npc.target].Center.X && Main.netMode != 1)
                        {
                            AI2 = 1f;
                        }
                        else
                        {
                            AI2 = -1f;
                        }
                    }

                    int num852 = 800;
                    float num853 = Math.Abs(npc.Center.X - Main.player[npc.target].Center.X);
                    if (npc.Center.X < Main.player[npc.target].Center.X && AI2 < 0f && num853 > (float)num852 && Main.netMode != 1)
                    {
                        AI2 = 0f;
                    }
                    if (npc.Center.X > Main.player[npc.target].Center.X && AI2 > 0f && num853 > (float)num852 && Main.netMode != 1)
                    {
                        AI2 = 0f;
                    }
                    float num854 = 0.95f;
                    float num855 = 18f;
                    npc.velocity.X = npc.velocity.X + AI2 * num854;
                    if (npc.velocity.X > num855 && Main.netMode != 1)
                    {
                        npc.velocity.X = num855;
                        npc.netUpdate = true;
                    }
                    if (npc.velocity.X < -num855 && Main.netMode != 1)
                    {
                        npc.velocity.X = -num855;
                        npc.netUpdate = true;
                    }
                    float num856 = Main.player[npc.target].position.Y - (npc.position.Y + (float)npc.height);
                    if (num856 < 150f && Main.netMode != 1)
                    {
                        npc.velocity.Y = npc.velocity.Y - 0.2f;
                        npc.netUpdate = true;
                    }
                    if (num856 > 200f && Main.netMode != 1)
                    {
                        npc.velocity.Y = npc.velocity.Y + 0.2f;
                        npc.netUpdate = true;
                    }
                    if (npc.velocity.Y > 8f && Main.netMode != 1)
                    {
                        npc.velocity.Y = 8f;
                        npc.netUpdate = true;
                    }
                    if (npc.velocity.Y < -8f && Main.netMode != 1)
                    {
                        npc.velocity.Y = -8f;
                        npc.netUpdate = true;
                    }

                }
            }

            if (npc.ai[3] == 0)
            {
                npc.ai[0] += 1;
                int num235 = 13;
                if (Main.rand.Next(num235) == 0 && Main.netMode != 1)
                {
                    Projectile.NewProjectile(npc.position.X + Main.rand.Next(-50, 51), npc.position.Y + Main.rand.Next(-50, 51), 0f, 0f, mod.ProjectileType("PlagueMine"), damage, 0f, Main.myPlayer, 0f, 0f);
                    npc.netUpdate = true;
                }

                if (npc.ai[0] >= 150)
                {
                    npc.ai[3] = 1;
                    npc.ai[0] = 0;
                    npc.netUpdate = true;
                }
            }


            if (npc.ai[3] == 1)
            {
                npc.ai[0] += 1;
                npc.velocity.X *= 0.9f;
                npc.velocity.Y *= 0.9f;
                int num3 = 50;
                int num4 = 80;
                int num5 = 90;
                if (npc.ai[0] == num3 && Main.netMode != 1)
                {
                    npc.position.X = player.position.X - 900 + Main.rand.Next(600);
                    npc.position.Y = player.position.Y - 900 + Main.rand.Next(600);
                    for (int num623 = 0; num623 < 25; num623++)
                    {
                        int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 89, 0f, 0f, 100, default(Color), 1.6f);
                        Main.dust[num624].noGravity = true;
                        Main.dust[num624].velocity *= 4f;
                    }
                    npc.netUpdate = true;
                }
                if (npc.ai[0] == (int)(num3 += 1))
                {
                    for (int num623 = 0; num623 < 25; num623++)
                    {
                        int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 89, 0f, 0f, 100, default(Color), 1.6f);
                        Main.dust[num624].noGravity = true;
                        Main.dust[num624].velocity *= 4f;
                    }
                }
                if (npc.ai[0] == num4 && npc.ai[1] == 0 && Main.netMode != 1)
                {
                    npc.ai[0] = 0;
                    npc.ai[1] = 1;
                    npc.ai[3] = 2;
                    npc.netUpdate = true;
                }
                else if (npc.ai[0] == num5 && npc.ai[1] == 1 && Main.netMode != 1)
                {
                    npc.ai[0] = 0;
                    npc.ai[1] = 0;
                    npc.ai[3] = 3;
                    npc.netUpdate = true;
                }
            }


            if (npc.ai[3] == 2)
            {
                int num1 = 17;
                int num2 = 17;

                npc.ai[0] += 1;
                if (npc.ai[0] >= num2)
                {
                    if (Main.netMode != 1)
                    {
                        npc.ai[0] = 1;
                        npc.ai[2] += 1;
                        float Speed = 9f;  // projectile speed
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 4), npc.position.Y + (npc.height / 4));
                        int type = mod.ProjectileType("PlagueSplit");  //put your projectile
                        float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                        npc.netUpdate = true;
                    }
                }
                if (npc.ai[2] >= num1 && Main.netMode != 1)
                {
                    npc.ai[0] = 0;
                    npc.ai[2] = 0;
                    npc.ai[3] = 4;
                    npc.netUpdate = true;
                }
            }


            if (npc.ai[3] == 3)
            {
                int num1 = 14;
                int num2 = 14;
                npc.velocity.X *= 0.9f;
                npc.velocity.Y *= 0.9f;

                npc.ai[0] += 1;
                if (npc.ai[0] >= num2 && Main.netMode != 1)
                {
                    if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].head))
                    {
                        Projectile.NewProjectile(player.position.X, player.position.Y - 600, 0f, 6f, mod.ProjectileType("PlagueStrike1"), damage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X, player.position.Y - 600, 0f, 6f, mod.ProjectileType("PlagueStrike2"), damage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X, player.position.Y - 600, 0f, 6f, mod.ProjectileType("PlagueLeaf"), damage, 0f, Main.myPlayer);
                        npc.netUpdate = true;

                        npc.ai[0] = 0;
                        npc.ai[2] += 1;
                        Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 5);
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
                            Projectile.NewProjectile(vector23.X, vector23.Y, num148, num150, mod.ProjectileType("PlagueFeather"), damage, 0f, Main.myPlayer, 0f, 0f);
                            num25 = num154;
                        }
                    }
                    else if (nutty == 0)
                    {
                        nutty = 40;
                        npc.position.X = player.position.X - 900 + Main.rand.Next(1800);
                        npc.position.Y = player.position.Y - 900 + Main.rand.Next(1800);
                        for (int i = 0; i < 52; i++)    // More dust
                        {
                            int dustType = 89;
                            int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
                            Dust dust = Main.dust[dustIndex];
                            dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                            dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                            dust.scale *= 0.5f;
                        }
                    }
                    npc.netUpdate = true;
                    if (nutty >= 0)
                    {
                        nutty -= 1;
                    }
                }
                if (npc.ai[2] >= num1 && Main.netMode != 1)
                {
                    npc.ai[0] = 0;
                    npc.ai[2] = 0;
                    npc.ai[3] = 4;
                    npc.netUpdate = true;
                }
            }


            if (npc.ai[3] == 4)
            {
                npc.velocity.X *= 0.25f;
                npc.velocity.Y *= 0.25f;
                if (Main.netMode != 1)
                {
                    npc.ai[3] = 5;
                }
                npc.netUpdate = true;
            }


            if (npc.ai[3] == 5)
            {
                npc.ai[0] += 1;
                float Speed = 32f;

                if (npc.ai[0] == 50 && Main.netMode != 1)
                {
                    for (int num625 = 0; num625 < 2; num625++)
                    {
                        Projectile.NewProjectile(npc.position.X + Main.rand.Next(-50, 51), npc.position.Y + Main.rand.Next(-50, 51), 0f, 0f, mod.ProjectileType("PlagueMine"), damage, 0f, Main.myPlayer, 0f, 0f);
                    }
                    if (Main.netMode != 1)
                    {
                        Projectile.NewProjectile(player.position.X, player.position.Y - 600, 0f, 6f, mod.ProjectileType("PlagueStrike1"), damage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X, player.position.Y - 600, 0f, 6f, mod.ProjectileType("PlagueLeaf"), damage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X, player.position.Y - 600, 0f, 6f, mod.ProjectileType("PlagueStrike2"), damage, 0f, Main.myPlayer);
                        npc.netUpdate = true;
                    }

                    npc.position.X = player.position.X - 900 + Main.rand.Next(600);
                    npc.position.Y = player.position.Y - 900 + Main.rand.Next(600);
                    for (int num623 = 0; num623 < 25; num623++)
                    {
                        int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 89, 0f, 0f, 100, default(Color), 1.6f);
                        Main.dust[num624].noGravity = true;
                        Main.dust[num624].velocity *= 4f;
                    }

                    npc.netUpdate = true;
                }
                if (npc.ai[0] == 51 && Main.netMode != 1)
                {
                    for (int num623 = 0; num623 < 25; num623++)
                    {
                        int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 89, 0f, 0f, 100, default(Color), 1.6f);
                        Main.dust[num624].noGravity = true;
                        Main.dust[num624].velocity *= 4f;
                    }
                    npc.netUpdate = true;
                }
                if (npc.ai[0] >= 75 && npc.ai[0] <= 85 && Main.netMode != 1)
                {
                    Vector2 PlayerPosition = new Vector2(player.Center.X - npc.Center.X, player.Center.Y - npc.Center.Y);
                    PlayerPosition.Normalize();
                    npc.velocity = PlayerPosition * 20f;
                    npc.netUpdate = true;
                }
                if (npc.ai[0] >= 85 && Main.netMode != 1)
                {
                    npc.ai[0] = 0;
                    npc.ai[2] += 1;
                    npc.netUpdate = true;
                }
                if (npc.ai[2] >= 4 && Main.netMode != 1)
                {
                    npc.ai[3] = 0;
                    npc.ai[0] = 0;
                    npc.ai[2] = 0;
                    npc.netUpdate = true;
                }
            }
            return;
        }
    }
}