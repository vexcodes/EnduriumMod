using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Dusts
{
    public class Shadegasm : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.scale *= 0.7f;
        }

        public override bool MidUpdate(Dust dust)
        {
            if (!dust.noGravity)
            {
                dust.velocity.Y += 0.1f;
            }
            if (!dust.noLight)
            {
                float strength = dust.scale * 1.4f;
                if (strength > 2f)
                {
                    strength = 2f;
                }
                Lighting.AddLight(dust.position, 0.1f * strength, 0.2f * strength, 0.7f * strength);
            }
            return false;
        }
    }
}