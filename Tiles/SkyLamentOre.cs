using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Tiles
{
    public class SkyLamentOre : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;  //true for block to emit light
            Main.tileLighted[Type] = true;
            soundType = 21;
						Main.tileMergeDirt[Type] = true;
            drop = mod.ItemType("SkyLamentOre");   //put your CustomBlock name
            AddMapEntry(new Color(66, 244, 232));
						Main.tileSpelunker[Type] = true;
            mineResist = 2f;
        }
    }
}