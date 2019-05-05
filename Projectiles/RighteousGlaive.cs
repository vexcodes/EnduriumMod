using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class RighteousGlaive : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 248;
            projectile.height = 248;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = -1;
            projectile.aiStyle = -1;
            projectile.alpha = 255;
            projectile.hide = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.ownerHitCheck = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Righteous Glaive");
        }


        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
            projectile.direction = player.direction;
            player.heldProj = projectile.whoAmI;
            projectile.Center = vector;
            if (player.dead)
            {
                projectile.Kill();
                return;
            }
            if (!player.frozen)
            {
                projectile.spriteDirection = (projectile.direction = player.direction);
                projectile.alpha -= 127;
                if (projectile.alpha < 0)
                {
                    projectile.alpha = 0;
                }
                if (projectile.localAI[0] > 0f)
                {
                    projectile.localAI[0] -= 1f;
                }
                float num = (float)player.itemAnimation / (float)player.itemAnimationMax;
                float num2 = 9f - num;
                float num3 = projectile.velocity.ToRotation();
                float num4 = projectile.velocity.Length();
                float num5 = 22f;
                Vector2 value = new Vector2(1f, 0f).RotatedBy((double)(3.14159274f + num2 * 6.28318548f), default(Vector2));
                Vector2 spinningpoint = value * new Vector2(num4, projectile.ai[0]);
                projectile.position += spinningpoint.RotatedBy((double)num3, default(Vector2)) + new Vector2(num4 + num5, 0f).RotatedBy((double)num3, default(Vector2));
                Vector2 destination = vector + spinningpoint.RotatedBy((double)num3, default(Vector2)) + new Vector2(num4 + num5 + 40f, 0f).RotatedBy((double)num3, default(Vector2));
                projectile.rotation = player.AngleTo(destination) + 0.7853982f * (float)player.direction;
                if (projectile.spriteDirection == -1)
                {
                    projectile.rotation += 3.14159274f;
                }
                player.DirectionTo(projectile.Center);
                Vector2 value2 = player.DirectionTo(destination);
                Vector2 vector2 = projectile.velocity.SafeNormalize(Vector2.UnitY);
                float num6 = 8f;
                int num7 = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (Main.rand.Next(3) == 0)
                    {
                        Dust dust2 = Dust.NewDustDirect(projectile.Center, 20, 20, 15, 0f, 0f, 110, default(Color), 1f);
                        dust2.velocity = player.DirectionTo(dust2.position) * 2f;
                        dust2.position = projectile.Center + value2 * -110f;
                        dust2.scale = 0.45f + 0.4f * Main.rand.NextFloat();
                        dust2.fadeIn = 0.7f + 0.4f * Main.rand.NextFloat();
                        dust2.noGravity = true;
                        dust2.noLight = true;
                    }
                }

            }
            if (player.itemAnimation == 2)
            {
                projectile.Kill();
                player.reuseDelay = 2;
            }
        }
    }
}