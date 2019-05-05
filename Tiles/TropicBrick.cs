using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Tiles
{
    public class TropicBrick : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;  //true for block to emit light
            Main.tileLighted[Type] = true;
            soundType = 21;
            Main.tileMergeDirt[Type] = true;
            Main.tileMerge[Type][mod.GetTile("TropicalSoil").Type] = true;
            Main.tileMerge[Type][mod.GetTile("TropicStoneTest").Type] = true;
            Main.tileMerge[Type][mod.GetTile("RuinBrick").Type] = true;
            drop = mod.ItemType("TropicBrick");   //put your CustomBlock name
            AddMapEntry(new Color(20, 200, 50));
        }
    }
}