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

namespace EnduriumMod.NPCs.PrismMonolith
{
    public class PrismSpell : ModNPC
    {
        public override void SetDefaults()
        {

            npc.damage = 90;
            npc.npcSlots = 1f;
            npc.width = 32; //324
            npc.height = 32; //216
            npc.defense = 20;
            npc.lifeMax = 50;
            npc.aiStyle = -1; //new
            aiType = -1; //new
            npc.knockBackResist = 0f;
            npc.alpha = 95;
            npc.noGravity = true;
            npc.scale = 0.75f;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
        }
        float Speed = 0f;
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.damage = 100;
            npc.defense = 30;
            npc.lifeMax = 60;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prism Spell");
        }
        float spawnin = 0f;
        public override void AI()
        {
            if (spawnin == 0f)
            {
                spawnin = 1f;
                for (int num623 = 0; num623 < 15; num623++)
                {
                    int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 132, 0f, 0f, 100, default(Color), 1.2f);
                    Main.dust[num624].noGravity = true;
                    Main.dust[num624].velocity *= 4f;
                }
                Main.PlaySound(SoundID.DD2_DrakinShot, npc.position);
            }
            if (npc.ai[0] == 30)
            {
                npc.velocity.X *= 4.1f;
                npc.velocity.Y *= 4.1f;
            }
            int num3;
            for (int num93 = 0; num93 < 2; num93 = num3 + 1)
            {
                float num94 = npc.velocity.X / 3f * (float)num93;
                float num95 = npc.velocity.Y / 3f * (float)num93;
                int num96 = 4;
                int num97 = Dust.NewDust(new Vector2(npc.position.X + (float)num96, npc.position.Y + (float)num96), npc.width - num96 * 2, npc.height - num96 * 2, 132, 0f, 0f, 100, default(Color), 0.5f);
                Main.dust[num97].noGravity = true;
                Dust dust3 = Main.dust[num97];
                dust3.velocity *= 0.1f;
                dust3 = Main.dust[num97];
                dust3.velocity += npc.velocity * 0.1f;
                Dust dust6 = Main.dust[num97];
                dust6.position.X = dust6.position.X - num94;
                Dust dust7 = Main.dust[num97];
                dust7.position.Y = dust7.position.Y - num95;
                num3 = num93;
            }
            npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) + 0.785f;

        }
    }
}