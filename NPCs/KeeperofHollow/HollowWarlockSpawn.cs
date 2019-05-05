using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.KeeperofHollow
{
    public class HollowWarlockSpawn : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 144;
            projectile.height = 126;
            projectile.aiStyle = -1;
            projectile.light = 0.25f;
            projectile.friendly = false;
            projectile.tileCollide = false;
            Main.projFrames[projectile.type] = 4;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            projectile.alpha = 200;
            projectile.scale = 0.75f;
            projectile.timeLeft = 25;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
            for (int num621 = 0; num621 < 10; num621++)
            {
                int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("HollowBurn"), 0f, 0f, 100, default(Color), 2.2f);
                Main.dust[num622].velocity *= 3f;
                Main.dust[num622].scale = 0.5f;
                Main.dust[num622].noGravity = true;
                Main.dust[num622].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
            }
            for (int num623 = 0; num623 < 10; num623++)
            {
                int num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 156, 0f, 0f, 100, default(Color), 2.7f);
                Main.dust[num624].noGravity = true;
                Main.dust[num624].velocity *= 4f;
                num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("HollowBurn"), 0f, 0f, 100, default(Color), 2f);
                Main.dust[num624].velocity *= 2f;
                Main.dust[num624].noGravity = true;


            }
            if (Main.expertMode && Main.netMode != 1)
            {
                NPC.NewNPC((int)projectile.Center.X, (int)projectile.Center.Y, mod.NPCType("TheKeeperofHollow2"));
                projectile.netUpdate = true;
            }
        }
        public override bool CanHitPlayer(Player target)
        {
            return false;
        }
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
            projectile.alpha -= 5;
            projectile.frameCounter++;
            if (projectile.frameCounter > 5)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 4)
            {
                projectile.frame = 0;
            }
            int num4324;
            int num;
            for (int num20 = 0; num20 < 2; num20 = num4324 + 1)
            {
                float num21 = projectile.velocity.X / 4f * (float)num20;
                float num22 = projectile.velocity.Y / 4f * (float)num20;
                int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("HollowBurn"), 0f, 0f, 0, default(Color), 1.9f);
                Main.dust[num23].position.X = projectile.Center.X - num21;
                Main.dust[num23].position.Y = projectile.Center.Y - num22;
                Dust dust3 = Main.dust[num23];
                dust3.velocity *= 3.7f;
                Main.dust[num23].scale = 0.98f;
                Main.dust[num23].noGravity = true;
                num4324 = num20;
            }
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Spirit of Bloom");
        }
    }
}