using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System.IO;


namespace EnduriumMod.Tiles
{
    public class ElementBloomOre : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;  //true for block to emit light
            Main.tileLighted[Type] = true;
            soundType = 21;
            dustType = 89;
            minPick = 65;
            Main.tileMerge[Type][mod.GetTile("RuinBrick").Type] = true;
            Main.tileMerge[Type][mod.GetTile("TropicBrick").Type] = true;
            Main.tileMerge[Type][mod.GetTile("TropicStoneTest").Type] = true;
            Main.tileMerge[Type][mod.GetTile("TropicalTrunk").Type] = true;
            Main.tileMerge[Type][mod.GetTile("TropicalSoil").Type] = true;
            Main.tileMerge[Type][mod.GetTile("LivingStone").Type] = true;
            drop = mod.ItemType("BloomlightOre");   //put your CustomBlock name
            AddMapEntry(new Color(12, 135, 20));
            mineResist = 3f;
            Main.tileSpelunker[Type] = true;
        }
        public override bool CanExplode(int i, int j)
		{
			return false;
		}
    }
}