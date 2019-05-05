using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Tiles
{
    public class Aquamarine : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;  //true for block to emit light
            Main.tileLighted[Type] = true;
            soundType = 21;
						Main.tileMergeDirt[Type] = true;
						minPick = 115;
            drop = mod.ItemType("AquaticCluster");   //put your CustomBlock name
            AddMapEntry(new Color(56, 152, 255));
						Main.tileSpelunker[Type] = true;
            mineResist = 3.5f;
        }
				
		public override bool CanExplode(int i, int j)
		{
			return false;
		}
    }
}