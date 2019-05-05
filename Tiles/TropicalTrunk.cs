using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Tiles
{
    public class TropicalTrunk : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;  //true for block to emit light
            Main.tileLighted[Type] = true;
            soundType = 0;
            Main.tileMerge[Type][mod.GetTile("RuinBrick").Type] = true;
            Main.tileMerge[Type][mod.GetTile("TropicBrick").Type] = true;
            Main.tileMerge[Type][mod.GetTile("TropicStoneTest").Type] = true;
            Main.tileMerge[Type][mod.GetTile("ElementBloomOre").Type] = true;
            Main.tileMerge[Type][mod.GetTile("TropicalSoil").Type] = true;
            Main.tileMerge[Type][mod.GetTile("LivingStone").Type] = true;
            drop = mod.ItemType("ThornWood");   //put your CustomBlock name
            AddMapEntry(new Color(244, 235, 66));
        }
    }
}