using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.TheScourge
{
    public class JungleBag : ModItem
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
            bossBagNPC = mod.NPCType("TheScourge");
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
            int choice = Main.rand.Next(5);
            if (choice == 0)
            {
                player.QuickSpawnItem(mod.ItemType("JungleHatchet"));
            }

            if (choice == 1)
            {
                player.QuickSpawnItem(mod.ItemType("RazorShot"));
            }

            if (choice == 2)
            {
                player.QuickSpawnItem(mod.ItemType("SapSpray"));
            }

            if (choice == 3)
            {
                player.QuickSpawnItem(mod.ItemType("TheScourge"));
            }
            if (choice == 4)
            {
                player.QuickSpawnItem(mod.ItemType("ThornBlade"));
            }
            player.QuickSpawnItem(mod.ItemType("JungleCrown"));
        }
    }
}
