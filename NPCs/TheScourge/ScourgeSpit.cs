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

namespace EnduriumMod.NPCs.TheScourge
{
    public class ScourgeSpit : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.hostile = true;
            projectile.width = 18; //324
            projectile.height = 18; //216
            projectile.tileCollide = false;
            projectile.aiStyle = -1; //new
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Toxic Spit");
        }
        bool randomized = false;
        bool velocity = false;
        float ai2 = 0f;
        float ai3 = 0f;
        public override bool PreAI()
        {
            NPC p = Main.npc[(int)projectile.ai[0]];
            if (!velocity)
            {
                if (!randomized)
                {
                    randomized = true;
                    projectile.alpha += Main.rand.Next(1, 125);
                    projectile.rotation += Main.rand.Next(1, 361);
                    projectile.scale += Main.rand.NextFloat(-0.25f, 0.4f);
                    ai2 += Main.rand.NextFloat(-37f, 36f);
                    projectile.ai[1] += Main.rand.NextFloat(1f, 361f);
                }
                if (ai3 == 0)
                {
                    ai2 += 0.5f;
                    if (ai2 >= 30f)
                    {

                        ai3 = 1;
                    }
                }
                if (ai3 == 1)
                {
                    ai2 -= 2.5f;
                    if (ai2 <= 10f)
                    {
                        ai3 = 0;
                    }
                }
                if (p.active)
                {
                    double deg = (double)projectile.ai[1];
                    double rad = deg * (Math.PI / 180);
                    double dist = ai2;
                    projectile.position.X = p.Center.X - (int)(Math.Cos(rad) * dist) - projectile.width / 2;
                    projectile.position.Y = p.Center.Y - (int)(Math.Sin(rad) * dist) - projectile.height / 2;
                }
            }
            if (p.life <= 0 || !p.active)
            {
                if (!velocity)
                {
                    velocity = true;
                    float num628 = (float)Main.rand.Next(-35, 36) * 0.02f;
                    float num629 = (float)Main.rand.Next(-35, 36) * 0.02f;
                    num628 *= 10f;
                    num629 *= 10f;
                    projectile.velocity.X = num628;
                    projectile.velocity.Y = num629;
                }
            }
            if (Main.rand.Next(3) == 0)
            {
                projectile.rotation += 0.08f;
                projectile.ai[1] += 1f;
            }
            projectile.rotation += 0.08f;
            projectile.ai[1] += 1f;
            return false;
        }
    }
}