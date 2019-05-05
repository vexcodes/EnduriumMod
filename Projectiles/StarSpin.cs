using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System.IO;

namespace EnduriumMod.Projectiles
{
    public class StarSpin : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;
            projectile.CloneDefaults(ProjectileID.TheEyeOfCthulhu);
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 99;
            projectile.friendly = true;
            projectile.scale = 1f;
            projectile.penetrate = 20;
            projectile.melee = true;
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 25f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 350f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 24f;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Spin");
        }
        float AI1 = 0f;
        public override void AI()
        {
            AI1 += 1f;
            if (AI1 >= 40f)
            {
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 93);
                AI1 = 0f;
                Vector2 vector8 = new Vector2(projectile.Center.X, projectile.Center.Y);
                int damage = projectile.damage;  // projectile damage
                int type = mod.ProjectileType("StarSpinBolt");  //put your projectile
                int num11 = Projectile.NewProjectile(vector8.X, vector8.Y, 0f, 0f, type, damage, 0f, Main.myPlayer);
                Main.projectile[num11].localAI[0] = 0;
                Main.projectile[num11].netUpdate = true;
            }
            int a = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("StarFlame"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.dust[a].noGravity = true;
            Main.dust[a].velocity *= 0f;
            Main.dust[a].scale *= 1f;
            Main.dust[a].position = projectile.Center;
        }
    }
}