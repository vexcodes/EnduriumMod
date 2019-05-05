using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.PrismMonolith
{
    public class CruptixWorm_Body : ModNPC
    {
        public int spawn = 9;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tortured Soul");
        }
				        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
        	target.AddBuff(mod.BuffType("Shiver"), 100);
        }
        public override void SetDefaults()
        {
            npc.damage = 30; //70
            npc.npcSlots = 5f;
            npc.width = 32; //324
            npc.height = 32; //216
            npc.defense = 6;
            npc.lifeMax = 2280; //250000
            npc.aiStyle = 6; //new
            aiType = -1; //new
            npc.knockBackResist = 0f;
            npc.behindTiles = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.Item14;
            npc.netAlways = true;
            npc.dontCountMe = true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }

        public override void AI()
        {
            bool expertMode = Main.expertMode;
            Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 0.2f, 0.05f, 0.2f);
            if (!Main.npc[(int)npc.ai[1]].active)
            {
                npc.life = 0;
                npc.HitEffect(0, 10.0);
                npc.active = false;
            }
        }

        public override bool CheckActive()
        {
            return false;
        }

        public override bool PreNPCLoot()
        {
            return false;
        }
    }
}