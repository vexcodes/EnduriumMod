using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace EnduriumMod.NPCs
{
    public class EnduriumDrops : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == mod.NPCType("NecroMaster"))
            {
                EnduriumWorld.downedPhantasmShaman = true;
            }
            if (Main.rand.Next(20) == 0)
            {
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BronzeCoin"), 1);
                }
            }
            if (npc.type == 327) // pemp kong
            {
                if (Main.rand.Next(4) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Exhaustion"));
                }
            }

            if (npc.type == 159 || npc.type == 158 || npc.type == 253 || npc.type == 251) 
            {
                if (Main.rand.Next(2) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RiftShard"), Main.rand.Next(1, 4));
                }
            }


            if (npc.type == 345) // ice queen
            {
                if (Main.rand.Next(4) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TheBlizzard"));
                }
            }
            if (npc.type == 398) // moon lord
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MoonPlasm"), Main.rand.Next(200, 400));
            }
            if (npc.type == 262) // plantera
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TropicRune"), Main.rand.Next(1, 5));
            }

            if (npc.type == mod.NPCType("TropicalBoulderFlying"))
            {
                if (NPC.downedBoss3)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Jade"), Main.rand.Next(3, 5));
                }
            }
            if (npc.type == mod.NPCType("BoneClatterWorm_Head"))
            {
                if (NPC.downedPlantBoss)
                {
                    if (Main.rand.Next(4) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SoulGem"), Main.rand.Next(3, 8));
                    }
                }
            }
            if (npc.type == mod.NPCType("FlameSpitter"))
            {
                if (NPC.downedPlantBoss)
                {
                    if (Main.rand.Next(4) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SoulGem"), Main.rand.Next(3, 8));
                    }
                }
            }
            if (npc.type == 156) //reddevil
            {
                if (NPC.downedPlantBoss)
                {
                    if (Main.rand.Next(4) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SoulGem"), Main.rand.Next(3, 8));
                    }
                }
            }
            if (npc.type == 32)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ErodedShard"), Main.rand.Next(8, 14));
            }
            if (Main.hardMode)
            {
                if (npc.type == mod.NPCType("TropicalSlime"))
                {
                    if (Main.rand.Next(100) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TropicalFragment"), Main.rand.Next(1, 2));
                    }
                }
                if (npc.type == mod.NPCType("TropicalBat"))
                {
                    if (Main.rand.Next(100) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TropicalFragment"), Main.rand.Next(1, 2));
                    }
                }
                if (npc.type == mod.NPCType("TropicalBoulder"))
                {
                    if (Main.rand.Next(50) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TropicalFragment"), Main.rand.Next(1, 2));
                    }
                }
                if (npc.type == mod.NPCType("TropicalBoulderFlying"))
                {
                    if (Main.rand.Next(35) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TropicalFragment"), Main.rand.Next(1, 2));
                    }
                }
                if (npc.type == NPCID.IceGolem)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GlitterFrostCrystal"), Main.rand.Next(15, 25));

                }
                if (npc.type == NPCID.MeteorHead)
                {
                    if (Main.rand.Next(3) == 0)
                    {

                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FieryTissue"), 1);

                    }
                }
                if (npc.type == NPCID.Lihzahrd || npc.type == NPCID.LihzahrdCrawler || npc.type == NPCID.FlyingSnake)
                {
                    if (Main.rand.Next(3) == 0)
                    {

                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TempleFragment"), Main.rand.Next(2, 4));
                    }
                    if (Main.rand.Next(2) == 0)
                    {

                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RuinousCrystal"), Main.rand.Next(3, 6));
                    }
                }
                if (npc.type == NPCID.Demon || npc.type == NPCID.VoodooDemon)
                {


                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FieryTissue"), Main.rand.Next(1, 4));


                }
                if (npc.type == NPCID.BoneSerpentHead || npc.type == mod.NPCType("BoneClatterWorm_Head"))
                {

                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FieryTissue"), Main.rand.Next(2, 6));


                }
                if (npc.type == NPCID.MeteorHead)
                {
                    if (Main.rand.Next(3) == 0)
                    {

                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FieryTissue"), 1);

                    }
                }
                if (npc.type == NPCID.IcyMerman)
                {
                    if (Main.rand.Next(2) == 0)
                    {

                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrigidFragment"), Main.rand.Next(1, 4));

                    }
                }
                if (npc.type == mod.NPCType("CruptixWorm_Head"))
                {

                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrigidFragment"), Main.rand.Next(2, 6));


                }
                if (npc.type == NPCID.IceSlime || npc.type == NPCID.IceElemental)
                {
                    if (Main.rand.Next(3) == 0)
                    {
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrigidFragment"), 1);
                        }
                    }
                }
                if (npc.type == NPCID.IceGolem)
                {
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrigidFragment"), Main.rand.Next(4, 10));
                    }

                }
                if (npc.type == NPCID.IceTortoise)
                {
                    if (Main.rand.Next(3) == 0)
                    {
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrigidFragment"), Main.rand.Next(2, 8));
                        }
                    }
                }
            }
            if (npc.type == NPCID.MeteorHead || npc.type == mod.NPCType("FlameSpitter"))
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MeteoritePowerCore"), Main.rand.Next(1, 3));
            }
            if (npc.type == NPCID.UndeadMiner || npc.type == NPCID.CaveBat || npc.type == NPCID.DiggerHead || npc.type == NPCID.Skeleton || npc.type == NPCID.Crawdad || npc.type == NPCID.GiantShelly || npc.type == NPCID.BabySlime || npc.type == NPCID.BlackSlime)
            {
                if (Main.rand.Next(2) == 0)
                {
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OreCluster"), 1);
                    }
                }
            }
            if (npc.type == NPCID.BoneSerpentHead)
            {
                if (Main.rand.Next(2) == 0)
                {
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BloodEnergy"), 1);
                    }
                }
            }
            /*Seeker item drops
			below
			*/
            if (npc.type == NPCID.GiantShelly)
            {
                if (Main.rand.Next(10) == 0)
                {
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MagicCherry"), 1);
                    }
                }
            }
            if (npc.type == NPCID.GiantShelly2)
            {
                if (Main.rand.Next(10) == 0)
                {
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MagicCherry"), 1);
                    }
                }
            }
            if (npc.type == NPCID.Crawdad)
            {
                if (Main.rand.Next(10) == 0)
                {
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MagicCherry"), 1);
                    }
                }
            }
            if (npc.type == NPCID.Crawdad2)
            {
                if (Main.rand.Next(10) == 0)
                {
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MagicCherry"), 1);
                    }
                }
            }
            if (npc.type == NPCID.GreekSkeleton)
            {
                if (NPC.downedBoss1)
                {
                    Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RosyGoldChunk"), Main.rand.Next(2, 4));
                }
                if (Main.rand.Next(10) == 0)
                {
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OddGemstone"), 1);
                    }
                }
            }
            if (npc.type == NPCID.Medusa)
            {
                if (Main.rand.Next(6) == 0)
                {
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OddGemstone"), 1);
                    }
                }
            }
            if (npc.type == NPCID.GraniteGolem)
            {
                if (NPC.downedBoss1)
                {
                    Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GraniteScale"), Main.rand.Next(2, 4));
                }
                if (Main.rand.Next(2) == 0)
                {

                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GraniteEnergyCore"), 1);

                }
                if (Main.rand.Next(10) == 0)
                {

                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OddGemstone"), 1);

                }
                if (Main.rand.Next(3) == 0)
                {

                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GraniteEnergyCore"), 1);

                }
            }
            if (npc.type == NPCID.GraniteFlyer)
            {
                if (NPC.downedBoss1)
                {
                    Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GraniteScale"), Main.rand.Next(2, 4));
                }
                if (Main.rand.Next(10) == 0)
                {
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OddGemstone"), 1);
                    }
                }
            }
            if (npc.type == NPCID.BlueSlime)
            {
                if (Main.rand.Next(30) == 0)
                {
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WeirdSludge"), 1);
                    }
                }
            }
            if (npc.type == NPCID.Salamander)
            {
                if (Main.rand.Next(10) == 0)
                {
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MagicCherry"), 1);
                    }
                }
            }
            if (npc.type == NPCID.Demon)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BloodEnergy"), 1);
            }
            if (npc.type == NPCID.IceSlime)
            {
                if (Main.rand.Next(3) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceEnergy"), 1);
                }
            }
        }
    }
}