using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Tiles
{
    public class TropicalSoil : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;  //true for block to emit light
            Main.tileLighted[Type] = true;
            soundType = 0;
            Main.tileMerge[Type][mod.GetTile("RuinBrick").Type] = true;
            Main.tileMerge[Type][mod.GetTile("TropicBrick").Type] = true;
            Main.tileMerge[Type][mod.GetTile("TropicalTrunk").Type] = true;
            Main.tileMerge[Type][mod.GetTile("ElementBloomOre").Type] = true;
            Main.tileMerge[Type][mod.GetTile("TropicStoneTest").Type]= true;
            Main.tileMerge[Type][mod.GetTile("LivingStone").Type] = true;
            drop = mod.ItemType("TropicalSoil");   //put your CustomBlock name
            AddMapEntry(new Color(66, 204, 125));
            SetModTree(new TropicalTree());
        }
        public override void ChangeWaterfallStyle(ref int style)
        {
            style = mod.GetWaterfallStyleSlot("ExampleWaterfallStyle");
        }
        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return mod.TileType("TropicalSapling");
        }
    }
}