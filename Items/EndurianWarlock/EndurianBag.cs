using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.EndurianWarlock
{
    public class EndurianBag : ModItem
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
            bossBagNPC = mod.NPCType("EndurianWarlock");
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
            int choice = Main.rand.Next(4);
            if (choice == 0)
            {
                player.QuickSpawnItem(mod.ItemType("FalconEagle"));
            }

            if (choice == 1)
            {
                player.QuickSpawnItem(mod.ItemType("FalconStaff"));
            }

            if (choice == 2)
            {
                player.QuickSpawnItem(mod.ItemType("FalconBroadsword"));
            }

            if (choice == 3)
            {
                player.QuickSpawnItem(mod.ItemType("FalconCrossbow"));
            }
                player.QuickSpawnItem(mod.ItemType("EndurianHeart"));
            player.QuickSpawnItem(mod.ItemType("AcidCore"), Main.rand.Next(25, 45));
            player.QuickSpawnItem(mod.ItemType("ElderBranch"), Main.rand.Next(15, 25));
        }
    }
}