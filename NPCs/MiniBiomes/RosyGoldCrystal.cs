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

namespace EnduriumMod.NPCs.MiniBiomes
{
    public class RosyGoldCrystal : ModNPC
    {
        public float shoot = 0f;

        public override void SetDefaults()
        {
            npc.damage = 20;
            npc.npcSlots = 5f;
            npc.width = 50; //324
            npc.height = 74; //216
            npc.defense = 10;
            npc.lifeMax = 100;
            npc.aiStyle = -1;
            npc.knockBackResist = 0f;
            for (int k = 0; k < npc.buffImmune.Length; k++)
            {
                npc.buffImmune[k] = true;
            }
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rosy Gold Crystal");
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.15f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        float drawscale = 1f;
        float drawchange = 0;
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D glowmask = mod.GetTexture("NPCs/MiniBiomes/RosyGoldCrystalGlow");
            int glownum = 84;
            int y7 = glownum * (int)npc.frameCounter;
            Main.spriteBatch.Draw(glowmask, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y7, glowmask.Width, glownum)), npc.GetAlpha(Color.White), npc.rotation, new Vector2((float)glowmask.Width / 2f, (float)glownum / 2f), drawscale, npc.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            return true;
        }
        public override void AI()
        {
            int damage = 13;
                npc.ai[1] += 1;
            
            if (npc.ai[1] >= 240)
            {
                int chance = 25;
                if (Main.rand.Next(chance) == 0 && Main.netMode != 1)
                {
                    if (Main.rand.Next(2) == 0 && Main.netMode != 1)
                    {
                        int p1 = Projectile.NewProjectile(npc.Center.X - Main.rand.Next(50, 70), npc.Center.Y + Main.rand.Next(-10, 10), 0f, 0f, mod.ProjectileType("RosyFire"), damage, 0f, Main.myPlayer, 0f, 0f);
                        Main.projectile[p1].timeLeft = 210;
                        Main.projectile[p1].netUpdate = true;
                        int p2 = Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-10, 10), npc.Center.Y - Main.rand.Next(60, 80), 0f, 0f, mod.ProjectileType("RosyFire"), damage, 0f, Main.myPlayer, 0f, 0f);
                        Main.projectile[p2].timeLeft = 260;
                        Main.projectile[p2].netUpdate = true;
                        int p3 = Projectile.NewProjectile(npc.Center.X + Main.rand.Next(70, 100), npc.Center.Y + Main.rand.Next(-10, 10), 0f, 0f, mod.ProjectileType("RosyFire"), damage, 0f, Main.myPlayer, 0f, 0f);
                        Main.projectile[p3].timeLeft = 310;
                        Main.projectile[p3].netUpdate = true;
                    }
                    else
                    {
                        int p1 = Projectile.NewProjectile(npc.Center.X - Main.rand.Next(50, 70), npc.Center.Y + Main.rand.Next(-10, 10), 0f, 0f, mod.ProjectileType("RosyFire"), damage, 0f, Main.myPlayer, 0f, 0f);
                        Main.projectile[p1].timeLeft = 310;
                        Main.projectile[p1].netUpdate = true;
                        int p2 = Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-10, 10), npc.Center.Y - Main.rand.Next(60, 80), 0f, 0f, mod.ProjectileType("RosyFire"), damage, 0f, Main.myPlayer, 0f, 0f);
                        Main.projectile[p2].timeLeft = 260;
                        Main.projectile[p2].netUpdate = true;
                        int p3 = Projectile.NewProjectile(npc.Center.X + Main.rand.Next(70, 100), npc.Center.Y + Main.rand.Next(-10, 10), 0f, 0f, mod.ProjectileType("RosyFire"), damage, 0f, Main.myPlayer, 0f, 0f);
                        Main.projectile[p3].timeLeft = 210;
                        Main.projectile[p3].netUpdate = true;
                    }
                    npc.ai[1] = 0;
                    npc.netUpdate = true;
                }
            }
            if (drawchange == 0)
            {
                drawscale += 0.004f;
                if (drawscale >= 1.12f)
                {
                    drawchange = 1;
                    npc.netUpdate = true;
                }
            }
            if (drawchange == 1)
            {
                drawscale -= 0.004f;
                if (drawscale <= 1.04f)
                {
                    drawchange = 0;
                    npc.netUpdate = true;
                }
            }
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
                npc.spriteDirection = 2;
            }
            bool expertMode = Main.expertMode;
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }

            if (npc.ai[2] == 0 && Main.netMode != 1)
            {
                npc.ai[2] = 1;
              /*  int num11 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("RosyGoldCrystalGlow"));
                Main.npc[num11].ai[0] = npc.whoAmI;
                Main.npc[num11].netUpdate = true;*/
            }
            if (npc.ai[2] == 1)
            {
                if (npc.ai[3] <= 0.12f)
                {
                    npc.ai[3] += 0.0025f;
                }
                npc.velocity.Y += npc.ai[3];
                if (npc.velocity.Y >= 0.32f && Main.netMode != 1)
                {
                    npc.ai[2] = 2;
                    npc.ai[3] = 0;
                    npc.netUpdate = true;
                }
            }
            if (npc.ai[2] == 2)
            {
                if (npc.ai[3] <= 0.12f)
                {
                    npc.ai[3] += 0.0025f;
                }
                npc.velocity.Y -= npc.ai[3];
                if (npc.velocity.Y <= -0.32f && Main.netMode != 1)
                {
                    npc.ai[2] = 1;
                    npc.ai[3] = 0;
                    npc.netUpdate = true;
                }
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            Tile tile = Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY];
            return (tile.type == 367) && !spawnInfo.playerInTown && !spawnInfo.player.ZoneTowerStardust && !spawnInfo.player.ZoneTowerSolar && !spawnInfo.player.ZoneTowerVortex && !spawnInfo.player.ZoneTowerNebula ? 0.24f : 0f;
        }
        public override void NPCLoot()
        {
            if (NPC.downedBoss1)
            {
                Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RosyGoldChunk"), Main.rand.Next(6, 10));
            }
            if (NPC.downedBoss2)
            {
                if (Main.rand.Next(20) == 0)
                {
                    Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EmperialGlaive"));
                }
            }
        }
    }
}