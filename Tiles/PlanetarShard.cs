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
    public class PlanetarShard : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;  //true for block to emit light
            Main.tileLighted[Type] = true;
            soundType = 21;
            Main.tileMergeDirt[Type] = true;
            minPick = 270;
            drop = mod.ItemType("PlanetarShard");   //put your CustomBlock name
            AddMapEntry(new Color(50, 255, 255));
            dustType = 156;
            Main.tileSpelunker[Type] = true;
            mineResist = 29f;
        }
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            if (Main.rand.Next(500) == 0)
            {
               int dustie = Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, 156, 0f, 0f, 0, default(Color), 1.4f);
                Main.dust[dustie].scale = 0.7f;
                Main.dust[dustie].noGravity = true;
                Main.dust[dustie].velocity *= 0.34f;
            }
        }
    }
}