using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Tiles
{
    public class EmberFlareOre : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;  //true for block to emit light
            Main.tileLighted[Type] = true;
            soundType = 21;
						Main.tileMergeDirt[Type] = true;
						minPick = 105;
            drop = mod.ItemType("DuskOre");   //put your CustomBlock name
            AddMapEntry(new Color(255, 150, 100));
            mineResist = 5f;
            Main.tileSpelunker[Type] = true;
        }
				
		public override bool CanExplode(int i, int j)
		{
			return false;
		}
    }
}