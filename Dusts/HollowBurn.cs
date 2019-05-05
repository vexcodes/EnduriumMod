using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Dusts
{
    public class HollowBurn : ModDust
    {

        public override bool MidUpdate(Dust dust)
        {
            if (!dust.noLight)
            {
                float strength = dust.scale * 1.4f;
                if (strength > 8f)
                {
                    strength = 8f;
                }
                Lighting.AddLight(dust.position, 0.1f * strength, 0.2f * strength, 8f * strength);
            }
            return false;
        }
    }
}