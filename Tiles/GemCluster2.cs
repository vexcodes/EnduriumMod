using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace EnduriumMod.Tiles
{
    class GemCluster2 : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileObsidianKill[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.LavaDeath = false;
            dustType = 89;
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.addTile(Type);
            disableSmartCursor = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Elysian Crystal");
            AddMapEntry(new Color(0, 200, 125), name);
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            if (Main.rand.Next(300) == 0)
            {
                int dustie = Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, 89, 0f, 0f, 0, default(Color), 1.4f);
                Main.dust[dustie].scale = 1.5f;
                Main.dust[dustie].noGravity = true;
                Main.dust[dustie].velocity *= 0f;
            }
            Tile tile = Main.tile[i, j];
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }
            int height = tile.frameY == 18 ? 18 : 16;
            Main.spriteBatch.Draw(mod.GetTexture("Tiles/GemCluster2_Glow"), new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.frameX, tile.frameY, 16, height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.1f;
            g = 0.75f;
            b = 0.25f;
        }
        /*   public override void KillMultiTile(int i, int j, int frameX, int frameY)
           {
               Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType("Nothing"));
           }*/
    }
}