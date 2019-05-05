using System;
using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using System.Linq;
using Terraria.ModLoader.IO;

namespace EnduriumMod.Tiles
{
    public class EnduriumOreGen : ModWorld
    {
        private const int saveVersion = 0;
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (ShiniesIndex == -1)
            {
                return;
            }
            tasks.Insert(ShiniesIndex + 1, new PassLegacy("GenLament", delegate (GenerationProgress progress)
            {
                progress.Message = "Generating Lament Ore";
                //Put your custom tile block name
                {
                    for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
                    {
                        int i2 = WorldGen.genRand.Next(0, Main.maxTilesX);
                        int j2 = WorldGen.genRand.Next((int)(Main.maxTilesY * .3f), (int)(Main.maxTilesY * .7f));
                        if (Main.tile[i2, j2].type == 203 || Main.tile[i2, j2].type == 117 || Main.tile[i2, j2].type == 1 || Main.tile[i2, j2].type == 25)
                            WorldGen.OreRunner(i2, j2, (double)WorldGen.genRand.Next(6, 9), WorldGen.genRand.Next(6, 9), (ushort)mod.TileType("SkyLamentOre"));
                    }
                }
            }));
			   		     tasks.Insert(ShiniesIndex + 1, new PassLegacy("GenEmber", delegate (GenerationProgress progress)
            {
                progress.Message = "Generating Ember Flare";
                //Put your custom tile block name
                {
                    for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
                    {
                        int i2 = WorldGen.genRand.Next(0, Main.maxTilesX);
                        int j2 = WorldGen.genRand.Next((int)(Main.maxTilesY * .3f), (int)(Main.maxTilesY * .9f));
                        if (Main.tile[i2, j2].type == 203 || Main.tile[i2, j2].type == 117 || Main.tile[i2, j2].type == 1 || Main.tile[i2, j2].type == 25)
                            WorldGen.OreRunner(i2, j2, (double)WorldGen.genRand.Next(7, 8), WorldGen.genRand.Next(7, 8), (ushort)mod.TileType("EmberFlareOre"));
                    }
                }
            }));  
        }
    }
}