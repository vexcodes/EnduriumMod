using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Dusts
{
    public class StarFlame : ModDust
    {
        public override bool MidUpdate(Dust dust)
        {
                dust.velocity.Y *= 0.95f;
            
            if (!dust.noLight)
            {
                float strength = dust.scale * 1.4f;
                if (strength > 2f)
                {
                    strength = 2f;
                }
                Lighting.AddLight(dust.position, 0f * strength, 0.2f * strength, 0.7f * strength);
            }
            return false;
        }

        public override Color? GetAlpha(Dust dust, Color lightColor)
        {
            return new Color(lightColor.R, lightColor.G, lightColor.B, 25);
        }
    }
}