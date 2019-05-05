using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace EnduriumMod
{
    public class StarInvasion
    {
		//List of PreHardmodeInvaders
		public static int[] Star = {
			NPCID.AngryBones,
			NPCID.AngryBonesBig,
			NPCID.AngryBonesBigMuscle,
			NPCID.AngryBonesBigHelmet,
			NPCID.DungeonSlime,
			NPCID.DarkCaster,
			NPCID.CursedSkull
		};
		
		//Easy way to get full list
		public static int[] GetFullInvaderList()
		{
			//Creating a list
			int[] list = new int[Star.Length];
			
			//CopyTo(var arrayToCopyTo, index)
			Star.CopyTo(list, 0);
			
			return list;
		}
		
		//Setup for an Invasion After setting up
		public static void StartDungeonInvasion()
		{
			//Set to no invasion
			if (Main.invasionType != 0 && Main.invasionSize == 0)
			{
				Main.invasionType = 0;
			}
			if (Main.invasionType == 0)
			{
				//Checks amount of players
				int num = 0;
				for (int i = 0; i < 255; i++)
				{
					if (Main.player[i].active && Main.player[i].statLifeMax >= 200)
					{
						num++;
					}
				}
				if (num > 0)
				{
					//Invasion setup
					Main.invasionType = -1;
					EnduriumWorld.StarArmyUp = true;
					Main.invasionSize = 100 * num;
					Main.invasionSizeStart = Main.invasionSize;
					Main.invasionProgress = 0;
					Main.invasionProgressIcon = 0 + 3;
					Main.invasionProgressWave = 0;
					Main.invasionProgressMax = Main.invasionSizeStart;
					Main.invasionWarn = 360;
					if (Main.rand.Next(2) == 0)
					{
						Main.invasionX = 0.0;
						return;
					}
					Main.invasionX = (double)Main.maxTilesX;
				}
			}
		}

		//Text for Dungeons and syncing messages
		public static void DungeonInvasionWarning()
		{
			String text = "";
			if (Main.invasionX == (double)Main.spawnTileX)
			{
				text = "A portal from the space has opened";
			}
			if(Main.invasionSize <= 0)
			{
				text = "The stars fade away";
			}
			if (Main.netMode == 0)
			{
				Main.NewText(text, 175, 75, 255, false);
				return;
			}
			if (Main.netMode == 2)
			{
				//Sync with net
				NetMessage.SendData(25, -1, -1, NetworkText.FromLiteral(text), 255, 175f, 75f, 255f, 0, 0, 0);
			}
		}
		
		public static void UpdateDungeonInvasion()
		{
			if(EnduriumWorld.StarArmyUp)
			{
				//End invasion if size less or equal to 0
				if(Main.invasionSize <= 0)
				{
					EnduriumWorld.StarArmyUp = false;
					DungeonInvasionWarning();
					Main.invasionType = 0;
					Main.invasionDelay = 0;
				}
				
				//Do not do the rest if invasion already at spawn
				if (Main.invasionX == (double)Main.spawnTileX)
				{
					return;
				}
				
				//Update when the invasion gets to Spawn
				float num = (float)Main.dayRate;
				if (Main.invasionX > (double)Main.spawnTileX)
				{
					Main.invasionX -= (double)num;
					if (Main.invasionX <= (double)Main.spawnTileX)
					{
						Main.invasionX = (double)Main.spawnTileX;
						DungeonInvasionWarning();
					}
					else
					{
						Main.invasionWarn--;
					}
				}
				else
				{
					if (Main.invasionX < (double)Main.spawnTileX)
					{
						Main.invasionX += (double)num;
						if (Main.invasionX >= (double)Main.spawnTileX)
						{
							Main.invasionX = (double)Main.spawnTileX;
							DungeonInvasionWarning();
						}
						else
						{
							Main.invasionWarn--;
						}
					}
				}
			}
		}
		
		public static void CheckDungeonInvasionProgress()
		{
			//Get full list of invaders
			int[] FullList = GetFullInvaderList();
			
			//Not really sure what this is
			if (Main.invasionProgressMode != 2)
			{
				Main.invasionProgressNearInvasion = false;
				return;
			}
			bool flag = false;
			Player player = Main.player[Main.myPlayer];
			Rectangle rectangle = new Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
			int num = 5000;
			int icon = 0;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active)
				{
					icon = 0;
					int type = Main.npc[i].type;
					for(int n = 0; n < FullList.Length; n++)
					{
						if(type == FullList[n])
						{
							Rectangle value = new Rectangle((int)(Main.npc[i].position.X + (float)(Main.npc[i].width / 2)) - num, (int)(Main.npc[i].position.Y + (float)(Main.npc[i].height / 2)) - num, num * 2, num * 2);
							if (rectangle.Intersects(value))
							{
								flag = true;
								break;
							}
						}
					}
				}
			}
			Main.invasionProgressNearInvasion = flag;
			int progressMax3 = 1;
			if (EnduriumWorld.StarArmyUp)
			{
				progressMax3 = Main.invasionSizeStart;
			}
			if(EnduriumWorld.StarArmyUp && (Main.invasionX == (double)Main.spawnTileX))
			{
				//Shows the UI for the invasion
				Main.ReportInvasionProgress(Main.invasionSizeStart - Main.invasionSize, progressMax3, icon, 0);
			}
			
			//Syncing start of invasion
			foreach(Player p in Main.player)
			{
				NetMessage.SendData(78, p.whoAmI, -1, null, Main.invasionSizeStart - Main.invasionSize, (float)Main.invasionSizeStart, (float)(Main.invasionType + 3), 0f, 0, 0, 0);
			}
		}
    }
}