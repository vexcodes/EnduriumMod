using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.StarInfection
{
    public class StarCreep : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Creep");
        }
        public override void SetDefaults()
        {

            npc.damage = 120;
            npc.npcSlots = 1f;
            npc.width = 32; //324
            npc.height = 40; //216
            npc.defense = 10;
            npc.value = 60000f;
            npc.lifeMax = 2800;
            npc.aiStyle = 14; //new
            npc.knockBackResist = 0f;
            Main.npcFrameCount[npc.type] = 4;
            npc.value = Item.buyPrice(0, 20, 0, 0);
            npc.noGravity = true;
            npc.noTileCollide = false;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
        }
        public override void NPCLoot()
        {
            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StarShard"));
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.GetModPlayer<MyPlayer>(mod).ZonePlanet ? 1.4f : 0f;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.24f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        public override void AI()
        {
            Player player = Main.player[npc.target];
            npc.rotation = npc.velocity.X / 30f;
            npc.ai[2] += 1f;
            if (npc.ai[2] == 210f && Main.netMode != 1 || npc.ai[2] == 220f && Main.netMode != 1 || npc.ai[2] >= 230f && Main.netMode != 1)
            {
                float Speed = 20f;  // projectile speed
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 4), npc.position.Y + (npc.height / 4));
                int damage = 40;  // projectile damage
                int type = mod.ProjectileType("StarBurst2");  //put your projectile
                float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                npc.netUpdate = true;
                if (npc.ai[2] >= 230f)
                {
                    npc.ai[2] = 0;
                }
                npc.netUpdate = true;
            }
            if (player.Center.X > npc.Center.X)
            {
                npc.spriteDirection = 1;
            }
            else
            {
                npc.spriteDirection = 2;
            }
            return;
        }
    }
}