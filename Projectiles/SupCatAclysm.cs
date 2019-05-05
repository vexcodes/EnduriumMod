using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class SupCatAclysm : ModProjectile
    {
	        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 18;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 800;
            projectile.light = 0.25f;
            projectile.extraUpdates = 1;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 2;
            ProjectileID.Sets.TrailingMode[projectile.type] = 5;
            projectile.aiStyle = 2;
            aiType = 48;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Supreme CatAclysm");
        }


      

        public override bool PreAI()
        {
            for (int num136 = 0; num136 < 3; num136++)
            {
                float x2 = projectile.position.X - projectile.velocity.X / 10f * (float)num136;
                float y2 = projectile.position.Y - projectile.velocity.Y / 10f * (float)num136;
                int num137 = Dust.NewDust(new Vector2(x2, y2), 16, 255, 72, 0f, 0f, 0, default(Color), 1.62f);
                Main.dust[num137].alpha = projectile.alpha;
                Main.dust[num137].position.X = x2;
                Main.dust[num137].position.Y = y2;
                Main.dust[num137].velocity *= 1f;
                Main.dust[num137].noGravity = true;
            }
            for (int num136 = 0; num136 < 3; num136++)
            {
                float x2 = projectile.position.X - projectile.velocity.X / 10f * (float)num136;
                float y2 = projectile.position.Y - projectile.velocity.Y / 10f * (float)num136;
                int num137 = Dust.NewDust(new Vector2(x2, y2), 16, 255, 71, 0f, 0f, 0, default(Color), 1.62f);
                Main.dust[num137].alpha = projectile.alpha;
                Main.dust[num137].position.X = x2;
                Main.dust[num137].position.Y = y2;
                Main.dust[num137].velocity *= 1f;
                Main.dust[num137].noGravity = true;
            }
			            for (int num136 = 0; num136 < 3; num136++)
            {
                float x2 = projectile.position.X - projectile.velocity.X / 10f * (float)num136;
                float y2 = projectile.position.Y - projectile.velocity.Y / 10f * (float)num136;
                int num137 = Dust.NewDust(new Vector2(x2, y2), 16, 255, 73, 0f, 0f, 0, default(Color), 1.62f);
                Main.dust[num137].alpha = projectile.alpha;
                Main.dust[num137].position.X = x2;
                Main.dust[num137].position.Y = y2;
                Main.dust[num137].velocity *= 1f;
                Main.dust[num137].noGravity = true;
            }
			            for (int num136 = 0; num136 < 3; num136++)
            {
                float x2 = projectile.position.X - projectile.velocity.X / 10f * (float)num136;
                float y2 = projectile.position.Y - projectile.velocity.Y / 10f * (float)num136;
                int num137 = Dust.NewDust(new Vector2(x2, y2), 16, 255, 70, 0f, 0f, 0, default(Color), 1.62f);
                Main.dust[num137].alpha = projectile.alpha;
                Main.dust[num137].position.X = x2;
                Main.dust[num137].position.Y = y2;
                Main.dust[num137].velocity *= 1f;
                Main.dust[num137].noGravity = true;
            }
            float num138 = (float)Math.Sqrt((double)(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y));
            float num139 = projectile.localAI[0];
            if (num139 == 0f)
            {
                projectile.localAI[0] = num138;
                num139 = num138;
            }
            float num140 = projectile.position.X;
            float num141 = projectile.position.Y;
            float num142 = 300f;
            bool flag4 = false;
            int num143 = 0;
            if (projectile.ai[1] == 0f)
            {
                for (int num144 = 0; num144 < 200; num144++)
                {
                    if (Main.npc[num144].CanBeChasedBy(projectile, false) && (projectile.ai[1] == 0f || projectile.ai[1] == (float)(num144 + 1)))
                    {
                        float num145 = Main.npc[num144].position.X + (float)(Main.npc[num144].width / 2);
                        float num146 = Main.npc[num144].position.Y + (float)(Main.npc[num144].height / 2);
                        float num147 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num145) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num146);
                        if (num147 < num142 && Collision.CanHit(new Vector2(projectile.position.X + (float)(projectile.width / 2), projectile.position.Y + (float)(projectile.height / 2)), 1, 1, Main.npc[num144].position, Main.npc[num144].width, Main.npc[num144].height))
                        {
                            num142 = num147;
                            num140 = num145;
                            num141 = num146;
                            flag4 = true;
                            num143 = num144;
                        }
                    }
                }
                if (flag4)
                {
                    projectile.ai[1] = (float)(num143 + 1);
                }
                flag4 = false;
            }
            if (projectile.ai[1] > 0f)
            {
                int num148 = (int)(projectile.ai[1] - 1f);
                if (Main.npc[num148].active && Main.npc[num148].CanBeChasedBy(projectile, true) && !Main.npc[num148].dontTakeDamage)
                {
                    float num149 = Main.npc[num148].position.X + (float)(Main.npc[num148].width / 2);
                    float num150 = Main.npc[num148].position.Y + (float)(Main.npc[num148].height / 2);
                    float num151 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num149) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num150);
                    if (num151 < 1000f)
                    {
                        flag4 = true;
                        num140 = Main.npc[num148].position.X + (float)(Main.npc[num148].width / 2);
                        num141 = Main.npc[num148].position.Y + (float)(Main.npc[num148].height / 2);
                    }
                }
                else
                {
                    projectile.ai[1] = 0f;
                }
            }
            if (!projectile.friendly)
            {
                flag4 = false;
            }
            if (flag4)
            {
                float num152 = num139;
                Vector2 vector13 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                float num153 = num140 - vector13.X;
                float num154 = num141 - vector13.Y;
                float num155 = (float)Math.Sqrt((double)(num153 * num153 + num154 * num154));
                num155 = num152 / num155;
                num153 *= num155;
                num154 *= num155;
                int num156 = 12;
                projectile.velocity.X = (projectile.velocity.X * (float)(num156 - 1) + num153) / (float)num156;
                projectile.velocity.Y = (projectile.velocity.Y * (float)(num156 - 1) + num154) / (float)num156;
            }
            return false;
        }
        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 38, projectile.oldVelocity.X * 0f, projectile.oldVelocity.Y * 0f);
            }
        }
		        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }
    }
}
