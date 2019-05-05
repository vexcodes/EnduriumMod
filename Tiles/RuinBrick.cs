using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Tiles
{
    public class RuinBrick : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;  //true for block to emit light
            Main.tileLighted[Type] = true;
            soundType = 21;
            Main.tileMerge[Type][mod.GetTile("TropicalSoil").Type] = true;
            Main.tileMerge[Type][mod.GetTile("TropicBrick").Type] = true;
            Main.tileMerge[Type][mod.GetTile("TropicalTrunk").Type] = true;
            Main.tileMerge[Type][mod.GetTile("TropicStoneTest").Type] = true;
            Main.tileMerge[Type][mod.GetTile("ElementBloomOre").Type] = true;
            Main.tileMerge[Type][mod.GetTile("LivingStone").Type] = true;
            Main.tileMergeDirt[Type] = true;
            drop = mod.ItemType("RuinBrick");   //put your CustomBlock name
            AddMapEntry(new Color(255, 255, 10));
        }
    }
}