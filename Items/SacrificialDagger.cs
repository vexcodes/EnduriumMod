using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;
namespace EnduriumMod.Items
{
    public class SacrificialDagger : ModItem
    {
        public override void SetDefaults()
        {

			item.width = 38;
			item.height = 32;
			item.maxStack = 1;

			item.rare = -1;
			item.useAnimation = 55;
			item.useTime = 55;
			item.useStyle = 2;
			item.UseSound = SoundID.Item1;
	
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sacrificial Dagger");
            Tooltip.SetDefault("Kills you for good\nDon't use this item unless you really want to end it all");
        }

		public override bool UseItem(Player player)
		{
               player.KillMeForGood();
			  
			   			player.AddBuff(mod.BuffType("Death"), 100);
			return true;
		}
    }
}