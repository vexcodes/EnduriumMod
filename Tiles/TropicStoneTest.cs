using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Tiles
{
    public class TropicStoneTest : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;  //true for block to emit light
            Main.tileLighted[Type] = true;
            soundType = 21;
            Main.tileMerge[Type][mod.GetTile("RuinBrick").Type] = true;
            Main.tileMerge[Type][mod.GetTile("TropicBrick").Type] = true;
            Main.tileMerge[Type][mod.GetTile("TropicalTrunk").Type] = true;
            Main.tileMerge[Type][mod.GetTile("ElementBloomOre").Type] = true;
            Main.tileMerge[Type][mod.GetTile("TropicalSoil").Type] = true;
            Main.tileMerge[Type][mod.GetTile("LivingStone").Type] = true;
            minPick = 35;
            drop = mod.ItemType("TropicalStone");   //put your CustomBlock name
            AddMapEntry(new Color(230, 154, 120));
        }
				
		public override bool CanExplode(int i, int j)
		{
			return false;
		}
    }
}