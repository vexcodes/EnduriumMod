using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.StarShip
{
    public class StarTreasureBag : ModItem
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
            bossBagNPC = mod.NPCType("StarShippo");
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
            int choice2 = Main.rand.Next(2);
            if (choice == 0)
            {
                player.QuickSpawnItem(mod.ItemType("StarBeater"));
            }

            if (choice == 1)
            {
                player.QuickSpawnItem(mod.ItemType("StarClaymore"));
            }

            if (choice == 2)
            {
                player.QuickSpawnItem(mod.ItemType("StarRainPedestrian"));
            }
            if (choice == 3)
            {
                player.QuickSpawnItem(mod.ItemType("StarSpin"));
            }
            if (choice2 == 1)
            {
                player.QuickSpawnItem(mod.ItemType("StormBulwark"));
            }
            if (choice2 == 0)
            {
                player.QuickSpawnItem(mod.ItemType("EyeoftheStorm"));
            }
            player.QuickSpawnItem(mod.ItemType("StarShard"), Main.rand.Next(35, 55));
            if (Main.rand.Next(2) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("CoreofInfusion"));
            }
        }
    }
}