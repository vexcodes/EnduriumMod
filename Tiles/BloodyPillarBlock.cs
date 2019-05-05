using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Tiles
{
    public class BloodyPillarBlock : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;  //true for block to emit light
            Main.tileLighted[Type] = true;
            soundType = 21;
						Main.tileMergeDirt[Type] = true;
            drop = mod.ItemType("BloodyBlock");   //put your CustomBlock name
            AddMapEntry(new Color(255, 127, 39));
        }
    }
}