using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.ThePrismArcanum
{
    public class PrismBag : ModItem
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
            bossBagNPC = mod.NPCType("ThePrismArcanum");
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
            player.QuickSpawnItem(mod.ItemType("CrypticPowerCell"), Main.rand.Next(15, 25));
            int choice = Main.rand.Next(6);
            if (choice == 0)
            {
                player.QuickSpawnItem(mod.ItemType("ArcanumPike"));      
            }
			
            if (choice == 1)
            {
                player.QuickSpawnItem(mod.ItemType("FrozenCleaver"));
            }
			
            if (choice == 2)
            {
                player.QuickSpawnItem(mod.ItemType("TheArcticWind"));
            }
			
            if (choice == 3)
            {
                player.QuickSpawnItem(mod.ItemType("IceClasper"));
            }
            if (choice == 4)
            {
                player.QuickSpawnItem(mod.ItemType("IceAncient"));
            }
            if (choice == 5)
            {
                player.QuickSpawnItem(mod.ItemType("IceFlare"));
            }
            if (Main.rand.Next(3) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("CrypticBand"));
            }
            if (Main.rand.Next(5) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("PrismHood"));
            }
            player.QuickSpawnItem(mod.ItemType("TheFrozenMoonlight"));
        }
    }
}
