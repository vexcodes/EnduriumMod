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
    public class GraniteRotation : ModNPC //its treated like a projectile okay?
    {
        public override void SetDefaults()
        {

            npc.damage = 10;
            npc.npcSlots = 1f;
            npc.width = 8; //324
            npc.height = 8; //216
            npc.defense = 20;
            npc.lifeMax = 999;
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
            DisplayName.SetDefault("Granite Rotation");
        }
        float charge = 0f;
        public override bool PreAI()
        {
            npc.dontTakeDamage = true;
            Player P = Main.player[npc.target];
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }
            else if (npc.timeLeft > 1800)
            {
                npc.timeLeft = 1800;
            }
            int a = Dust.NewDust(npc.position, npc.width, npc.height, 156, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
            Main.dust[a].noGravity = true;
            Main.dust[a].velocity *= npc.velocity;
            Main.dust[a].scale *= 1f;
            if (npc.alpha >= 0)
            {
                npc.alpha -= 6;
            }
            if (npc.ai[2] == 170)
            {
                float Speed = 18f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 20;
                int type = mod.ProjectileType("GraniteRotation2");
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 60);
                float rotation = (float)Math.Atan2(vector8.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), vector8.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                npc.active = false;
                npc.life = 0;
                npc.checkDead();
                npc.HitEffect();

            }
            npc.TargetClosest(true);
            Vector2 direction = Main.player[npc.target].Center - npc.Center;
            npc.rotation = direction.ToRotation();  //To make this i modified a projectile that orbits around the player, modified it and got it working.
            if (npc.ai[2] <= 200)
            {
                npc.ai[2] += 2;
            }
            double deg = (double)npc.ai[1];
            double rad = deg * (Math.PI / 180);
            double dist = npc.ai[2];
            NPC p = Main.npc[(int)npc.ai[0]];
            npc.position.X = p.Center.X - (int)(Math.Cos(rad) * dist) - npc.width / 2;
            npc.position.Y = p.Center.Y - (int)(Math.Sin(rad) * dist) - npc.height / 2;
            if (charge <= 4f)
            {
                charge += 0.1f;
            }
            if (p.life <= 0 || !p.active)
            {
                npc.active = false;
                npc.life = 0;
                npc.checkDead();
                npc.HitEffect();
            }
            npc.ai[1] += charge;
            return false;
        }
    }
}