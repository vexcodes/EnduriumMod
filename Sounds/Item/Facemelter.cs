using Microsoft.Xna.Framework.Audio;
using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Sounds.Facemelter
{
    public class Facemelter : ModSound
    {
        public override SoundEffectInstance PlaySound(ref SoundEffectInstance soundInstance, float volume, float pan, SoundType type)
        {
            // By checking if the input soundInstance is playing, we can prevent the sound from firing while the sound is still playing, allowing the sound to play out completely. Non-ModSound behavior is to restart the sound, only permitting 1 instance.
            if (soundInstance.State == SoundState.Playing)
                return null;
            soundInstance.Volume = volume * 1.25f;
            soundInstance.Pan = pan;
            soundInstance.Pitch = 1.25f;
            return soundInstance;
        }
    }
}
