using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.StarShip
{
    public class TestEnemy : ModNPC
    {
        public override void SetDefaults()
        {

            npc.damage = 140;
            npc.npcSlots = 1f;
            npc.width = 156; //324
            npc.height = 156; //216
            npc.defense = 25;
            npc.lifeMax = 400000;
            npc.knockBackResist = 0f;
            npc.aiStyle = -1; //new
            aiType = -1; //new
            npc.value = Item.buyPrice(0, 20, 0, 0);
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath4;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Celestial_Intervention");
            bossBag = mod.ItemType("StarTreasureBag");
        }
        public virtual bool CheckDead(NPC npc)
        {
            return false;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Fortress");
        }
        float rotationPlus = 0f;
        float rotationBase = 0.02f;

        float movementACCX = 0.1f;
        float movementACCY = 0.22f;
        float movementCAPX = 7f;
        float movementCAPY = 9f;
        public override void AI()
        {
            //player choosing
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
                npc.spriteDirection = -1;
            }
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }
            //rotation
            rotationPlus = (npc.velocity.X + npc.velocity.Y) * 0.005f;
            if (P.Center.X > npc.Center.X)
            {
                npc.rotation += (rotationBase + rotationPlus);
            }
            else
            {
                npc.rotation -= ((rotationBase) - rotationPlus);
            }
            bool expertMode = Main.expertMode;
            //movement
            if (npc.velocity.Y >= movementCAPY)
            {
                npc.velocity.Y = movementCAPY;
            }
            if (npc.velocity.Y <= -movementCAPY)
            {
                npc.velocity.Y = -movementCAPY;
            }
            if (npc.velocity.X >= movementCAPX)
            {
                npc.velocity.X = movementCAPX;
            }
            if (npc.velocity.X <= -movementCAPX)
            {
                npc.velocity.X = -movementCAPX;
            }
            if (npc.position.Y > P.position.Y + 50f)
            {
                npc.velocity.Y = npc.velocity.Y -= movementACCY;
            }
            else if (npc.position.Y < P.position.Y - 50f)
            {
                npc.velocity.Y = npc.velocity.Y += movementACCY;
            }
            if (npc.position.X + (float)(npc.width / 2) > (P.position.X + (float)(P.width / 2)) + 50f)
            {
                npc.velocity.X = npc.velocity.X -= movementACCX;
            }
            if (npc.position.X + (float)(npc.width / 2) < (P.position.X + (float)(P.width / 2)) - 50f)
            {
                npc.velocity.X = npc.velocity.X += movementACCX;
            }
            int num001;
            int num1300 = 10;
            for (int num1301 = 0; num1301 < 1; num1301 = num001 + 1)
            {
                int num1302 = Dust.NewDust(npc.position - new Vector2((float)num1300), npc.width + num1300 * 2, npc.height + num1300 * 2, 89, 0f, 0f, 100, default(Color), 1f);
                Main.dust[num1302].noGravity = true;
                Main.dust[num1302].noLight = true;
                Main.dust[num1302].velocity.Y = movementACCY;
                Main.dust[num1302].velocity.X = movementACCX;
                num001 = num1301;
            }
        }
    }
}
//https://www.youtube.com/watch?v=b_eyzPf54j4 pass this shit to ricefield