using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace EnduriumMod.Tiles
{
    public class SkyLamentAnvil : ModTile
    {
        public override void SetDefaults()
        {

            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = false;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
            ModTranslation name = CreateMapEntryName();
            AddMapEntry(new Color(124, 161, 221), name);
            name.SetDefault("Sky Lament Anvil");
            disableSmartCursor = true;
            TileObjectData.addTile(Type);
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("SkyLamentAnvil"));
        }
    }
}
