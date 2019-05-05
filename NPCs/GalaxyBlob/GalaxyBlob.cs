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

namespace EnduriumMod.NPCs.GalaxyBlob
{
    public class GalaxyBlob : ModNPC
    {
        public override void SetDefaults()
        {

            npc.damage = 120;
            npc.npcSlots = 1f;
            npc.width = 44; //324
            npc.height = 46; //216
            npc.defense = 0;
            npc.lifeMax = 4500;
            npc.aiStyle = 14; //new
            aiType = -1; //new
            npc.knockBackResist = 0f;
            Main.npcFrameCount[npc.type] = 4;
            npc.value = Item.buyPrice(0, 10, 0, 0);
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneTowerStardust && NPC.downedMoonlord || spawnInfo.player.ZoneTowerSolar && NPC.downedMoonlord || spawnInfo.player.ZoneTowerVortex && NPC.downedMoonlord || spawnInfo.player.ZoneTowerNebula && NPC.downedMoonlord ? 0.11f : 0f;
        }
        public override void NPCLoot()
        {
            if (Main.player[npc.target].ZoneTowerStardust && NPC.downedMoonlord)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3459, Main.rand.Next(4, 16));
            }
            if (Main.player[npc.target].ZoneTowerSolar && NPC.downedMoonlord)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3458, Main.rand.Next(4, 16));
            }
            if (Main.player[npc.target].ZoneTowerVortex && NPC.downedMoonlord)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3456, Main.rand.Next(4, 16));
            }
            if (Main.player[npc.target].ZoneTowerNebula && NPC.downedMoonlord)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3457, Main.rand.Next(4, 16));
            }
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("QuantumCore"), Main.rand.Next(4, 6));
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3460, Main.rand.Next(4, 12));
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.15f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Galaxy Invader");
        }
        public override void AI()
        {
            Player player = Main.player[npc.target];
            npc.noGravity = true;
            npc.TargetClosest(true);
            npc.ai[0] += 1;
            if (npc.ai[0] >= 85 && Main.netMode != 1) // small leaf
            {
                npc.ai[0] = 0;
                float Speed = 11f;  // projectile speed
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 4), npc.position.Y + (npc.height / 4));
                int damage = 24;  // projectile damage
                int type = mod.ProjectileType("GalaxySpark");  //put your projectile
                float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                npc.netUpdate = true;
            }

        }
    }
}