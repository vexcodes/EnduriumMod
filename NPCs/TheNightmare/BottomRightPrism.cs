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

namespace EnduriumMod.NPCs.TheNightmare
{
    public class BottomRightPrism : ModNPC
    {
        public override void SetDefaults()
        {

            npc.damage = 70;
            npc.npcSlots = 1f;
            npc.width = 14; //324
            npc.height = 26; //216
            npc.defense = 20;
            npc.lifeMax = 500;
            npc.aiStyle = -1; //new
            aiType = -1; //new
            npc.knockBackResist = 0f;
            npc.alpha = 255;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prism Spell");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.damage = 80;
            npc.defense = 40;
            npc.lifeMax = 1000;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn a gore
            {
                int num3;
                for (int num731 = 0; num731 < 12; num731 = num3 + 1)
                {
                    int num732 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 5, 0f, 0f, 100, default(Color), 2.5f);
                    Main.dust[num732].noGravity = true;
                    Dust dust = Main.dust[num732];
                    dust.velocity *= 5f;
                    num732 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 5, 0f, 0f, 100, default(Color), 1.5f);
                    dust = Main.dust[num732];
                    dust.velocity *= 2.5f;
                    num3 = num731;
                }
            }
        }
        public override bool PreAI()
        {
            npc.dontTakeDamage = false;
            int num3;
            for (int num93 = 0; num93 < 2; num93 = num3 + 1)
            {
                int a = Dust.NewDust(npc.position, npc.width, npc.height, 156, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                Main.dust[a].noGravity = true;
                Main.dust[a].velocity *= 0f;
                Main.dust[a].position = npc.Center;
                Main.dust[a].scale *= 1f;
                num3 = num93;
            }
            if (npc.alpha >= 0)
            {
                npc.alpha -= 6;
            }
            npc.TargetClosest(true);
            if (npc.ai[2] <= 200)
            {
                npc.ai[2] = 200;
            }
            double deg = (double)npc.ai[1];
            double rad = deg * (Math.PI / 180);
            double dist = npc.ai[2];
            NPC p = Main.npc[(int)npc.ai[0]];
            npc.position.X = p.Center.X - (int)(Math.Cos(rad) * dist) - npc.width / 2;
            npc.position.Y = p.Center.Y - (int)(Math.Sin(rad) * dist) - npc.height / 2;
            if (p.life <= 0 || !p.active)
            {
                npc.active = false;
                npc.life = 0;
                npc.checkDead();
                npc.HitEffect();
                for (int num731 = 0; num731 < 12; num731 = num3 + 1)
                {
                    int num732 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 5, 0f, 0f, 100, default(Color), 2.5f);
                    Main.dust[num732].noGravity = true;
                    Dust dust = Main.dust[num732];
                    dust.velocity *= 5f;
                    num732 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 5, 0f, 0f, 100, default(Color), 1.5f);
                    dust = Main.dust[num732];
                    dust.velocity *= 2.5f;
                    num3 = num731;
                }
            }
            bool Top = NPC.AnyNPCs(mod.NPCType("TopPrism"));
            bool Right = NPC.AnyNPCs(mod.NPCType("BottomRightPrism"));
            bool Left = NPC.AnyNPCs(mod.NPCType("BottomLeftPrism"));
            npc.ai[1] += 2;
            return false;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = Main.npcTexture[npc.type];
            var effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(texture, npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame, drawColor, npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
            Texture2D glowmask = mod.GetTexture("NPCs/TheNightmare/BottomRightPrism");
            spriteBatch.Draw(glowmask, npc.Center - Main.screenPosition, npc.frame, npc.GetAlpha(Color.White), npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
            return false;
        }
    }
}