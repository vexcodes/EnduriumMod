using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class MechanicalAngler : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 22;
            projectile.friendly = true;
            projectile.aiStyle = 39;
            Main.projFrames[projectile.type] = 4;
            aiType = 190;
            projectile.penetrate = -1;
            projectile.ranged = true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical Angler Fish");
        }
    }
}