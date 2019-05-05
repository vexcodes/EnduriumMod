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

namespace EnduriumMod.NPCs.TropicalParadise.HardMode
{
    public class TropicalElemental : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tropic Elemental");
            Main.npcFrameCount[npc.type] = 5;
        }
        public override void SetDefaults()
        {

            npc.damage = 90;
            npc.npcSlots = 1f;
            npc.width = 38; //324
            npc.height = 46; //216
            npc.defense = 26;
            npc.lifeMax = 1000;
            npc.knockBackResist = 0f;
            npc.aiStyle = -1; //new
            aiType = -1; //new
            npc.noGravity = true;

            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
        }
        public override void AI()
        {
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
            if (Main.player[npc.target].dead)
            {
                npc.active = false;
            }
            else
            {
                npc.timeLeft = 2;
            }
            Player player = Main.player[npc.target];
            npc.noGravity = true;
            npc.TargetClosest(true);
            npc.rotation = npc.velocity.X * 0.1f;
            float num = 5f;
            float num2 = 0.06f;
            Vector2 vector = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
            float num4 = player.position.X + (float)(player.width / 2);
            float num5 = player.position.Y + (float)(player.height / 2);
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
            if (player.dead)
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
        public override void NPCLoot()
        {
            if (Main.rand.Next(5) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TropicalFragment"));
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return Main.tile[(int)(spawnInfo.spawnTileX), (int)(spawnInfo.spawnTileY)].type == mod.TileType("TropicalSoil") && Main.hardMode ? 0.1f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0 && Main.netMode != 1)
            {
                npc.netUpdate = true;
                int num11 = 3;
                for (int j = 0; j < num11; j++)
                {
                    Vector2 vector5 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                    vector5 += npc.velocity * 3f;
                    vector5.Normalize();
                    vector5 *= (float)Main.rand.Next(35, 39) * 0.1f;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vector5.X, vector5.Y, mod.ProjectileType("PlaguePursuit"), 20, 0f, 0);
                }
            }
        }
    }
}