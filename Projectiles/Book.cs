using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class Book : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Book");
            Main.projFrames[projectile.type] = 8;
            Main.projPet[projectile.type] = true;
            projectile.width = 20;
            projectile.height = 20;
        }
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.penetrate = -1;
            projectile.netImportant = true;
            projectile.timeLeft *= 5;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.manualDirectionChange = true;
        }
        public override void AI()
        {
            {
                Player player = Main.player[projectile.owner];
                float num = 4f;
                int num2 = 8;
                int num3 = 8;
                int num4 = Main.projFrames[projectile.type];
                int num5 = 0;
                Vector2 value = new Vector2((float)(player.direction * 64), -54f);
                if (player.dead)
                {
                    projectile.Kill();
                    return;
                }
                bool flag = true;
                MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(mod, "MyPlayer");
                if (player.dead)
                {
                    modPlayer.Book = false;
                }
                if (modPlayer.Book)
                {
                    projectile.timeLeft = 2;
                }
                projectile.direction = (projectile.spriteDirection = player.direction);
                Vector2 vector = player.MountedCenter + value;
                float num6 = Vector2.Distance(projectile.Center, vector);
                if (num6 > 1300f)
                {
                    projectile.Center = player.Center + value;
                }
                Vector2 vector2 = vector - projectile.Center;
                if (num6 < num)
                {
                    projectile.velocity *= 0.25f;
                }
                if (vector2 != Vector2.Zero)
                {
                    if (vector2.Length() < num * 0.5f)
                    {
                        projectile.velocity = vector2;
                    }
                    else
                    {
                        projectile.velocity = vector2 * 0.1f;
                    }
                }

                if (projectile.rotation > 3.14159274f)
                {
                    projectile.rotation -= 6.28318548f;
                }
                if (projectile.rotation > -0.005f && projectile.rotation < 0.005f)
                {
                    projectile.rotation = 0f;
                }
                else
                {
                    projectile.rotation *= 0.96f;
                }
                projectile.frameCounter++;
                if (projectile.frameCounter > 8)
                {
                    projectile.frame++;
                    projectile.frameCounter = 0;
                }
                if (projectile.frame > 7)
                {
                    projectile.frame = 0;
                }

                projectile.localAI[0] += 1f;
                if (projectile.localAI[0] > 160f)
                {
                    projectile.localAI[0] = 0f;
                }
            }
        }
    }
}