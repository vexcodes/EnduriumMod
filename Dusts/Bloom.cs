using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Dusts
{
    public class Bloom : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity.Y = Main.rand.Next(-20, 10) * 0.05f;
            dust.velocity.X *= 0.3f;
            dust.scale *= 0.7f;
        }

        public override bool MidUpdate(Dust dust)
        {
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