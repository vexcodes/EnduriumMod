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

namespace EnduriumMod.NPCs.Dusk
{
    public class FlameSpitter : ModNPC
    {
        public override void SetDefaults()
        {

            npc.damage = 45;
            npc.npcSlots = 1f;
            npc.width = 70; //324
            npc.height = 72; //216
            npc.defense = 20;
            npc.lifeMax = 500;
            npc.aiStyle = -1; //new
            aiType = -1; //new
            npc.knockBackResist = 0.2f;
            Main.npcFrameCount[npc.type] = 4;
            npc.value = Item.buyPrice(0, 2, 50, 0);
            npc.noGravity = true;
            npc.scale = 1.25f;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.damage = 60;
            npc.defense = 15;
            npc.lifeMax = 1000;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.08f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FlameTissue"), Main.rand.Next(3, 6));
            if (NPC.downedPlantBoss)
            {
                Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DragonShard"), Main.rand.Next(2, 6));
                if (Main.rand.Next(3) == 0)
                {
                    Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DragonBlood"), Main.rand.Next(2, 6));
                }
            }
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flame Spitter");
        }
        public int Phase = 0;
        public override void AI()
        {
            Player player = Main.player[npc.target];
            if (Phase == 0)
            {
                if (npc.life <= 350 && Phase == 0)
                {
                    Phase = 1;
                    int num3;
                    int num4;
                    for (int num624 = 0; num624 < 50; num624 = num3 + 1)
                    {
                        int num625 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 127, 0f, 0f, 0, default(Color), 2f);
                        Dust dust = Main.dust[num625];
                        dust.velocity *= 2.5f;
                        dust = Main.dust[num625];
                        dust.scale *= 0.9f;
                        Main.dust[num625].noGravity = true;
                        num3 = num624;
                    }
                }
                npc.aiStyle = 14;
                if (Main.netMode != 1)
                {
                    npc.ai[3] += (float)Main.rand.Next(2, 5);
                    if (npc.ai[3] >= 500 && Main.netMode != 1)
                    {
                        npc.ai[3] = 0f;
                        float Speed = 20f;  // projectile speed
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 4), npc.position.Y + (npc.height / 4));
                        // projectile damage
                        int type = mod.ProjectileType("EvilFire");  //put your projectile
                        float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, 25, 0f, Main.myPlayer);
                    }
                }
            }
            if (Phase == 1)
            {
                npc.aiStyle = -1;
                if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
                {
                    npc.TargetClosest(true);
                }
                float num = 20f;
                float num2 = 0.2f;
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
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);

            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("NPCs/Dusk/FlameSpitter_Gore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("NPCs/Dusk/FlameSpitter_Gore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("NPCs/Dusk/FlameSpitter_Gore2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("NPCs/Dusk/FlameSpitter_Gore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("NPCs/Dusk/FlameSpitter_Gore2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("NPCs/Dusk/FlameSpitter_Gore2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("NPCs/Dusk/FlameSpitter_Gore3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("NPCs/Dusk/FlameSpitter_Gore3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("NPCs/Dusk/FlameSpitter_Gore3"), 1f);
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 14);
                int num3;
                int num4;
                for (int num624 = 0; num624 < 50; num624 = num3 + 1)
                {
                    int num625 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 127, 0f, 0f, 0, default(Color), 2f);
                    Dust dust = Main.dust[num625];
                    dust.velocity *= 2.5f;
                    dust = Main.dust[num625];
                    dust.scale *= 0.9f;
                    Main.dust[num625].noGravity = true;
                    num3 = num624;
                }
                int num11 = Main.rand.Next(4, 8);
                for (int j = 0; j < num11; j++)
                {
                    Vector2 vector5 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                    vector5 += npc.velocity * 3f;
                    vector5.Normalize();
                    vector5 *= (float)Main.rand.Next(35, 39) * 0.1f;

                    int dab = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vector5.X, vector5.Y, 15, 40, 0f, 0);
                    Main.projectile[dab].hostile = true;
                    Main.projectile[dab].friendly = false;
                }

                int num12 = Main.rand.Next(4, 8);
                for (int g = 0; g < num11; g++)
                {
                    Vector2 vector5 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                    vector5 += npc.velocity * 3f;
                    vector5.Normalize();
                    vector5 *= (float)Main.rand.Next(35, 39) * 0.1f;

                    int dab = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vector5.X, vector5.Y, 328, 40, 0f, 0);
                    Main.projectile[dab].hostile = true;
                    Main.projectile[dab].friendly = false;
                }
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            Tile tile = Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY];
            return spawnInfo.player.ZoneUnderworldHeight && Main.hardMode ? 0.07f : 0f;
        }
    }
}