using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod
{
	class Drop222 : GlobalTile
	{
		public override bool Drop(int i, int j, int type)
		{
			if (type == mod.TileType("SkyLamentOre"))
			{
				if (Main.rand.Next(2) == 1)
				{
					Item.NewItem(i * 16, j * 16, 48, 32, mod.ItemType("MagicPowder"));
					goto il;
				}
			}
			return true;
			il: return true;
		}
	}
}
