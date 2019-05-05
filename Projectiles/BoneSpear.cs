using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class BoneSpear : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 72;
            projectile.height = 72;
            projectile.scale = 1f;
            projectile.aiStyle = 19;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
            projectile.timeLeft = 90;
            projectile.hide = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int num414 = (int)(target.Center.X);
            int num415 = (int)(target.Center.Y);
            Projectile.NewProjectile((float)num414, (float)num415, -5f, -5f, mod.ProjectileType("BoneSpear2"), 10, 0f, projectile.owner);
            Projectile.NewProjectile((float)num414, (float)num415, -5f, 5f, mod.ProjectileType("BoneSpear2"), 10, 0f, projectile.owner);
            Projectile.NewProjectile((float)num414, (float)num415, 5f, -5f, mod.ProjectileType("BoneSpear2"), 10, 0f, projectile.owner);
            Projectile.NewProjectile((float)num414, (float)num415, 5f, 5f, mod.ProjectileType("BoneSpear2"), 10, 0f, projectile.owner);
            Projectile.NewProjectile((float)num414, (float)num415, 0f, -5f, mod.ProjectileType("BoneSpear2"), 10, 0f, projectile.owner);
            Projectile.NewProjectile((float)num414, (float)num415, 0f, 5f, mod.ProjectileType("BoneSpear2"), 10, 0f, projectile.owner);
            Projectile.NewProjectile((float)num414, (float)num415, 5f, 0f, mod.ProjectileType("BoneSpear2"), 10, 0f, projectile.owner);
            Projectile.NewProjectile((float)num414, (float)num415, -5f, 0f, mod.ProjectileType("BoneSpear2"), 10, 0f, projectile.owner);
            return;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bone Pike");
        }

        public override void AI()
        {
            Main.player[projectile.owner].direction = projectile.direction;
            Main.player[projectile.owner].heldProj = projectile.whoAmI;
            Main.player[projectile.owner].itemTime = Main.player[projectile.owner].itemAnimation;
            projectile.position.X = Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) - (float)(projectile.width / 2);
            projectile.position.Y = Main.player[projectile.owner].position.Y + (float)(Main.player[projectile.owner].height / 2) - (float)(projectile.height / 2);
            projectile.position += projectile.velocity * projectile.ai[0]; if (projectile.ai[0] == 0f)
            {
                projectile.ai[0] = 3f;
                projectile.netUpdate = true;
            }
            if (Main.player[projectile.owner].itemAnimation < Main.player[projectile.owner].itemAnimationMax / 3)
            {
                projectile.ai[0] -= 1.1f;
            }
            else
            {
                projectile.ai[0] += 0.95f;
            }

            if (Main.player[projectile.owner].itemAnimation == 0)
            {
                projectile.Kill();
            }

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 2.355f;
            if (projectile.spriteDirection == -1)
            {
                projectile.rotation -= 1.57f;
            }
        }
    }
}
