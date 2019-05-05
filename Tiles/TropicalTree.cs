using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace EnduriumMod.Tiles
{
	public class TropicalTree : ModTree
	{
		private Mod mod
		{
			get
			{
				return ModLoader.GetMod("EnduriumMod");
			}
		}
				public override int CreateDust()
		{
			return 89;
		}

		public override int GrowthFXGore()
		{
			return mod.GetGoreSlot("Gores/TropicalTreeFX");
		}

		public override int DropWood()
		{
			return mod.ItemType("ThornWood");
		}

		public override Texture2D GetTexture()
		{
			return mod.GetTexture("Tiles/TropicalTree");
		}

		public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
		{
			return mod.GetTexture("Tiles/TropicalTree_Tops");
		}

		public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame)
		{
			return mod.GetTexture("Tiles/TropicalTree_Branches");
		}
	}
}