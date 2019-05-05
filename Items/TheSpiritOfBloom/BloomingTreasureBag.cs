using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.TheSpiritOfBloom
{
    public class BloomingTreasureBag : ModItem
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
            bossBagNPC = mod.NPCType("TheSpiritOfBloom");
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
            int choice = Main.rand.Next(8);
            if (choice == 0)
            {
                player.QuickSpawnItem(mod.ItemType("BlessedBlade"));      
            }
			
            if (choice == 1)
            {
                player.QuickSpawnItem(mod.ItemType("TheStaffOfBloom"));
            }
			
            if (choice == 2)
            {
                player.QuickSpawnItem(mod.ItemType("SpiritSpear"));
            }
			
            if (choice == 3)
            {
                player.QuickSpawnItem(mod.ItemType("SpiritBuckshot"));
            }
			            if (choice == 4)
            {
                player.QuickSpawnItem(mod.ItemType("TheBowOfBloom"));
            }
			            if (choice == 5)
            {
                player.QuickSpawnItem(mod.ItemType("BloomingEmblem"));
            }
			            if (choice == 6)
            {
                player.QuickSpawnItem(mod.ItemType("SpiritFlameStaff"));
            }
			            if (choice == 7)
            {
                player.QuickSpawnItem(mod.ItemType("BlessedHatchet"));
            }
            player.QuickSpawnItem(mod.ItemType("TheCrownOfNature"));
			            player.QuickSpawnItem(mod.ItemType("TrueNatureEssence"), Main.rand.Next(12, 28));
        }
    }
}
