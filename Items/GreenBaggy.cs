using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items
{
    public class GreenBaggy : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Perennial Herb Bag");
            Tooltip.SetDefault("Right Click to open");
        }
        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.consumable = true;
            item.width = 32;
            item.height = 32;
            item.rare = 3;
            bossBagNPC = mod.NPCType("Seeker");
        }
        public override bool CanRightClick()
        {
            return true;
        }

        public override void OpenBossBag(Player player)
        {
            player.QuickSpawnItem(ItemID.SilverCoin, Main.rand.Next(10, 25));
            player.QuickSpawnItem(ItemID.CopperCoin, Main.rand.Next(10, 25));
            if (Main.rand.Next(25) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("JungleSporeStaff"));
            }

            if (Main.rand.Next(25) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("SpiritOrb"));
            }
            if (Main.rand.Next(10) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("BronzeCoin"), Main.rand.Next(1, 10));
            }
            if (Main.rand.Next(4) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("BronzeCoin"), Main.rand.Next(1, 4));
            }
            if (Main.rand.Next(3) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("MagicPowder"), Main.rand.Next(1, 3));
            }
            if (NPC.downedBoss3)
            {
                if (Main.rand.Next(4) == 0)
                {
                    player.QuickSpawnItem(mod.ItemType("Jade"), Main.rand.Next(1, 3));
                }
            }
            if (Main.rand.Next(6) == 0)
            {
                player.QuickSpawnItem(ItemID.GlowingMushroom, Main.rand.Next(10, 25));
            }


            if (Main.rand.Next(6) == 0)
            {
                player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(1, 5));
            }
            if (Main.rand.Next(10) == 0)
            {
                player.QuickSpawnItem(ItemID.Daybloom, Main.rand.Next(1, 2));
            }

            if (Main.rand.Next(6) == 0)
            {
                player.QuickSpawnItem(ItemID.Moonglow, Main.rand.Next(1, 2));
            }
            if (Main.rand.Next(6) == 0)
            {
                player.QuickSpawnItem(ItemID.Fireblossom, Main.rand.Next(1, 2));
            }
            if (Main.rand.Next(6) == 0)
            {
                player.QuickSpawnItem(ItemID.Waterleaf, Main.rand.Next(1, 2));
            }
            if (Main.rand.Next(100) == 0)
            {
                player.QuickSpawnItem(ItemID.PlatinumCoin);
            }
        }
    }
}