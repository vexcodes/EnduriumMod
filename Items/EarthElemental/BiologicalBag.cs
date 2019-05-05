using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.EarthElemental
{
    public class BiologicalBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("Right Click to open");
        }
        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.consumable = true;
            item.width = 32;
            item.height = 32;
            item.rare = -12;
            bossBagNPC = mod.NPCType("TheSwarm");
            item.expert = true;
        }
        public override bool CanRightClick()
        {
            return true;
        }

        public override void OpenBossBag(Player player)
        {
            player.TryGettingDevArmor();
            player.TryGettingDevArmor();
            int choice = Main.rand.Next(2);
            if (Main.rand.Next(2) == 0)
            {
                if (choice == 0)
                {
                    player.QuickSpawnItem(mod.ItemType("EarthBuster"));
                }

                if (choice == 1)
                {
                    player.QuickSpawnItem(mod.ItemType("EarthMagnum"));
                }
            }

            if (Main.rand.Next(2) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("BiologicalMarine"));
            }
            if (Main.rand.Next(2) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("SporeCleaver"));
            }
            if (Main.rand.Next(2) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("ThePlague"));
            }
            player.QuickSpawnItem(mod.ItemType("PlagueCore"));
            player.QuickSpawnItem(mod.ItemType("BioScale"), Main.rand.Next(25, 35));
        }
    }
}
