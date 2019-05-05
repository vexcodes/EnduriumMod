using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items
{
	public class PermarineBar : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 8;
			item.height = 5;
			item.maxStack = 999;
			item.value = 12344;
			item.rare = 8;
		}

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Permarine Bar");
            Tooltip.SetDefault("'It channels dark energy from the void'");
		    Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 30));
        }

		public override void PostUpdate()
		{
			Lighting.AddLight(item.Center, 0.9f * Main.essScale, 0.30f * Main.essScale, 1.1f * Main.essScale);//Color.WhiteSmoke.ToVector3() * 0.55f * Main.essScale);
		}

	}
}
