using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class GoblinMinion : ModProjectile
    {
        public float dust = 0f;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Battle Goblin");
        }
        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.friendly = true;
            projectile.minionSlots = 1;
            projectile.width = 32;
            projectile.height = 38;
            projectile.CloneDefaults(ProjectileID.OneEyedPirate);
            projectile.timeLeft = 250;
            aiType = ProjectileID.OneEyedPirate;
            projectile.timeLeft = 18000;
            Main.projFrames[projectile.type] = 15;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            projectile.penetrate = -1;
            projectile.timeLeft *= 5;
            projectile.minion = true;
        }

        public override void AI()
        {
            bool flag64 = projectile.type == mod.ProjectileType("GoblinMinion");
            Player player = Main.player[projectile.owner];
            MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(mod, "MyPlayer");
            player.AddBuff(mod.BuffType("GoblinMinionBuff"), 3600);
            if (flag64)
            {
                if (player.dead)
                {
                    modPlayer.GoblinMinionBuff = false;
                }
                if (modPlayer.GoblinMinionBuff)
                {
                    projectile.timeLeft = 2;
                }
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.penetrate == 0)
            {
                projectile.Kill();
            }
            return false;
        }
    }
}