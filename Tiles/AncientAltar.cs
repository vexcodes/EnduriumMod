using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace EnduriumMod.Tiles
{
    public class AncientAltar : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = false;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            ModTranslation name = CreateMapEntryName();
            AddMapEntry(new Color(0, 255, 125), name);
            name.SetDefault("Ancient Altar");
            disableSmartCursor = true;
            TileObjectData.addTile(Type);
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)   //light colors
        {
            r = 0f;
            g = 3f;
            b = 0.5f;
        }
        /*     public override void KillMultiTile(int i, int j, int frameX, int frameY)
             {
                 Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("AncientAltar"));
             }*/
    }
}
