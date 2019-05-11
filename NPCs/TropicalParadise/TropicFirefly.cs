using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.TropicalParadise
{
    public class TropicFirefly : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tropic Firefly");
        }
        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            return false;
        }
        public override void SetDefaults()
        {
            npc.width = 8;
            npc.height = 8;
            npc.defense = 0;
            npc.lavaImmune = true;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.lifeMax = 5;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.3f;
            npc.aiStyle = -1;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Firefly];
            animationType = NPCID.Firefly;
        }
        public override void AI()
        {
            Player P = Main.player[npc.target];
            if (P.Center.X > npc.Center.X)
            {
                npc.spriteDirection = 1;
            }
            else
            {
                npc.spriteDirection = -1;
            }
                npc.TargetClosest(true);
            
            Vector2 vector102 = new Vector2(npc.Center.X, npc.Center.Y);
            float num791 = P.Center.X - vector102.X;
            float num792 = P.Center.Y - vector102.Y;
            float num793 = (float)Math.Sqrt((double)(num791 * num791 + num792 * num792));
            float num794 = 6f;
            num793 = num794 / num793;
            num791 *= num793;
            num792 *= num793;
            npc.velocity.X = (npc.velocity.X * 100f + num791) / 101f;
            npc.velocity.Y = (npc.velocity.Y * 100f + num792) / 101f;
            int num;
            for (int num1446 = 0; num1446 < 1; num1446 = num + 1)
            {
                int num1447 = Dust.NewDust(npc.position, npc.width, npc.height, 89, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f, 0, default(Color), 1.5f);
                Main.dust[num1447].noGravity = true;
                Dust dust3 = Main.dust[num1447];
                dust3.velocity *= 0f;
                num = num1446;
            }
            int num492 = P.whoAmI;

            Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 0f, 0.75f, 0.25f);
            float num493 = 4f;
            Vector2 vector39 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
            float num494 = P.Center.X - vector39.X;
            float num495 = P.Center.Y - vector39.Y;
            float num496 = (float)Math.Sqrt((double)(num494 * num494 + num495 * num495));
            if (num496 < 50f && npc.position.X < P.position.X + (float)P.width && npc.position.X + (float)npc.width > P.position.X && npc.position.Y < P.position.Y + (float)P.height && npc.position.Y + (float)npc.height > P.position.Y)
            {
                int num497 = 25;
                P.HealEffect(num497, false);
                Player player = P;
                player.statLife += num497;
                NetMessage.SendData(66, -1, -1, null, num492, (float)num497, 0f, 0f, 0, 0, 0);
                npc.active = false;
                npc.life = 0;
                npc.checkDead();
                npc.HitEffect();
                int num001;
                int num1300 = 10;
                for (int num1301 = 0; num1301 < 10; num1301 = num001 + 1)
                {
                    int num1302 = Dust.NewDust(npc.position - new Vector2((float)num1300), npc.width + num1300 * 2, npc.height + num1300 * 2, 89, 0f, 0f, 100, default(Color), 1f);
                    Main.dust[num1302].noGravity = true;
                    Main.dust[num1302].velocity *= 2f;
                    num001 = num1301;
                }
            }
            num496 = num493 / num496;
            num494 *= num496;
            num495 *= num496;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return Main.tile[(int)(spawnInfo.spawnTileX), (int)(spawnInfo.spawnTileY)].type == mod.TileType("TropicalSoil") ? 0.8f : 0f;
        }
    }
}